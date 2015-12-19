namespace PlasmaDebug
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmdBreak = new System.Windows.Forms.Button();
            this.cmdContinue = new System.Windows.Forms.Button();
            this.txtPID = new System.Windows.Forms.TextBox();
            this.cmdAttach = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(31, 102);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(388, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // cmdBreak
            // 
            this.cmdBreak.Location = new System.Drawing.Point(250, 141);
            this.cmdBreak.Name = "cmdBreak";
            this.cmdBreak.Size = new System.Drawing.Size(55, 26);
            this.cmdBreak.TabIndex = 3;
            this.cmdBreak.Text = "Break";
            this.cmdBreak.UseVisualStyleBackColor = true;
            this.cmdBreak.Click += new System.EventHandler(this.cmdBreak_Click);
            // 
            // cmdContinue
            // 
            this.cmdContinue.Location = new System.Drawing.Point(342, 142);
            this.cmdContinue.Name = "cmdContinue";
            this.cmdContinue.Size = new System.Drawing.Size(77, 25);
            this.cmdContinue.TabIndex = 4;
            this.cmdContinue.Text = "Continue";
            this.cmdContinue.UseVisualStyleBackColor = true;
            this.cmdContinue.Click += new System.EventHandler(this.cmdContinue_Click);
            // 
            // txtPID
            // 
            this.txtPID.Location = new System.Drawing.Point(41, 27);
            this.txtPID.Name = "txtPID";
            this.txtPID.Size = new System.Drawing.Size(104, 20);
            this.txtPID.TabIndex = 5;
            // 
            // cmdAttach
            // 
            this.cmdAttach.Location = new System.Drawing.Point(160, 27);
            this.cmdAttach.Name = "cmdAttach";
            this.cmdAttach.Size = new System.Drawing.Size(61, 19);
            this.cmdAttach.TabIndex = 6;
            this.cmdAttach.Text = "Attach";
            this.cmdAttach.UseVisualStyleBackColor = true;
            this.cmdAttach.Click += new System.EventHandler(this.cmdAttach_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 368);
            this.Controls.Add(this.cmdAttach);
            this.Controls.Add(this.txtPID);
            this.Controls.Add(this.cmdContinue);
            this.Controls.Add(this.cmdBreak);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button cmdBreak;
        private System.Windows.Forms.Button cmdContinue;
        private System.Windows.Forms.TextBox txtPID;
        private System.Windows.Forms.Button cmdAttach;
    }
}

