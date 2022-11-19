namespace ASE_Assignment
{
    partial class MyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyForm));
            this.PictureBoxCanvas = new System.Windows.Forms.PictureBox();
            this.TxtCommandLine = new System.Windows.Forms.TextBox();
            this.BtnRun = new System.Windows.Forms.Button();
            this.BtnClear = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuStripFile = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.AryanMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblCoordinates = new System.Windows.Forms.Label();
            this.lblCoordinatesInfo = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.lblFillState = new System.Windows.Forms.Label();
            this.lblPenColor = new System.Windows.Forms.Label();
            this.TxtCommandArea = new System.Windows.Forms.TextBox();
            this.btnRunMultiline = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxCanvas)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureBoxCanvas
            // 
            this.PictureBoxCanvas.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PictureBoxCanvas.Location = new System.Drawing.Point(7, 28);
            this.PictureBoxCanvas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PictureBoxCanvas.Name = "PictureBoxCanvas";
            this.PictureBoxCanvas.Size = new System.Drawing.Size(800, 500);
            this.PictureBoxCanvas.TabIndex = 0;
            this.PictureBoxCanvas.TabStop = false;
            this.PictureBoxCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxCanvas_Paint);
            // 
            // TxtCommandLine
            // 
            this.TxtCommandLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCommandLine.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCommandLine.Location = new System.Drawing.Point(7, 28);
            this.TxtCommandLine.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TxtCommandLine.Name = "TxtCommandLine";
            this.TxtCommandLine.Size = new System.Drawing.Size(431, 26);
            this.TxtCommandLine.TabIndex = 0;
            this.TxtCommandLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCommandLine_KeyDown);
            // 
            // BtnRun
            // 
            this.BtnRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(54)))), ((int)(((byte)(61)))));
            this.BtnRun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRun.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRun.ForeColor = System.Drawing.Color.White;
            this.BtnRun.Location = new System.Drawing.Point(19, 591);
            this.BtnRun.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnRun.Name = "BtnRun";
            this.BtnRun.Size = new System.Drawing.Size(96, 40);
            this.BtnRun.TabIndex = 2;
            this.BtnRun.Text = "run";
            this.BtnRun.UseVisualStyleBackColor = false;
            this.BtnRun.Click += new System.EventHandler(this.BtnRun_Click);
            // 
            // BtnClear
            // 
            this.BtnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(54)))), ((int)(((byte)(61)))));
            this.BtnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClear.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClear.ForeColor = System.Drawing.Color.White;
            this.BtnClear.Location = new System.Drawing.Point(132, 591);
            this.BtnClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(96, 40);
            this.BtnClear.TabIndex = 3;
            this.BtnClear.Text = "clear";
            this.BtnClear.UseVisualStyleBackColor = false;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.menuStrip.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripFile,
            this.menuStripHelp,
            this.menuStripAbout});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1339, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuStripFile
            // 
            this.menuStripFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveMenuItem,
            this.LoadMenuItem});
            this.menuStripFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStripFile.ForeColor = System.Drawing.Color.White;
            this.menuStripFile.Name = "menuStripFile";
            this.menuStripFile.Size = new System.Drawing.Size(37, 20);
            this.menuStripFile.Text = "File";
            // 
            // SaveMenuItem
            // 
            this.SaveMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.SaveMenuItem.ForeColor = System.Drawing.Color.White;
            this.SaveMenuItem.Name = "SaveMenuItem";
            this.SaveMenuItem.ShortcutKeyDisplayString = "";
            this.SaveMenuItem.Size = new System.Drawing.Size(100, 22);
            this.SaveMenuItem.Text = "Save";
            this.SaveMenuItem.Click += new System.EventHandler(this.SaveMenuItem_Click);
            // 
            // LoadMenuItem
            // 
            this.LoadMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.LoadMenuItem.ForeColor = System.Drawing.Color.White;
            this.LoadMenuItem.Name = "LoadMenuItem";
            this.LoadMenuItem.Size = new System.Drawing.Size(100, 22);
            this.LoadMenuItem.Text = "Load";
            this.LoadMenuItem.Click += new System.EventHandler(this.LoadMenuItem_Click);
            // 
            // menuStripHelp
            // 
            this.menuStripHelp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStripHelp.ForeColor = System.Drawing.Color.White;
            this.menuStripHelp.Name = "menuStripHelp";
            this.menuStripHelp.Size = new System.Drawing.Size(44, 20);
            this.menuStripHelp.Text = "Help";
            // 
            // menuStripAbout
            // 
            this.menuStripAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AryanMenuItem});
            this.menuStripAbout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStripAbout.ForeColor = System.Drawing.Color.White;
            this.menuStripAbout.Name = "menuStripAbout";
            this.menuStripAbout.Size = new System.Drawing.Size(52, 20);
            this.menuStripAbout.Text = "About";
            // 
            // AryanMenuItem
            // 
            this.AryanMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.AryanMenuItem.ForeColor = System.Drawing.Color.White;
            this.AryanMenuItem.Name = "AryanMenuItem";
            this.AryanMenuItem.Size = new System.Drawing.Size(225, 22);
            this.AryanMenuItem.Text = "Built with ❤️ by Aryan Prince";
            this.AryanMenuItem.Click += new System.EventHandler(this.AryanMenuItem_Click);
            // 
            // lblCoordinates
            // 
            this.lblCoordinates.AutoSize = true;
            this.lblCoordinates.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoordinates.ForeColor = System.Drawing.Color.White;
            this.lblCoordinates.Location = new System.Drawing.Point(476, 626);
            this.lblCoordinates.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCoordinates.Name = "lblCoordinates";
            this.lblCoordinates.Size = new System.Drawing.Size(154, 26);
            this.lblCoordinates.TabIndex = 9;
            this.lblCoordinates.Text = "X:0, Y:0 (default)";
            // 
            // lblCoordinatesInfo
            // 
            this.lblCoordinatesInfo.AutoSize = true;
            this.lblCoordinatesInfo.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoordinatesInfo.ForeColor = System.Drawing.Color.White;
            this.lblCoordinatesInfo.Location = new System.Drawing.Point(476, 598);
            this.lblCoordinatesInfo.Name = "lblCoordinatesInfo";
            this.lblCoordinatesInfo.Size = new System.Drawing.Size(186, 26);
            this.lblCoordinatesInfo.TabIndex = 10;
            this.lblCoordinatesInfo.Text = "current coordinates:";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.White;
            this.lblError.Location = new System.Drawing.Point(20, 662);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(2, 23);
            this.lblError.TabIndex = 11;
            // 
            // lblFillState
            // 
            this.lblFillState.AutoSize = true;
            this.lblFillState.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFillState.ForeColor = System.Drawing.Color.White;
            this.lblFillState.Location = new System.Drawing.Point(1172, 598);
            this.lblFillState.Name = "lblFillState";
            this.lblFillState.Size = new System.Drawing.Size(116, 26);
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
            this.lblPenColor.Size = new System.Drawing.Size(131, 26);
            this.lblPenColor.TabIndex = 13;
            this.lblPenColor.Text = "pen color: red";
            // 
            // txtCommandArea
            // 
            this.TxtCommandArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCommandArea.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCommandArea.Location = new System.Drawing.Point(7, 28);
            this.TxtCommandArea.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TxtCommandArea.Multiline = true;
            this.TxtCommandArea.Name = "TxtCommandArea";
            this.TxtCommandArea.Size = new System.Drawing.Size(431, 355);
            this.TxtCommandArea.TabIndex = 14;
            // 
            // btnRunMultiline
            // 
            this.btnRunMultiline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(54)))), ((int)(((byte)(61)))));
            this.btnRunMultiline.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRunMultiline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunMultiline.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunMultiline.ForeColor = System.Drawing.Color.White;
            this.btnRunMultiline.Location = new System.Drawing.Point(19, 455);
            this.btnRunMultiline.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRunMultiline.Name = "btnRunMultiline";
            this.btnRunMultiline.Size = new System.Drawing.Size(145, 40);
            this.btnRunMultiline.TabIndex = 15;
            this.btnRunMultiline.Text = "run multiline";
            this.btnRunMultiline.UseVisualStyleBackColor = false;
            this.btnRunMultiline.Click += new System.EventHandler(this.btnRunMultiline_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtCommandArea);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 391);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Multi-line Commands";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PictureBoxCanvas);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(481, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(816, 536);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Drawing Canvas";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TxtCommandLine);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(12, 512);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(445, 66);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Single-line Commands";
            // 
            // A
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(1339, 747);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRunMultiline);
            this.Controls.Add(this.lblPenColor);
            this.Controls.Add(this.lblFillState);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblCoordinatesInfo);
            this.Controls.Add(this.lblCoordinates);
            this.Controls.Add(this.BtnClear);
            this.Controls.Add(this.BtnRun);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MyForm";
            this.Text = "Graphical Programming Language";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxCanvas)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBoxCanvas;
        private System.Windows.Forms.TextBox TxtCommandLine;
        private System.Windows.Forms.Button BtnRun;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuStripFile;
        private System.Windows.Forms.ToolStripMenuItem menuStripHelp;
        private System.Windows.Forms.ToolStripMenuItem menuStripAbout;
        private System.Windows.Forms.Label lblCoordinates;
        private System.Windows.Forms.Label lblCoordinatesInfo;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblFillState;
        private System.Windows.Forms.Label lblPenColor;
        private System.Windows.Forms.TextBox TxtCommandArea;
        private System.Windows.Forms.Button btnRunMultiline;
        private System.Windows.Forms.ToolStripMenuItem SaveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStripMenuItem AryanMenuItem;
    }
}

