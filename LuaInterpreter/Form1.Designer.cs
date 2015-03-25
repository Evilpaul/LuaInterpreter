﻿namespace LuaInterpreter
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.runButton = new System.Windows.Forms.Button();
			this.inputGroupBox = new System.Windows.Forms.GroupBox();
			this.inputTextBox = new System.Windows.Forms.TextBox();
			this.outputGroupBox = new System.Windows.Forms.GroupBox();
			this.outputListBox = new System.Windows.Forms.ListBox();
			this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItem_clear = new System.Windows.Forms.ToolStripMenuItem();
			this.tableLayoutPanel1.SuspendLayout();
			this.inputGroupBox.SuspendLayout();
			this.outputGroupBox.SuspendLayout();
			this.contextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.runButton, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.inputGroupBox, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.outputGroupBox, 0, 2);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.41688F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.58312F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(678, 495);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// runButton
			// 
			this.runButton.Location = new System.Drawing.Point(3, 3);
			this.runButton.Name = "runButton";
			this.runButton.Size = new System.Drawing.Size(75, 21);
			this.runButton.TabIndex = 0;
			this.runButton.Text = "Run Code";
			this.runButton.UseVisualStyleBackColor = true;
			this.runButton.Click += new System.EventHandler(this.runButton_Click);
			// 
			// inputGroupBox
			// 
			this.inputGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.inputGroupBox.Controls.Add(this.inputTextBox);
			this.inputGroupBox.Location = new System.Drawing.Point(3, 30);
			this.inputGroupBox.Name = "inputGroupBox";
			this.inputGroupBox.Size = new System.Drawing.Size(672, 331);
			this.inputGroupBox.TabIndex = 1;
			this.inputGroupBox.TabStop = false;
			this.inputGroupBox.Text = "Input";
			// 
			// inputTextBox
			// 
			this.inputTextBox.AcceptsReturn = true;
			this.inputTextBox.AcceptsTab = true;
			this.inputTextBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.inputTextBox.Location = new System.Drawing.Point(6, 19);
			this.inputTextBox.MaxLength = 1677215;
			this.inputTextBox.Multiline = true;
			this.inputTextBox.Name = "inputTextBox";
			this.inputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.inputTextBox.Size = new System.Drawing.Size(660, 306);
			this.inputTextBox.TabIndex = 0;
			this.inputTextBox.Text = "-- defines a factorial function\r\nfunction fact (n)\r\n\tif (n == 0) then\r\n\t\treturn 1" +
    "\r\n\telse\r\n\t\treturn n*fact(n - 1)\r\n\tend\r\nend\r\n\r\nreturn fact(5)";
			this.inputTextBox.WordWrap = false;
			// 
			// outputGroupBox
			// 
			this.outputGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.outputGroupBox.Controls.Add(this.outputListBox);
			this.outputGroupBox.Location = new System.Drawing.Point(3, 367);
			this.outputGroupBox.Name = "outputGroupBox";
			this.outputGroupBox.Size = new System.Drawing.Size(672, 125);
			this.outputGroupBox.TabIndex = 2;
			this.outputGroupBox.TabStop = false;
			this.outputGroupBox.Text = "Output";
			// 
			// outputListBox
			// 
			this.outputListBox.ContextMenuStrip = this.contextMenuStrip;
			this.outputListBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.outputListBox.FormattingEnabled = true;
			this.outputListBox.ItemHeight = 16;
			this.outputListBox.Location = new System.Drawing.Point(6, 19);
			this.outputListBox.Name = "outputListBox";
			this.outputListBox.Size = new System.Drawing.Size(660, 100);
			this.outputListBox.TabIndex = 0;
			// 
			// contextMenuStrip
			// 
			this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_clear});
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new System.Drawing.Size(153, 48);
			// 
			// toolStripMenuItem_clear
			// 
			this.toolStripMenuItem_clear.Name = "toolStripMenuItem_clear";
			this.toolStripMenuItem_clear.Size = new System.Drawing.Size(152, 22);
			this.toolStripMenuItem_clear.Text = "Clear";
			this.toolStripMenuItem_clear.Click += new System.EventHandler(this.toolStripMenuItem_clear_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(702, 519);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Lua Interpreter";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.inputGroupBox.ResumeLayout(false);
			this.inputGroupBox.PerformLayout();
			this.outputGroupBox.ResumeLayout(false);
			this.contextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button runButton;
		private System.Windows.Forms.GroupBox inputGroupBox;
		private System.Windows.Forms.GroupBox outputGroupBox;
		private System.Windows.Forms.ListBox outputListBox;
		private System.Windows.Forms.TextBox inputTextBox;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_clear;

	}
}

