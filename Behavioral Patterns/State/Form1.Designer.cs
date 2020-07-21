namespace State
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
            this.btChange = new System.Windows.Forms.Button();
            this.btMode = new System.Windows.Forms.Button();
            this.txtState = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOre = new System.Windows.Forms.TextBox();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btChange
            // 
            this.btChange.Location = new System.Drawing.Point(110, 132);
            this.btChange.Name = "btChange";
            this.btChange.Size = new System.Drawing.Size(75, 23);
            this.btChange.TabIndex = 0;
            this.btChange.Text = "Change";
            this.btChange.UseVisualStyleBackColor = true;
            this.btChange.Click += new System.EventHandler(this.btChange_Click);
            // 
            // btMode
            // 
            this.btMode.Location = new System.Drawing.Point(191, 132);
            this.btMode.Name = "btMode";
            this.btMode.Size = new System.Drawing.Size(75, 23);
            this.btMode.TabIndex = 1;
            this.btMode.Text = "Mode";
            this.btMode.UseVisualStyleBackColor = true;
            this.btMode.Click += new System.EventHandler(this.btMode_Click);
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(110, 44);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(156, 20);
            this.txtState.TabIndex = 5;
            this.txtState.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "stato";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtOre
            // 
            this.txtOre.Location = new System.Drawing.Point(110, 78);
            this.txtOre.Name = "txtOre";
            this.txtOre.Size = new System.Drawing.Size(47, 20);
            this.txtOre.TabIndex = 7;
            this.txtOre.Text = "00";
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(203, 78);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(63, 20);
            this.txtMin.TabIndex = 8;
            this.txtMin.Text = "00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "ore";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "minuti";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.txtOre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.btMode);
            this.Controls.Add(this.btChange);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btChange;
        private System.Windows.Forms.Button btMode;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOre;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

