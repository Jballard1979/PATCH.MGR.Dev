namespace PATCH.MGR
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.HelpRichTB = new System.Windows.Forms.RichTextBox();
            this.BtnCmdExit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.HelpRichTB);
            this.groupBox1.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Lime;
            this.groupBox1.Location = new System.Drawing.Point(2, 1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(1002, 489);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[HELP]";
            // 
            // HelpRichTB
            // 
            this.HelpRichTB.BackColor = System.Drawing.Color.DimGray;
            this.HelpRichTB.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpRichTB.ForeColor = System.Drawing.Color.Snow;
            this.HelpRichTB.Location = new System.Drawing.Point(6, 20);
            this.HelpRichTB.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.HelpRichTB.Name = "HelpRichTB";
            this.HelpRichTB.Size = new System.Drawing.Size(992, 462);
            this.HelpRichTB.TabIndex = 1;
            this.HelpRichTB.Text = resources.GetString("HelpRichTB.Text");
            this.HelpRichTB.TextChanged += new System.EventHandler(this.HelpRichTB_TextChanged);
            // 
            // BtnCmdExit
            // 
            this.BtnCmdExit.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.BtnCmdExit.FlatAppearance.CheckedBackColor = System.Drawing.Color.DodgerBlue;
            this.BtnCmdExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.BtnCmdExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.BtnCmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCmdExit.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCmdExit.ForeColor = System.Drawing.Color.White;
            this.BtnCmdExit.Location = new System.Drawing.Point(2, 493);
            this.BtnCmdExit.Name = "BtnCmdExit";
            this.BtnCmdExit.Size = new System.Drawing.Size(1002, 30);
            this.BtnCmdExit.TabIndex = 15;
            this.BtnCmdExit.Text = "E&XIT:";
            this.BtnCmdExit.UseVisualStyleBackColor = true;
            this.BtnCmdExit.Click += new System.EventHandler(this.BtnCmdExit_Click);
            // 
            // Form2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1008, 527);
            this.ControlBox = false;
            this.Controls.Add(this.BtnCmdExit);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.Aqua;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PATCH MGR HELP v2.5";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox HelpRichTB;
        internal System.Windows.Forms.Button BtnCmdExit;
    }
}