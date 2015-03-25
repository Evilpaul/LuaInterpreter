using System;
using System.Windows.Forms;
using MoonSharp.Interpreter;

namespace LuaInterpreter
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

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
				outputListBox.Items.Add(s);
			};
			Script.RunString("print (_VERSION)");
		}

		private void runButton_Click(object sender, EventArgs e)
		{
			outputListBox.Items.Clear();

			try
			{
				DynValue res = Script.RunString(inputTextBox.Text);
				outputListBox.Items.Add(res.ToString());
			}
			catch (InterpreterException ex)
			{
				outputListBox.Items.Add(ex.DecoratedMessage);
			}
			catch (Exception ex)
			{
				outputListBox.Items.Add(ex.Message);
			}
		}
	}
}
