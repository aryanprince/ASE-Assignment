namespace ASE_Assignment
{
    partial class formAssignment
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picboxCanvas = new System.Windows.Forms.PictureBox();
            this.txtboxCodeArea = new System.Windows.Forms.RichTextBox();
            this.txtboxCommandLine = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picboxCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // picboxCanvas
            // 
            this.picboxCanvas.Location = new System.Drawing.Point(427, 12);
            this.picboxCanvas.Name = "picboxCanvas";
            this.picboxCanvas.Size = new System.Drawing.Size(361, 426);
            this.picboxCanvas.TabIndex = 0;
            this.picboxCanvas.TabStop = false;
            this.picboxCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // txtboxCodeArea
            // 
            this.txtboxCodeArea.Location = new System.Drawing.Point(12, 12);
            this.txtboxCodeArea.Name = "txtboxCodeArea";
            this.txtboxCodeArea.Size = new System.Drawing.Size(394, 271);
            this.txtboxCodeArea.TabIndex = 1;
            this.txtboxCodeArea.Text = "";
            // 
            // txtboxCommandLine
            // 
            this.txtboxCommandLine.Location = new System.Drawing.Point(12, 314);
            this.txtboxCommandLine.Name = "txtboxCommandLine";
            this.txtboxCommandLine.Size = new System.Drawing.Size(394, 23);
            this.txtboxCommandLine.TabIndex = 0;
            this.txtboxCommandLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 343);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(93, 343);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // formAssignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtboxCommandLine);
            this.Controls.Add(this.txtboxCodeArea);
            this.Controls.Add(this.picboxCanvas);
            this.KeyPreview = true;
            this.Name = "formAssignment";
            this.Text = "ASE Assignment";
            ((System.ComponentModel.ISupportInitialize)(this.picboxCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox picboxCanvas;
        private RichTextBox txtboxCodeArea;
        private TextBox txtboxCommandLine;
        private Button btnRun;
        private Button btnClear;
    }
}