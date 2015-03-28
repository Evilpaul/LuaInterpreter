using System;
using System.Windows.Forms;
using MoonSharp.Interpreter;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace LuaInterpreter
{
	public partial class Form1 : Form
	{
		private IProgress<string> progress_str;
		private IProgress<bool> progress_hmi;
		private IProgress<bool> progress_mass;

		private List<string> out_list;

		private Thread t_work;

		public Form1()
		{
			InitializeComponent();

			out_list = new List<string>();

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

			progress_mass = new Progress<bool>(StatusBar =>
			{
				outputListBox.Items.AddRange(out_list.ToArray());
				outputListBox.TopIndex = outputListBox.Items.Count - 1;

				out_list.Clear();
			});

			Script.DefaultOptions.DebugPrint = s =>
			{
				out_list.Add(s);
			};

			progress_hmi.Report(false);

			printVersion();

			progress_hmi.Report(true);
		}

		private async void printVersion()
		{
			await runScript("print (_VERSION)");
		}

		private Task runScript(string code)
		{
			out_list.Clear();

			return Task.Run(() =>
				{
					Stopwatch sw = new Stopwatch();
					t_work = Thread.CurrentThread;

					try
					{
						sw.Start();
						DynValue res = Script.RunString(code);
						if (res.Type != DataType.Void)
							out_list.Add("Return value : " + res.ToString());
					}
					catch (InterpreterException ex)
					{
						out_list.Add(ex.DecoratedMessage);
					}
					catch (Exception ex)
					{
						out_list.Add(ex.Message);
					}
					finally
					{
						sw.Stop();
						out_list.Add("Script completed in : " + sw.ElapsedMilliseconds + "ms");
						progress_mass.Report(true);
					}
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
				Task task = runScript(inputTextBox.Text);
				if (task == await Task.WhenAny(task, Task.Delay(Convert.ToInt16(timeoutTextBox.Text))))
				{
					await task;
				}
				else
				{
					t_work.Abort();
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
