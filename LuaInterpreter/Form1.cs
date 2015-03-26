using System;
using System.Windows.Forms;
using MoonSharp.Interpreter;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;

namespace LuaInterpreter
{
	public partial class Form1 : Form
	{
		private IProgress<string> progress_str;
		private IProgress<bool> progress_hmi;

		private Thread t_work;

		public Form1()
		{
			InitializeComponent();

			progress_str = new Progress<string>(status =>
			{
				outputListBox.Items.Add(status);
				outputListBox.TopIndex = outputListBox.Items.Count - 1;
			});

			progress_hmi = new Progress<bool>(status =>
			{
				runButton.Enabled = status;
				inputTextBox.Enabled = status;
				openFileButton.Enabled = status;
				saveFileButton.Enabled = status;
				timeoutTextBox.Enabled = status;
			});

			Script.DefaultOptions.DebugPrint = s =>
			{
				progress_str.Report(s);
			};

			progress_hmi.Report(false);

			runScript("print (_VERSION)");

			progress_hmi.Report(true);
		}

		private Task runScript(string code)
		{
			return Task.Run(() =>
				{
					Stopwatch sw = new Stopwatch();
					sw.Start();

					t_work = Thread.CurrentThread;

					try
					{
						DynValue res = Script.RunString(code);
						if (res.Type != DataType.Void)
							progress_str.Report("Return value : " + res.ToString());
					}
					catch (InterpreterException ex)
					{
						progress_str.Report(ex.DecoratedMessage);
					}
					catch (Exception ex)
					{
						progress_str.Report(ex.Message);
					}

					sw.Stop();
					progress_str.Report("Script completed in : " + sw.ElapsedMilliseconds + "ms");
				});
		}

		private async void runButton_Click(object sender, EventArgs e)
		{
			outputListBox.Items.Clear();
			progress_hmi.Report(false);

			if (String.IsNullOrEmpty(timeoutTextBox.Text))
			{
				progress_str.Report("Timeout value is invalid");
			}
			else
			{
				var task = runScript(inputTextBox.Text);
				if (task == await Task.WhenAny(task, Task.Delay(Convert.ToInt16(timeoutTextBox.Text))))
				{
					await task;
				}
				else
				{
					t_work.Abort();
					progress_str.Report("Timeout reached, aborting...");
				}
			}

			progress_hmi.Report(true);
		}

		private void toolStripMenuItem_clear_Click(object sender, EventArgs e)
		{
			outputListBox.Items.Clear();
		}

		private async void openFileButton_Click(object sender, EventArgs e)
		{
			// Show the dialog and get result.
			DialogResult result = openFileDialog.ShowDialog();
			if (result == DialogResult.OK) // Test result.
			{
				progress_hmi.Report(false);

				using (StreamReader sr = new StreamReader(openFileDialog.FileName))
				{
					StringBuilder sb = new StringBuilder(inputTextBox.MaxLength);
					string currLine;

					outputListBox.Items.Clear();
					progress_str.Report("Opening " + openFileDialog.FileName);

					while ((currLine = await sr.ReadLineAsync()) != null)
					{
						sb.AppendLine(currLine);
					}
					inputTextBox.Text = sb.ToString();
				}

				progress_hmi.Report(true);
			}
		}

		private async void saveFileButton_Click(object sender, EventArgs e)
		{
			// Show the dialog and get result.
			DialogResult result = saveFileDialog.ShowDialog();
			if (result == DialogResult.OK) // Test result.
			{
				progress_hmi.Report(false);

				using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
				{
					outputListBox.Items.Clear();
					progress_str.Report("Saving " + openFileDialog.FileName);

					await sw.WriteAsync(inputTextBox.Text);
					await sw.FlushAsync();
					sw.Close();
				}

				progress_hmi.Report(true);
			}
		}

		private void timeoutTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!Regex.IsMatch(e.KeyChar.ToString(), "^[0-9\b]+$"))
			{
				e.Handled = true;
			}
		}
	}
}
