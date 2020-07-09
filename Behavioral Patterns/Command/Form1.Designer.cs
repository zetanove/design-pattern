namespace CommandPattern
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
            this.btCut = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btUndo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btCut
            // 
            this.btCut.Location = new System.Drawing.Point(93, 3);
            this.btCut.Name = "btCut";
            this.btCut.Size = new System.Drawing.Size(75, 23);
            this.btCut.TabIndex = 0;
            this.btCut.Text = "Taglia";
            this.btCut.UseVisualStyleBackColor = true;
            this.btCut.Click += new System.EventHandler(this.btCut_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 69);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(776, 202);
            this.textBox1.TabIndex = 1;
            // 
            // btUndo
            // 
            this.btUndo.Location = new System.Drawing.Point(12, 3);
            this.btUndo.Name = "btUndo";
            this.btUndo.Size = new System.Drawing.Size(75, 23);
            this.btUndo.TabIndex = 2;
            this.btUndo.Text = "Undo";
            this.btUndo.UseVisualStyleBackColor = true;
            this.btUndo.Click += new System.EventHandler(this.btUndo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btUndo);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btCut);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btCut;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btUndo;
    }
}

