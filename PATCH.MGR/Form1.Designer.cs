namespace WindowsFormsApp1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PatchLbl = new System.Windows.Forms.Label();
            this.BtnLoadPatches = new System.Windows.Forms.Button();
            this.BtnCmdExit = new System.Windows.Forms.Button();
            this.grpBox1 = new System.Windows.Forms.GroupBox();
            this.CBCleanRemDir = new System.Windows.Forms.CheckBox();
            this.CBQuietMode = new System.Windows.Forms.CheckBox();
            this.RbtnNoReboot = new System.Windows.Forms.RadioButton();
            this.RbtnForceReboot = new System.Windows.Forms.RadioButton();
            this.LstNotification = new System.Windows.Forms.ListBox();
            this.BtnStartPatch = new System.Windows.Forms.Button();
            this.BtnLoadSys = new System.Windows.Forms.Button();
            this.LstPatches = new System.Windows.Forms.ListBox();
            this.BtnQueryKB = new System.Windows.Forms.Button();
            this.BtnCopyPatches = new System.Windows.Forms.Button();
            this.lblSys = new System.Windows.Forms.Label();
            this.LstLoadSystems = new System.Windows.Forms.ListBox();
            this.PbarOverallProgress = new System.Windows.Forms.ProgressBar();
            this.BtnOpenLog = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmNewInstance = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmCloseInstance = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmCloseApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TSK = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnClrLstOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnDeleteFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.TSRebootSystems = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnEnrCreds = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnNoteLog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.HELPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TOOLTip = new System.Windows.Forms.ToolTip(this.components);
            this.ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DELETE = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.grpBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.ContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // PatchLbl
            // 
            this.PatchLbl.AutoSize = true;
            this.PatchLbl.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PatchLbl.ForeColor = System.Drawing.Color.White;
            this.PatchLbl.Location = new System.Drawing.Point(0, 36);
            this.PatchLbl.Name = "PatchLbl";
            this.PatchLbl.Size = new System.Drawing.Size(88, 14);
            this.PatchLbl.TabIndex = 0;
            this.PatchLbl.Text = "PATCH LIST:";
            // 
            // BtnLoadPatches
            // 
            this.BtnLoadPatches.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.BtnLoadPatches.FlatAppearance.CheckedBackColor = System.Drawing.Color.DodgerBlue;
            this.BtnLoadPatches.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.BtnLoadPatches.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.BtnLoadPatches.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLoadPatches.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLoadPatches.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnLoadPatches.Location = new System.Drawing.Point(2, 150);
            this.BtnLoadPatches.Name = "BtnLoadPatches";
            this.BtnLoadPatches.Size = new System.Drawing.Size(320, 34);
            this.BtnLoadPatches.TabIndex = 1;
            this.BtnLoadPatches.Text = "LOAD PATCHE(S):";
            this.TOOLTip.SetToolTip(this.BtnLoadPatches, "Navigate & select a single or multiple patches to install:");
            this.BtnLoadPatches.UseVisualStyleBackColor = true;
            this.BtnLoadPatches.Click += new System.EventHandler(this.BtnLoadPatches_Click);
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
            this.BtnCmdExit.Location = new System.Drawing.Point(411, 515);
            this.BtnCmdExit.Name = "BtnCmdExit";
            this.BtnCmdExit.Size = new System.Drawing.Size(405, 30);
            this.BtnCmdExit.TabIndex = 7;
            this.BtnCmdExit.Text = "E&XIT:";
            this.TOOLTip.SetToolTip(this.BtnCmdExit, "Forces all instances to close by killing process threads:");
            this.BtnCmdExit.UseVisualStyleBackColor = true;
            this.BtnCmdExit.Click += new System.EventHandler(this.BtnCmdExit_Click);
            // 
            // grpBox1
            // 
            this.grpBox1.Controls.Add(this.CBCleanRemDir);
            this.grpBox1.Controls.Add(this.CBQuietMode);
            this.grpBox1.Controls.Add(this.RbtnNoReboot);
            this.grpBox1.Controls.Add(this.RbtnForceReboot);
            this.grpBox1.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBox1.ForeColor = System.Drawing.Color.White;
            this.grpBox1.Location = new System.Drawing.Point(653, 34);
            this.grpBox1.Name = "grpBox1";
            this.grpBox1.Size = new System.Drawing.Size(162, 150);
            this.grpBox1.TabIndex = 34;
            this.grpBox1.TabStop = false;
            this.grpBox1.Text = "OPTIONS /  MODES:";
            // 
            // CBCleanRemDir
            // 
            this.CBCleanRemDir.AutoSize = true;
            this.CBCleanRemDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBCleanRemDir.Location = new System.Drawing.Point(14, 115);
            this.CBCleanRemDir.Name = "CBCleanRemDir";
            this.CBCleanRemDir.Size = new System.Drawing.Size(101, 18);
            this.CBCleanRemDir.TabIndex = 10;
            this.CBCleanRemDir.Tag = "";
            this.CBCleanRemDir.Text = "&PURGE-KB\'s:";
            this.TOOLTip.SetToolTip(this.CBCleanRemDir, "Purge all @\"C$\\TEMP\\PATCHES\\\" files from all the loaded systems lists:");
            this.CBCleanRemDir.UseVisualStyleBackColor = true;
            this.CBCleanRemDir.CheckedChanged += new System.EventHandler(this.CBCleanRemDir_CheckedChanged);
            // 
            // CBQuietMode
            // 
            this.CBQuietMode.AutoSize = true;
            this.CBQuietMode.Checked = true;
            this.CBQuietMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBQuietMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBQuietMode.Location = new System.Drawing.Point(14, 86);
            this.CBQuietMode.Name = "CBQuietMode";
            this.CBQuietMode.Size = new System.Drawing.Size(67, 18);
            this.CBQuietMode.TabIndex = 8;
            this.CBQuietMode.Tag = "";
            this.CBQuietMode.Text = "&QUIET:";
            this.TOOLTip.SetToolTip(this.CBQuietMode, "Enable \"VERBOSE\" notifications & logging during installation process:");
            this.CBQuietMode.UseVisualStyleBackColor = true;
            this.CBQuietMode.CheckedChanged += new System.EventHandler(this.CBQuietMode_CheckedChanged);
            // 
            // RbtnNoReboot
            // 
            this.RbtnNoReboot.AutoSize = true;
            this.RbtnNoReboot.Checked = true;
            this.RbtnNoReboot.Location = new System.Drawing.Point(14, 28);
            this.RbtnNoReboot.Name = "RbtnNoReboot";
            this.RbtnNoReboot.Size = new System.Drawing.Size(103, 18);
            this.RbtnNoReboot.TabIndex = 4;
            this.RbtnNoReboot.TabStop = true;
            this.RbtnNoReboot.Text = "NO REBOOT:";
            this.RbtnNoReboot.UseVisualStyleBackColor = true;
            // 
            // RbtnForceReboot
            // 
            this.RbtnForceReboot.AutoSize = true;
            this.RbtnForceReboot.Location = new System.Drawing.Point(14, 57);
            this.RbtnForceReboot.Name = "RbtnForceReboot";
            this.RbtnForceReboot.Size = new System.Drawing.Size(126, 18);
            this.RbtnForceReboot.TabIndex = 6;
            this.RbtnForceReboot.Text = "FORCE REBOOT:";
            this.TOOLTip.SetToolTip(this.RbtnForceReboot, "Force the reboot of all remote systems after patching:");
            this.RbtnForceReboot.UseVisualStyleBackColor = true;
            this.RbtnForceReboot.CheckedChanged += new System.EventHandler(this.RbtnForceReboot_CheckedChanged);
            // 
            // LstNotification
            // 
            this.LstNotification.BackColor = System.Drawing.Color.Black;
            this.LstNotification.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.LstNotification.Font = new System.Drawing.Font("Georgia", 7.5F, System.Drawing.FontStyle.Bold);
            this.LstNotification.ForeColor = System.Drawing.Color.Lime;
            this.LstNotification.FormattingEnabled = true;
            this.LstNotification.HorizontalScrollbar = true;
            this.LstNotification.Items.AddRange(new object[] {
            "REAL TIME NOTIFICATION SUMMARY:"});
            this.LstNotification.Location = new System.Drawing.Point(2, 235);
            this.LstNotification.Name = "LstNotification";
            this.LstNotification.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LstNotification.ScrollAlwaysVisible = true;
            this.LstNotification.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LstNotification.Size = new System.Drawing.Size(814, 251);
            this.LstNotification.TabIndex = 35;
            // 
            // BtnStartPatch
            // 
            this.BtnStartPatch.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.BtnStartPatch.FlatAppearance.CheckedBackColor = System.Drawing.Color.DodgerBlue;
            this.BtnStartPatch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.BtnStartPatch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.BtnStartPatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnStartPatch.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnStartPatch.ForeColor = System.Drawing.Color.Lime;
            this.BtnStartPatch.Location = new System.Drawing.Point(548, 199);
            this.BtnStartPatch.Name = "BtnStartPatch";
            this.BtnStartPatch.Size = new System.Drawing.Size(268, 32);
            this.BtnStartPatch.TabIndex = 5;
            this.BtnStartPatch.Text = "&START INSTALL PROCESS:";
            this.TOOLTip.SetToolTip(this.BtnStartPatch, "Remotely installs the selected patches on all the loaded systems:");
            this.BtnStartPatch.UseVisualStyleBackColor = true;
            this.BtnStartPatch.Click += new System.EventHandler(this.BtnStartPatch_Click);
            // 
            // BtnLoadSys
            // 
            this.BtnLoadSys.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.BtnLoadSys.FlatAppearance.CheckedBackColor = System.Drawing.Color.DodgerBlue;
            this.BtnLoadSys.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.BtnLoadSys.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.BtnLoadSys.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLoadSys.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLoadSys.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnLoadSys.Location = new System.Drawing.Point(327, 150);
            this.BtnLoadSys.Name = "BtnLoadSys";
            this.BtnLoadSys.Size = new System.Drawing.Size(320, 34);
            this.BtnLoadSys.TabIndex = 2;
            this.BtnLoadSys.Text = "LOAD SYSTEM(S):";
            this.TOOLTip.SetToolTip(this.BtnLoadSys, "Navigate & select the  [.txt/.jeb] file containing the desired list of remote sys" +
        "tems:");
            this.BtnLoadSys.UseVisualStyleBackColor = true;
            this.BtnLoadSys.Click += new System.EventHandler(this.BtnLoadSys_Click);
            // 
            // LstPatches
            // 
            this.LstPatches.BackColor = System.Drawing.Color.Black;
            this.LstPatches.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LstPatches.Font = new System.Drawing.Font("Georgia", 7.2F, System.Drawing.FontStyle.Bold);
            this.LstPatches.ForeColor = System.Drawing.Color.White;
            this.LstPatches.FormattingEnabled = true;
            this.LstPatches.HorizontalScrollbar = true;
            this.LstPatches.Location = new System.Drawing.Point(2, 52);
            this.LstPatches.Name = "LstPatches";
            this.LstPatches.ScrollAlwaysVisible = true;
            this.LstPatches.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LstPatches.Size = new System.Drawing.Size(320, 95);
            this.LstPatches.TabIndex = 43;
            this.LstPatches.SelectedIndexChanged += new System.EventHandler(this.LstPatches_SelectedIndexChanged);
            // 
            // BtnQueryKB
            // 
            this.BtnQueryKB.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.BtnQueryKB.FlatAppearance.CheckedBackColor = System.Drawing.Color.DodgerBlue;
            this.BtnQueryKB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.BtnQueryKB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.BtnQueryKB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnQueryKB.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQueryKB.ForeColor = System.Drawing.Color.White;
            this.BtnQueryKB.Location = new System.Drawing.Point(3, 199);
            this.BtnQueryKB.Name = "BtnQueryKB";
            this.BtnQueryKB.Size = new System.Drawing.Size(267, 32);
            this.BtnQueryKB.TabIndex = 3;
            this.BtnQueryKB.Text = "&QUERY KB\'s:";
            this.TOOLTip.SetToolTip(this.BtnQueryKB, "Will return all the KB\'s installed on the loaded systems lists or the KB loaded i" +
        "nto the Patch List:");
            this.BtnQueryKB.UseVisualStyleBackColor = true;
            this.BtnQueryKB.Click += new System.EventHandler(this.BtnQueryKB_Click);
            // 
            // BtnCopyPatches
            // 
            this.BtnCopyPatches.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.BtnCopyPatches.FlatAppearance.CheckedBackColor = System.Drawing.Color.DodgerBlue;
            this.BtnCopyPatches.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.BtnCopyPatches.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.BtnCopyPatches.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCopyPatches.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCopyPatches.ForeColor = System.Drawing.Color.White;
            this.BtnCopyPatches.Location = new System.Drawing.Point(275, 199);
            this.BtnCopyPatches.Name = "BtnCopyPatches";
            this.BtnCopyPatches.Size = new System.Drawing.Size(268, 32);
            this.BtnCopyPatches.TabIndex = 4;
            this.BtnCopyPatches.Text = " &MIGRATE PATCHE(S):";
            this.TOOLTip.SetToolTip(this.BtnCopyPatches, "Migrates all the selected patches onto all the loaded systems:");
            this.BtnCopyPatches.UseVisualStyleBackColor = true;
            this.BtnCopyPatches.Click += new System.EventHandler(this.BtnCopyPatches_Click);
            // 
            // lblSys
            // 
            this.lblSys.AutoSize = true;
            this.lblSys.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSys.ForeColor = System.Drawing.Color.White;
            this.lblSys.Location = new System.Drawing.Point(325, 36);
            this.lblSys.Name = "lblSys";
            this.lblSys.Size = new System.Drawing.Size(101, 14);
            this.lblSys.TabIndex = 38;
            this.lblSys.Text = "SYSTEMS LIST:";
            // 
            // LstLoadSystems
            // 
            this.LstLoadSystems.BackColor = System.Drawing.Color.Black;
            this.LstLoadSystems.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LstLoadSystems.Font = new System.Drawing.Font("Georgia", 7.2F, System.Drawing.FontStyle.Bold);
            this.LstLoadSystems.ForeColor = System.Drawing.Color.White;
            this.LstLoadSystems.FormattingEnabled = true;
            this.LstLoadSystems.HorizontalScrollbar = true;
            this.LstLoadSystems.Location = new System.Drawing.Point(327, 52);
            this.LstLoadSystems.Name = "LstLoadSystems";
            this.LstLoadSystems.ScrollAlwaysVisible = true;
            this.LstLoadSystems.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LstLoadSystems.Size = new System.Drawing.Size(320, 95);
            this.LstLoadSystems.TabIndex = 44;
            this.LstLoadSystems.SelectedIndexChanged += new System.EventHandler(this.LstLoadSystems_SelectedIndexChanged);
            // 
            // PbarOverallProgress
            // 
            this.PbarOverallProgress.BackColor = System.Drawing.Color.Lime;
            this.PbarOverallProgress.ForeColor = System.Drawing.Color.Lime;
            this.PbarOverallProgress.Location = new System.Drawing.Point(2, 489);
            this.PbarOverallProgress.Name = "PbarOverallProgress";
            this.PbarOverallProgress.Size = new System.Drawing.Size(814, 23);
            this.PbarOverallProgress.TabIndex = 49;
            this.PbarOverallProgress.Click += new System.EventHandler(this.PbarOverallProgress_Click);
            // 
            // BtnOpenLog
            // 
            this.BtnOpenLog.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.BtnOpenLog.FlatAppearance.CheckedBackColor = System.Drawing.Color.DodgerBlue;
            this.BtnOpenLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.BtnOpenLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.BtnOpenLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOpenLog.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOpenLog.ForeColor = System.Drawing.Color.White;
            this.BtnOpenLog.Location = new System.Drawing.Point(2, 515);
            this.BtnOpenLog.Name = "BtnOpenLog";
            this.BtnOpenLog.Size = new System.Drawing.Size(405, 30);
            this.BtnOpenLog.TabIndex = 6;
            this.BtnOpenLog.Text = "OPEN LOG:";
            this.TOOLTip.SetToolTip(this.BtnOpenLog, "Opens log @(C:\\0_SCRIPTS\\PATCH.MGR\\PATCH.MGR.LOG.jeb)");
            this.BtnOpenLog.UseVisualStyleBackColor = true;
            this.BtnOpenLog.Click += new System.EventHandler(this.BtnOpenLog_Click);
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.ForeColor = System.Drawing.Color.SpringGreen;
            this.label1.Location = new System.Drawing.Point(-1, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(821, 10);
            this.label1.TabIndex = 51;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.DimGray;
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmNewInstance,
            this.TsmCloseInstance,
            this.TsmCloseApplication});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.Black;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(52, 20);
            this.toolStripMenuItem1.Text = "&FILE:";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // TsmNewInstance
            // 
            this.TsmNewInstance.BackColor = System.Drawing.Color.Lime;
            this.TsmNewInstance.Name = "TsmNewInstance";
            this.TsmNewInstance.Size = new System.Drawing.Size(253, 22);
            this.TsmNewInstance.Text = "&NEW INSTANCE:";
            this.TsmNewInstance.Click += new System.EventHandler(this.TsmNewInstance_Click);
            // 
            // TsmCloseInstance
            // 
            this.TsmCloseInstance.BackColor = System.Drawing.Color.LightGray;
            this.TsmCloseInstance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TsmCloseInstance.Name = "TsmCloseInstance";
            this.TsmCloseInstance.Size = new System.Drawing.Size(253, 22);
            this.TsmCloseInstance.Text = "&CLOSE CURRENT INSTANCE:";
            this.TsmCloseInstance.Click += new System.EventHandler(this.TsmCloseInstance_Click);
            // 
            // TsmCloseApplication
            // 
            this.TsmCloseApplication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.TsmCloseApplication.ForeColor = System.Drawing.Color.Black;
            this.TsmCloseApplication.Name = "TsmCloseApplication";
            this.TsmCloseApplication.Size = new System.Drawing.Size(253, 22);
            this.TsmCloseApplication.Text = "CLOSE &ALL INSTANCES:";
            this.TsmCloseApplication.Click += new System.EventHandler(this.TsmCloseApplication_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DimGray;
            this.menuStrip1.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.TSK,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(820, 24);
            this.menuStrip1.TabIndex = 52;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // TSK
            // 
            this.TSK.BackColor = System.Drawing.Color.DimGray;
            this.TSK.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnClrLstOptions,
            this.BtnDeleteFiles,
            this.TSRebootSystems,
            this.BtnEnrCreds,
            this.BtnNoteLog});
            this.TSK.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSK.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TSK.Name = "TSK";
            this.TSK.Size = new System.Drawing.Size(65, 20);
            this.TSK.Text = "&TASKS:";
            // 
            // BtnClrLstOptions
            // 
            this.BtnClrLstOptions.BackColor = System.Drawing.Color.LightGray;
            this.BtnClrLstOptions.Name = "BtnClrLstOptions";
            this.BtnClrLstOptions.Size = new System.Drawing.Size(180, 22);
            this.BtnClrLstOptions.Text = "&CLEAR-LISTS:";
            this.BtnClrLstOptions.Click += new System.EventHandler(this.BtnClrLstOptions_Click);
            // 
            // BtnDeleteFiles
            // 
            this.BtnDeleteFiles.AutoSize = false;
            this.BtnDeleteFiles.BackColor = System.Drawing.Color.LightGray;
            this.BtnDeleteFiles.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDeleteFiles.ForeColor = System.Drawing.Color.Black;
            this.BtnDeleteFiles.Name = "BtnDeleteFiles";
            this.BtnDeleteFiles.Size = new System.Drawing.Size(180, 22);
            this.BtnDeleteFiles.Text = "&PURGE-KB\'s:";
            this.BtnDeleteFiles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDeleteFiles.ToolTipText = "Purge all the patch files found within the Remote Systems \"C$\\TEMP\\PATCHES\\\" dire" +
    "ctory:";
            this.BtnDeleteFiles.Click += new System.EventHandler(this.BtnDeleteFiles_Click);
            // 
            // TSRebootSystems
            // 
            this.TSRebootSystems.AutoSize = false;
            this.TSRebootSystems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.TSRebootSystems.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSRebootSystems.ForeColor = System.Drawing.Color.Black;
            this.TSRebootSystems.Name = "TSRebootSystems";
            this.TSRebootSystems.Size = new System.Drawing.Size(180, 22);
            this.TSRebootSystems.Text = "&REBOOT-SYS\'s:";
            this.TSRebootSystems.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TSRebootSystems.ToolTipText = "Reboot all systems loaded into \"SYSTEMS LIST\":";
            this.TSRebootSystems.Click += new System.EventHandler(this.TSRebootSystems_Click);
            // 
            // BtnEnrCreds
            // 
            this.BtnEnrCreds.BackColor = System.Drawing.Color.LightGray;
            this.BtnEnrCreds.Name = "BtnEnrCreds";
            this.BtnEnrCreds.Size = new System.Drawing.Size(180, 22);
            this.BtnEnrCreds.Text = "&ENTER-CREDS:";
            this.BtnEnrCreds.Click += new System.EventHandler(this.BtnEnrCreds_Click);
            // 
            // BtnNoteLog
            // 
            this.BtnNoteLog.BackColor = System.Drawing.Color.LightGray;
            this.BtnNoteLog.Name = "BtnNoteLog";
            this.BtnNoteLog.Size = new System.Drawing.Size(180, 22);
            this.BtnNoteLog.Text = "&OPEN-LOG:";
            this.BtnNoteLog.Click += new System.EventHandler(this.BtnNoteLog_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HELPToolStripMenuItem});
            this.toolStripMenuItem2.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItem2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(25, 20);
            this.toolStripMenuItem2.Text = "?";
            // 
            // HELPToolStripMenuItem
            // 
            this.HELPToolStripMenuItem.BackColor = System.Drawing.Color.LightGray;
            this.HELPToolStripMenuItem.Name = "HELPToolStripMenuItem";
            this.HELPToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.HELPToolStripMenuItem.Text = "&HELP:";
            this.HELPToolStripMenuItem.Click += new System.EventHandler(this.HELPToolStripMenuItem_Click);
            // 
            // TOOLTip
            // 
            this.TOOLTip.IsBalloon = true;
            this.TOOLTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TOOLTip.Popup += new System.Windows.Forms.PopupEventHandler(this.ToolTip1_Popup);
            // 
            // ContextMenu
            // 
            this.ContextMenu.BackColor = System.Drawing.Color.Black;
            this.ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DELETE});
            this.ContextMenu.Name = "ContextMenu";
            this.ContextMenu.Size = new System.Drawing.Size(116, 26);
            this.ContextMenu.Text = "DELETE";
            // 
            // DELETE
            // 
            this.DELETE.BackColor = System.Drawing.Color.Black;
            this.DELETE.ForeColor = System.Drawing.Color.Lime;
            this.DELETE.Name = "DELETE";
            this.DELETE.Size = new System.Drawing.Size(115, 22);
            this.DELETE.Text = "DELETE:";
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.ForeColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(0, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(817, 10);
            this.label2.TabIndex = 53;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(820, 549);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnOpenLog);
            this.Controls.Add(this.BtnCopyPatches);
            this.Controls.Add(this.BtnQueryKB);
            this.Controls.Add(this.LstLoadSystems);
            this.Controls.Add(this.LstPatches);
            this.Controls.Add(this.lblSys);
            this.Controls.Add(this.BtnLoadSys);
            this.Controls.Add(this.BtnStartPatch);
            this.Controls.Add(this.LstNotification);
            this.Controls.Add(this.grpBox1);
            this.Controls.Add(this.BtnCmdExit);
            this.Controls.Add(this.BtnLoadPatches);
            this.Controls.Add(this.PatchLbl);
            this.Controls.Add(this.PbarOverallProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PATCH MGR v2.5";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpBox1.ResumeLayout(false);
            this.grpBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PatchLbl;
        internal System.Windows.Forms.Button BtnLoadPatches;
        internal System.Windows.Forms.Button BtnCmdExit;
        private System.Windows.Forms.GroupBox grpBox1;
        private System.Windows.Forms.RadioButton RbtnNoReboot;
        private System.Windows.Forms.RadioButton RbtnForceReboot;
        private System.Windows.Forms.ListBox LstNotification;
        internal System.Windows.Forms.Button BtnStartPatch;
        internal System.Windows.Forms.Button BtnLoadSys;
        private System.Windows.Forms.ListBox LstPatches;
        internal System.Windows.Forms.Button BtnQueryKB;
        private System.Windows.Forms.CheckBox CBQuietMode;
        internal System.Windows.Forms.Button BtnCopyPatches;
        private System.Windows.Forms.Label lblSys;
        private System.Windows.Forms.ListBox LstLoadSystems;
        private System.Windows.Forms.ProgressBar PbarOverallProgress;
        internal System.Windows.Forms.Button BtnOpenLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem TsmNewInstance;
        private System.Windows.Forms.ToolStripMenuItem TsmCloseInstance;
        private System.Windows.Forms.ToolStripMenuItem TsmCloseApplication;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolTip TOOLTip;
        private new System.Windows.Forms.ContextMenuStrip ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem DELETE;
        private System.Windows.Forms.ToolStripMenuItem TSK;
        private System.Windows.Forms.ToolStripMenuItem BtnDeleteFiles;
        private System.Windows.Forms.CheckBox CBCleanRemDir;
        private System.Windows.Forms.ToolStripMenuItem BtnClrLstOptions;
        private System.Windows.Forms.ToolStripMenuItem BtnNoteLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem HELPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BtnEnrCreds;
        private System.Windows.Forms.ToolStripMenuItem TSRebootSystems;
    }
}

