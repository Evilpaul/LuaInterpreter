using System;
using System.Windows.Forms;
using MoonSharp.Interpreter;
using System.Threading.Tasks;

namespace LuaInterpreter
{
	public partial class Form1 : Form
	{
		private IProgress<string> progress_str;
		private IProgress<bool> progress_hmi;

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
					try
					{
						DynValue res = Script.RunString(code);
						if (res.Type != DataType.Void)
							progress_str.Report(res.ToString());
					}
					catch (InterpreterException ex)
					{
						progress_str.Report(ex.DecoratedMessage);
					}
					catch (Exception ex)
					{
						progress_str.Report(ex.Message);
					}
				});
		}

		private async void runButton_Click(object sender, EventArgs e)
		{
			outputListBox.Items.Clear();
			progress_hmi.Report(false);

			await runScript(inputTextBox.Text);

			progress_hmi.Report(true);
		}

		private void toolStripMenuItem_clear_Click(object sender, EventArgs e)
		{
			outputListBox.Items.Clear();
		}
	}
}
