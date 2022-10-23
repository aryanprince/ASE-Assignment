namespace ASE_Assignment
{
    partial class form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form));
            this.picboxCanvas = new System.Windows.Forms.PictureBox();
            this.txtCommandLine = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.richtxtCommandArea = new System.Windows.Forms.RichTextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuStripFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.lblCommandArea = new System.Windows.Forms.Label();
            this.lblCanvas = new System.Windows.Forms.Label();
            this.lblCommandLine = new System.Windows.Forms.Label();
            this.lblDebug = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picboxCanvas)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // picboxCanvas
            // 
            this.picboxCanvas.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.picboxCanvas.Location = new System.Drawing.Point(361, 56);
            this.picboxCanvas.Name = "picboxCanvas";
            this.picboxCanvas.Size = new System.Drawing.Size(617, 361);
            this.picboxCanvas.TabIndex = 0;
            this.picboxCanvas.TabStop = false;
            // 
            // txtCommandLine
            // 
            this.txtCommandLine.Location = new System.Drawing.Point(15, 347);
            this.txtCommandLine.Name = "txtCommandLine";
            this.txtCommandLine.Size = new System.Drawing.Size(297, 20);
            this.txtCommandLine.TabIndex = 1;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(15, 373);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(96, 373);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // richtxtCommandArea
            // 
            this.richtxtCommandArea.Location = new System.Drawing.Point(15, 57);
            this.richtxtCommandArea.Name = "richtxtCommandArea";
            this.richtxtCommandArea.Size = new System.Drawing.Size(323, 254);
            this.richtxtCommandArea.TabIndex = 4;
            this.richtxtCommandArea.Text = "";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripFile,
            this.menuStripHelp,
            this.menuStripAbout});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(990, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuStripFile
            // 
            this.menuStripFile.Name = "menuStripFile";
            this.menuStripFile.Size = new System.Drawing.Size(37, 20);
            this.menuStripFile.Text = "File";
            // 
            // menuStripHelp
            // 
            this.menuStripHelp.Name = "menuStripHelp";
            this.menuStripHelp.Size = new System.Drawing.Size(44, 20);
            this.menuStripHelp.Text = "Help";
            // 
            // menuStripAbout
            // 
            this.menuStripAbout.Name = "menuStripAbout";
            this.menuStripAbout.Size = new System.Drawing.Size(52, 20);
            this.menuStripAbout.Text = "About";
            // 
            // lblCommandArea
            // 
            this.lblCommandArea.AutoSize = true;
            this.lblCommandArea.Location = new System.Drawing.Point(12, 37);
            this.lblCommandArea.Name = "lblCommandArea";
            this.lblCommandArea.Size = new System.Drawing.Size(164, 13);
            this.lblCommandArea.TabIndex = 6;
            this.lblCommandArea.Text = "Enter advanced commands here:";
            // 
            // lblCanvas
            // 
            this.lblCanvas.AutoSize = true;
            this.lblCanvas.Location = new System.Drawing.Point(358, 37);
            this.lblCanvas.Name = "lblCanvas";
            this.lblCanvas.Size = new System.Drawing.Size(87, 13);
            this.lblCanvas.TabIndex = 7;
            this.lblCanvas.Text = "Drawing canvas:";
            // 
            // lblCommandLine
            // 
            this.lblCommandLine.AutoSize = true;
            this.lblCommandLine.Location = new System.Drawing.Point(12, 331);
            this.lblCommandLine.Name = "lblCommandLine";
            this.lblCommandLine.Size = new System.Drawing.Size(145, 13);
            this.lblCommandLine.TabIndex = 8;
            this.lblCommandLine.Text = "Enter simple commands here:";
            // 
            // lblDebug
            // 
            this.lblDebug.AutoSize = true;
            this.lblDebug.Location = new System.Drawing.Point(358, 431);
            this.lblDebug.Name = "lblDebug";
            this.lblDebug.Size = new System.Drawing.Size(0, 13);
            this.lblDebug.TabIndex = 9;
            // 
            // form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 558);
            this.Controls.Add(this.lblDebug);
            this.Controls.Add(this.lblCommandLine);
            this.Controls.Add(this.lblCanvas);
            this.Controls.Add(this.lblCommandArea);
            this.Controls.Add(this.richtxtCommandArea);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtCommandLine);
            this.Controls.Add(this.picboxCanvas);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "form";
            this.Text = "Graphical Programming Language";
            ((System.ComponentModel.ISupportInitialize)(this.picboxCanvas)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picboxCanvas;
        private System.Windows.Forms.TextBox txtCommandLine;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RichTextBox richtxtCommandArea;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuStripFile;
        private System.Windows.Forms.ToolStripMenuItem menuStripHelp;
        private System.Windows.Forms.ToolStripMenuItem menuStripAbout;
        private System.Windows.Forms.Label lblCommandArea;
        private System.Windows.Forms.Label lblCanvas;
        private System.Windows.Forms.Label lblCommandLine;
        private System.Windows.Forms.Label lblDebug;
    }
}

