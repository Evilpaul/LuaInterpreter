namespace LuaInterpreter
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
			this.inputGroupBox = new System.Windows.Forms.GroupBox();
			this.inputTextBox = new ICSharpCode.TextEditor.TextEditorControlEx();
			this.outputGroupBox = new System.Windows.Forms.GroupBox();
			this.outputListBox = new System.Windows.Forms.ListBox();
			this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItem_clear = new System.Windows.Forms.ToolStripMenuItem();
			this.timeoutTextBox = new System.Windows.Forms.TextBox();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.timeoutLabel = new System.Windows.Forms.Label();
			this.runButton = new System.Windows.Forms.Button();
			this.openFileButton = new System.Windows.Forms.Button();
			this.saveFileButton = new System.Windows.Forms.Button();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.panel2 = new System.Windows.Forms.Panel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.inputGroupBox.SuspendLayout();
			this.outputGroupBox.SuspendLayout();
			this.contextMenuStrip.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// inputGroupBox
			// 
			this.inputGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.inputGroupBox.Controls.Add(this.inputTextBox);
			this.inputGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.inputGroupBox.Location = new System.Drawing.Point(0, 0);
			this.inputGroupBox.Name = "inputGroupBox";
			this.inputGroupBox.Size = new System.Drawing.Size(584, 310);
			this.inputGroupBox.TabIndex = 1;
			this.inputGroupBox.TabStop = false;
			this.inputGroupBox.Text = "Input";
			// 
			// inputTextBox
			// 
			this.inputTextBox.Cursor = System.Windows.Forms.Cursors.Default;
			this.inputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.inputTextBox.EnableFolding = false;
			this.inputTextBox.FoldingStrategy = "CSharp";
			this.inputTextBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.inputTextBox.Location = new System.Drawing.Point(3, 16);
			this.inputTextBox.Name = "inputTextBox";
			this.inputTextBox.Size = new System.Drawing.Size(578, 291);
			this.inputTextBox.SyntaxHighlighting = "Lua";
			this.inputTextBox.TabIndex = 1;
			this.inputTextBox.Text = "-- defines a factorial function\r\nfunction fact (n)\r\n\tif (n == 0) then\r\n\t\treturn 1" +
    "\r\n\telse\r\n\t\treturn n*fact(n - 1)\r\n\tend\r\nend\r\n\r\nreturn fact(5)";
			// 
			// outputGroupBox
			// 
			this.outputGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.outputGroupBox.Controls.Add(this.outputListBox);
			this.outputGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.outputGroupBox.Location = new System.Drawing.Point(0, 0);
			this.outputGroupBox.Name = "outputGroupBox";
			this.outputGroupBox.Size = new System.Drawing.Size(584, 75);
			this.outputGroupBox.TabIndex = 2;
			this.outputGroupBox.TabStop = false;
			this.outputGroupBox.Text = "Output";
			// 
			// outputListBox
			// 
			this.outputListBox.ContextMenuStrip = this.contextMenuStrip;
			this.outputListBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.outputListBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.outputListBox.FormattingEnabled = true;
			this.outputListBox.ItemHeight = 16;
			this.outputListBox.Location = new System.Drawing.Point(3, 16);
			this.outputListBox.Name = "outputListBox";
			this.outputListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.outputListBox.Size = new System.Drawing.Size(578, 56);
			this.outputListBox.TabIndex = 0;
			// 
			// contextMenuStrip
			// 
			this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_clear,
            this.copyToolStripMenuItem});
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new System.Drawing.Size(153, 70);
			// 
			// toolStripMenuItem_clear
			// 
			this.toolStripMenuItem_clear.Name = "toolStripMenuItem_clear";
			this.toolStripMenuItem_clear.Size = new System.Drawing.Size(101, 22);
			this.toolStripMenuItem_clear.Text = "Clear";
			this.toolStripMenuItem_clear.Click += new System.EventHandler(this.toolStripMenuItem_clear_Click);
			// 
			// timeoutTextBox
			// 
			this.timeoutTextBox.ContextMenuStrip = this.contextMenuStrip1;
			this.timeoutTextBox.Location = new System.Drawing.Point(132, 2);
			this.timeoutTextBox.MinimumSize = new System.Drawing.Size(4, 20);
			this.timeoutTextBox.Name = "timeoutTextBox";
			this.timeoutTextBox.Size = new System.Drawing.Size(100, 20);
			this.timeoutTextBox.TabIndex = 4;
			this.timeoutTextBox.Text = "500";
			this.toolTip1.SetToolTip(this.timeoutTextBox, "Nominal timout in millisceconds\r\n\r\nHigh processing (especially text output) will " +
        "skew the actual timout period.");
			this.timeoutTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.timeoutTextBox_KeyPress);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
			// 
			// timeoutLabel
			// 
			this.timeoutLabel.AutoSize = true;
			this.timeoutLabel.Location = new System.Drawing.Point(81, 5);
			this.timeoutLabel.Name = "timeoutLabel";
			this.timeoutLabel.Size = new System.Drawing.Size(45, 13);
			this.timeoutLabel.TabIndex = 3;
			this.timeoutLabel.Text = "Timeout";
			this.timeoutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// runButton
			// 
			this.runButton.Dock = System.Windows.Forms.DockStyle.Left;
			this.runButton.Location = new System.Drawing.Point(0, 0);
			this.runButton.Name = "runButton";
			this.runButton.Size = new System.Drawing.Size(75, 23);
			this.runButton.TabIndex = 0;
			this.runButton.Text = "Run Code";
			this.runButton.UseVisualStyleBackColor = true;
			this.runButton.Click += new System.EventHandler(this.runButton_Click);
			// 
			// openFileButton
			// 
			this.openFileButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.openFileButton.Location = new System.Drawing.Point(509, 0);
			this.openFileButton.Name = "openFileButton";
			this.openFileButton.Size = new System.Drawing.Size(75, 23);
			this.openFileButton.TabIndex = 1;
			this.openFileButton.Text = "Open File";
			this.openFileButton.UseVisualStyleBackColor = true;
			this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
			// 
			// saveFileButton
			// 
			this.saveFileButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.saveFileButton.Location = new System.Drawing.Point(434, 0);
			this.saveFileButton.Name = "saveFileButton";
			this.saveFileButton.Size = new System.Drawing.Size(75, 23);
			this.saveFileButton.TabIndex = 2;
			this.saveFileButton.Text = "Save File";
			this.saveFileButton.UseVisualStyleBackColor = true;
			this.saveFileButton.Click += new System.EventHandler(this.saveFileButton_Click);
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "*.lua";
			this.openFileDialog.Filter = "Lua files|*.lua|All files|*.*";
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.DefaultExt = "lua";
			this.saveFileDialog.Filter = "Lua files|*.lua|All files|*.*";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.timeoutTextBox);
			this.panel2.Controls.Add(this.saveFileButton);
			this.panel2.Controls.Add(this.timeoutLabel);
			this.panel2.Controls.Add(this.openFileButton);
			this.panel2.Controls.Add(this.runButton);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(584, 23);
			this.panel2.TabIndex = 2;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 23);
			this.splitContainer1.MinimumSize = new System.Drawing.Size(0, 100);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.inputGroupBox);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.outputGroupBox);
			this.splitContainer1.Panel2MinSize = 75;
			this.splitContainer1.Size = new System.Drawing.Size(584, 389);
			this.splitContainer1.SplitterDistance = 310;
			this.splitContainer1.TabIndex = 3;
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.copyToolStripMenuItem.Text = "Copy";
			this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 412);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.panel2);
			this.MinimumSize = new System.Drawing.Size(420, 250);
			this.Name = "Form1";
			this.Text = "Lua Interpreter";
			this.inputGroupBox.ResumeLayout(false);
			this.outputGroupBox.ResumeLayout(false);
			this.contextMenuStrip.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button runButton;
		private System.Windows.Forms.GroupBox inputGroupBox;
		private System.Windows.Forms.GroupBox outputGroupBox;
		private System.Windows.Forms.ListBox outputListBox;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_clear;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.Button openFileButton;
		private System.Windows.Forms.Button saveFileButton;
		private System.Windows.Forms.TextBox timeoutTextBox;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label timeoutLabel;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private ICSharpCode.TextEditor.TextEditorControlEx inputTextBox;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;

	}
}

