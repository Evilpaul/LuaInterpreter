using System;
using System.Windows.Forms;
using MoonSharp.Interpreter;

namespace LuaInterpreter
{
	public partial class Form1 : Form
	{
		private IProgress<string> progress_str;

		public Form1()
		{
			InitializeComponent();

			progress_str = new Progress<string>(status =>
			{
				outputListBox.Items.Add(status);
				outputListBox.TopIndex = outputListBox.Items.Count - 1;
			});

			inputTextBox.Text = @"-- defines a factorial function
function fact (n)
	if (n == 0) then
		return 1
	else
		return n*fact(n - 1)
	end
end

return fact(5)";

			Script.DefaultOptions.DebugPrint = s =>
			{
				progress_str.Report(s);
			};
			Script.RunString("print (_VERSION)");
		}

		private void runButton_Click(object sender, EventArgs e)
		{
			outputListBox.Items.Clear();

			try
			{
				DynValue res = Script.RunString(inputTextBox.Text);
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
		}
	}
}
