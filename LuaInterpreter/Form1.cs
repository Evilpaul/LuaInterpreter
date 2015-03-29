﻿using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LuaInterpreter
{
	public partial class Form1 : Form
	{
		private IProgress<string> progress_str;
		private IProgress<bool> progress_hmi;

		private Worker worker;

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

			worker = new Worker(ref outputListBox, progress_hmi);

			progress_str.Report("MoonSharp " + Worker.getMoonsharpVersion());
			progress_str.Report("Lua " + Worker.getLuaVersion());
		}

		private void runButton_Click(object sender, EventArgs e)
		{
			outputListBox.Items.Clear();

			if (String.IsNullOrEmpty(timeoutTextBox.Text))
			{
				progress_str.Report("Timeout value is invalid");
			}
			else
			{
				worker.doScript(inputTextBox.Text, Convert.ToInt32(timeoutTextBox.Text));
			}
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
