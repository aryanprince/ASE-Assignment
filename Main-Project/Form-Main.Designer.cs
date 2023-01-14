namespace ASE_Assignment
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.picDrawingCanvas = new System.Windows.Forms.PictureBox();
            this.txtCommandLine = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.mnuMenuStrip = new System.Windows.Forms.MenuStrip();
            this.mniFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mniLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.mniHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mniAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mniAryanGitHub = new System.Windows.Forms.ToolStripMenuItem();
            this.lblCoordinatesValues = new System.Windows.Forms.Label();
            this.lblCoordinatesLabel = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.lblFillState = new System.Windows.Forms.Label();
            this.lblPenColor = new System.Windows.Forms.Label();
            this.txtCommandArea = new System.Windows.Forms.TextBox();
            this.gbMultiLineCommands = new System.Windows.Forms.GroupBox();
            this.gbDrawingCanvas = new System.Windows.Forms.GroupBox();
            this.gbSingleLineCommands = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDrawingCanvas)).BeginInit();
            this.mnuMenuStrip.SuspendLayout();
            this.gbMultiLineCommands.SuspendLayout();
            this.gbDrawingCanvas.SuspendLayout();
            this.gbSingleLineCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // picDrawingCanvas
            // 
            this.picDrawingCanvas.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.picDrawingCanvas.Location = new System.Drawing.Point(7, 28);
            this.picDrawingCanvas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picDrawingCanvas.Name = "picDrawingCanvas";
            this.picDrawingCanvas.Size = new System.Drawing.Size(800, 500);
            this.picDrawingCanvas.TabIndex = 0;
            this.picDrawingCanvas.TabStop = false;
            this.picDrawingCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxCanvas_Paint);
            // 
            // txtCommandLine
            // 
            this.txtCommandLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCommandLine.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommandLine.Location = new System.Drawing.Point(7, 28);
            this.txtCommandLine.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCommandLine.Name = "txtCommandLine";
            this.txtCommandLine.Size = new System.Drawing.Size(431, 31);
            this.txtCommandLine.TabIndex = 0;
            this.txtCommandLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCommandLine_KeyDown);
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(54)))), ((int)(((byte)(61)))));
            this.btnRun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRun.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.ForeColor = System.Drawing.Color.White;
            this.btnRun.Location = new System.Drawing.Point(19, 591);
            this.btnRun.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(96, 40);
            this.btnRun.TabIndex = 4;
            this.btnRun.Text = "run";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.BtnRun_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(54)))), ((int)(((byte)(61)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(132, 591);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(96, 40);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // mnuMenuStrip
            // 
            this.mnuMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.mnuMenuStrip.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniFile,
            this.mniHelp,
            this.mniAbout});
            this.mnuMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuMenuStrip.Name = "mnuMenuStrip";
            this.mnuMenuStrip.Size = new System.Drawing.Size(1339, 28);
            this.mnuMenuStrip.TabIndex = 5;
            this.mnuMenuStrip.Text = "menuStrip1";
            // 
            // mniFile
            // 
            this.mniFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniSave,
            this.mniLoad});
            this.mniFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mniFile.ForeColor = System.Drawing.Color.White;
            this.mniFile.Name = "mniFile";
            this.mniFile.Size = new System.Drawing.Size(46, 24);
            this.mniFile.Text = "File";
            // 
            // mniSave
            // 
            this.mniSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.mniSave.ForeColor = System.Drawing.Color.White;
            this.mniSave.Name = "mniSave";
            this.mniSave.ShortcutKeyDisplayString = "";
            this.mniSave.Size = new System.Drawing.Size(125, 26);
            this.mniSave.Text = "Save";
            this.mniSave.Click += new System.EventHandler(this.SaveMenuItem_Click);
            // 
            // mniLoad
            // 
            this.mniLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.mniLoad.ForeColor = System.Drawing.Color.White;
            this.mniLoad.Name = "mniLoad";
            this.mniLoad.Size = new System.Drawing.Size(125, 26);
            this.mniLoad.Text = "Load";
            this.mniLoad.Click += new System.EventHandler(this.LoadMenuItem_Click);
            // 
            // mniHelp
            // 
            this.mniHelp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mniHelp.ForeColor = System.Drawing.Color.White;
            this.mniHelp.Name = "mniHelp";
            this.mniHelp.Size = new System.Drawing.Size(55, 24);
            this.mniHelp.Text = "Help";
            // 
            // mniAbout
            // 
            this.mniAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniAryanGitHub});
            this.mniAbout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mniAbout.ForeColor = System.Drawing.Color.White;
            this.mniAbout.Name = "mniAbout";
            this.mniAbout.Size = new System.Drawing.Size(64, 24);
            this.mniAbout.Text = "About";
            // 
            // mniAryanGitHub
            // 
            this.mniAryanGitHub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.mniAryanGitHub.ForeColor = System.Drawing.Color.White;
            this.mniAryanGitHub.Name = "mniAryanGitHub";
            this.mniAryanGitHub.Size = new System.Drawing.Size(285, 26);
            this.mniAryanGitHub.Text = "Built with ❤️ by Aryan Prince";
            this.mniAryanGitHub.Click += new System.EventHandler(this.AryanMenuItem_Click);
            // 
            // lblCoordinatesValues
            // 
            this.lblCoordinatesValues.AutoSize = true;
            this.lblCoordinatesValues.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoordinatesValues.ForeColor = System.Drawing.Color.White;
            this.lblCoordinatesValues.Location = new System.Drawing.Point(476, 626);
            this.lblCoordinatesValues.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCoordinatesValues.Name = "lblCoordinatesValues";
            this.lblCoordinatesValues.Size = new System.Drawing.Size(195, 33);
            this.lblCoordinatesValues.TabIndex = 9;
            this.lblCoordinatesValues.Text = "X:0, Y:0 (default)";
            // 
            // lblCoordinatesLabel
            // 
            this.lblCoordinatesLabel.AutoSize = true;
            this.lblCoordinatesLabel.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoordinatesLabel.ForeColor = System.Drawing.Color.White;
            this.lblCoordinatesLabel.Location = new System.Drawing.Point(476, 598);
            this.lblCoordinatesLabel.Name = "lblCoordinatesLabel";
            this.lblCoordinatesLabel.Size = new System.Drawing.Size(236, 33);
            this.lblCoordinatesLabel.TabIndex = 10;
            this.lblCoordinatesLabel.Text = "current coordinates:";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.White;
            this.lblError.Location = new System.Drawing.Point(20, 662);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(2, 30);
            this.lblError.TabIndex = 1;
            // 
            // lblFillState
            // 
            this.lblFillState.AutoSize = true;
            this.lblFillState.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFillState.ForeColor = System.Drawing.Color.White;
            this.lblFillState.Location = new System.Drawing.Point(1172, 598);
            this.lblFillState.Name = "lblFillState";
            this.lblFillState.Size = new System.Drawing.Size(146, 33);
            this.lblFillState.TabIndex = 12;
            this.lblFillState.Text = "fill: disabled";
            // 
            // lblPenColor
            // 
            this.lblPenColor.AutoSize = true;
            this.lblPenColor.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPenColor.ForeColor = System.Drawing.Color.White;
            this.lblPenColor.Location = new System.Drawing.Point(1166, 626);
            this.lblPenColor.Name = "lblPenColor";
            this.lblPenColor.Size = new System.Drawing.Size(165, 33);
            this.lblPenColor.TabIndex = 13;
            this.lblPenColor.Text = "pen color: red";
            // 
            // txtCommandArea
            // 
            this.txtCommandArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCommandArea.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommandArea.Location = new System.Drawing.Point(7, 28);
            this.txtCommandArea.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCommandArea.Multiline = true;
            this.txtCommandArea.Name = "txtCommandArea";
            this.txtCommandArea.Size = new System.Drawing.Size(431, 428);
            this.txtCommandArea.TabIndex = 0;
            // 
            // gbMultiLineCommands
            // 
            this.gbMultiLineCommands.Controls.Add(this.txtCommandArea);
            this.gbMultiLineCommands.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMultiLineCommands.ForeColor = System.Drawing.Color.White;
            this.gbMultiLineCommands.Location = new System.Drawing.Point(12, 42);
            this.gbMultiLineCommands.Name = "gbMultiLineCommands";
            this.gbMultiLineCommands.Size = new System.Drawing.Size(445, 464);
            this.gbMultiLineCommands.TabIndex = 10;
            this.gbMultiLineCommands.TabStop = false;
            this.gbMultiLineCommands.Text = "Multi-line Commands";
            // 
            // gbDrawingCanvas
            // 
            this.gbDrawingCanvas.Controls.Add(this.picDrawingCanvas);
            this.gbDrawingCanvas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDrawingCanvas.ForeColor = System.Drawing.Color.White;
            this.gbDrawingCanvas.Location = new System.Drawing.Point(481, 42);
            this.gbDrawingCanvas.Name = "gbDrawingCanvas";
            this.gbDrawingCanvas.Size = new System.Drawing.Size(816, 536);
            this.gbDrawingCanvas.TabIndex = 8;
            this.gbDrawingCanvas.TabStop = false;
            this.gbDrawingCanvas.Text = "Drawing Canvas";
            // 
            // gbSingleLineCommands
            // 
            this.gbSingleLineCommands.Controls.Add(this.txtCommandLine);
            this.gbSingleLineCommands.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSingleLineCommands.ForeColor = System.Drawing.Color.White;
            this.gbSingleLineCommands.Location = new System.Drawing.Point(12, 512);
            this.gbSingleLineCommands.Name = "gbSingleLineCommands";
            this.gbSingleLineCommands.Size = new System.Drawing.Size(445, 66);
            this.gbSingleLineCommands.TabIndex = 0;
            this.gbSingleLineCommands.TabStop = false;
            this.gbSingleLineCommands.Text = "Single-line Commands";
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(1339, 747);
            this.Controls.Add(this.gbSingleLineCommands);
            this.Controls.Add(this.gbDrawingCanvas);
            this.Controls.Add(this.gbMultiLineCommands);
            this.Controls.Add(this.lblPenColor);
            this.Controls.Add(this.lblFillState);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblCoordinatesLabel);
            this.Controls.Add(this.lblCoordinatesValues);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.mnuMenuStrip);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Graphical Programming Language";
            ((System.ComponentModel.ISupportInitialize)(this.picDrawingCanvas)).EndInit();
            this.mnuMenuStrip.ResumeLayout(false);
            this.mnuMenuStrip.PerformLayout();
            this.gbMultiLineCommands.ResumeLayout(false);
            this.gbMultiLineCommands.PerformLayout();
            this.gbDrawingCanvas.ResumeLayout(false);
            this.gbSingleLineCommands.ResumeLayout(false);
            this.gbSingleLineCommands.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDrawingCanvas;
        private System.Windows.Forms.TextBox txtCommandLine;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.MenuStrip mnuMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem mniFile;
        private System.Windows.Forms.ToolStripMenuItem mniHelp;
        private System.Windows.Forms.ToolStripMenuItem mniAbout;
        private System.Windows.Forms.Label lblCoordinatesValues;
        private System.Windows.Forms.Label lblCoordinatesLabel;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblFillState;
        private System.Windows.Forms.Label lblPenColor;
        private System.Windows.Forms.TextBox txtCommandArea;
        private System.Windows.Forms.ToolStripMenuItem mniSave;
        private System.Windows.Forms.ToolStripMenuItem mniLoad;
        private System.Windows.Forms.GroupBox gbMultiLineCommands;
        private System.Windows.Forms.GroupBox gbDrawingCanvas;
        private System.Windows.Forms.GroupBox gbSingleLineCommands;
        private System.Windows.Forms.ToolStripMenuItem mniAryanGitHub;
    }
}

