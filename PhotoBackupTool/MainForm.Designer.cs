using System.Drawing;
using System.Windows.Forms;

namespace PhotoBackupTool
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
            this.components = new System.ComponentModel.Container();
            this.btnSelectSource = new System.Windows.Forms.Button();
            this.btnSelectJpegDest = new System.Windows.Forms.Button();
            this.btnSelectRawDest = new System.Windows.Forms.Button();
            this.btnStartBackup = new System.Windows.Forms.Button();
            this.txtSourcePath = new System.Windows.Forms.TextBox();
            this.txtJpegDestPath = new System.Windows.Forms.TextBox();
            this.txtRawDestPath = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblSource = new System.Windows.Forms.Label();
            this.lblJpegDest = new System.Windows.Forms.Label();
            this.lblRawDest = new System.Windows.Forms.Label();
            this.cmbDuplicateAction = new System.Windows.Forms.ComboBox();
            this.lblDuplicateAction = new System.Windows.Forms.Label();
            this.chkListRawFormats = new System.Windows.Forms.CheckedListBox();
            this.lblRawFormats = new System.Windows.Forms.Label();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnSelectSource
            // 
            this.btnSelectSource.Font = new System.Drawing.Font("宋体", 12F);
            this.btnSelectSource.Location = new System.Drawing.Point(533, 14);
            this.btnSelectSource.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectSource.Name = "btnSelectSource";
            this.btnSelectSource.Size = new System.Drawing.Size(102, 28);
            this.btnSelectSource.TabIndex = 2;
            this.btnSelectSource.Text = "浏览";
            this.btnSelectSource.UseVisualStyleBackColor = true;
            this.btnSelectSource.Click += new System.EventHandler(this.btnSelectSource_Click);
            // 
            // btnSelectJpegDest
            // 
            this.btnSelectJpegDest.Font = new System.Drawing.Font("宋体", 12F);
            this.btnSelectJpegDest.Location = new System.Drawing.Point(533, 56);
            this.btnSelectJpegDest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectJpegDest.Name = "btnSelectJpegDest";
            this.btnSelectJpegDest.Size = new System.Drawing.Size(102, 26);
            this.btnSelectJpegDest.TabIndex = 4;
            this.btnSelectJpegDest.Text = "浏览";
            this.btnSelectJpegDest.UseVisualStyleBackColor = true;
            this.btnSelectJpegDest.Click += new System.EventHandler(this.btnSelectJpegDest_Click);
            // 
            // btnSelectRawDest
            // 
            this.btnSelectRawDest.Font = new System.Drawing.Font("宋体", 12F);
            this.btnSelectRawDest.Location = new System.Drawing.Point(533, 102);
            this.btnSelectRawDest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectRawDest.Name = "btnSelectRawDest";
            this.btnSelectRawDest.Size = new System.Drawing.Size(102, 27);
            this.btnSelectRawDest.TabIndex = 6;
            this.btnSelectRawDest.Text = "浏览";
            this.btnSelectRawDest.UseVisualStyleBackColor = true;
            this.btnSelectRawDest.Click += new System.EventHandler(this.btnSelectRawDest_Click);
            // 
            // btnStartBackup
            // 
            this.btnStartBackup.Font = new System.Drawing.Font("宋体", 12F);
            this.btnStartBackup.Location = new System.Drawing.Point(533, 146);
            this.btnStartBackup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStartBackup.Name = "btnStartBackup";
            this.btnStartBackup.Size = new System.Drawing.Size(102, 50);
            this.btnStartBackup.TabIndex = 9;
            this.btnStartBackup.Text = "开始备份";
            this.btnStartBackup.UseVisualStyleBackColor = true;
            this.btnStartBackup.Click += new System.EventHandler(this.btnStartBackup_Click);
            // 
            // txtSourcePath
            // 
            this.txtSourcePath.Font = new System.Drawing.Font("宋体", 12F);
            this.txtSourcePath.Location = new System.Drawing.Point(101, 14);
            this.txtSourcePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSourcePath.Name = "txtSourcePath";
            this.txtSourcePath.ReadOnly = true;
            this.txtSourcePath.Size = new System.Drawing.Size(415, 26);
            this.txtSourcePath.TabIndex = 1;
            // 
            // txtJpegDestPath
            // 
            this.txtJpegDestPath.Font = new System.Drawing.Font("宋体", 12F);
            this.txtJpegDestPath.Location = new System.Drawing.Point(101, 58);
            this.txtJpegDestPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtJpegDestPath.Name = "txtJpegDestPath";
            this.txtJpegDestPath.ReadOnly = true;
            this.txtJpegDestPath.Size = new System.Drawing.Size(415, 26);
            this.txtJpegDestPath.TabIndex = 3;
            // 
            // txtRawDestPath
            // 
            this.txtRawDestPath.Font = new System.Drawing.Font("宋体", 12F);
            this.txtRawDestPath.Location = new System.Drawing.Point(101, 103);
            this.txtRawDestPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRawDestPath.Name = "txtRawDestPath";
            this.txtRawDestPath.ReadOnly = true;
            this.txtRawDestPath.Size = new System.Drawing.Size(415, 26);
            this.txtRawDestPath.TabIndex = 5;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(277, 213);
            this.progressBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(358, 18);
            this.progressBar.TabIndex = 10;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("宋体", 12F);
            this.lblProgress.Location = new System.Drawing.Point(274, 233);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(71, 16);
            this.lblProgress.TabIndex = 12;
            this.lblProgress.Text = "准备就绪";
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSource.Location = new System.Drawing.Point(17, 17);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(87, 16);
            this.lblSource.TabIndex = 17;
            this.lblSource.Text = "源文件夹：";
            // 
            // lblJpegDest
            // 
            this.lblJpegDest.AutoSize = true;
            this.lblJpegDest.Font = new System.Drawing.Font("宋体", 12F);
            this.lblJpegDest.Location = new System.Drawing.Point(17, 61);
            this.lblJpegDest.Name = "lblJpegDest";
            this.lblJpegDest.Size = new System.Drawing.Size(87, 16);
            this.lblJpegDest.TabIndex = 16;
            this.lblJpegDest.Text = "照片目标：";
            // 
            // lblRawDest
            // 
            this.lblRawDest.AutoSize = true;
            this.lblRawDest.Font = new System.Drawing.Font("宋体", 12F);
            this.lblRawDest.Location = new System.Drawing.Point(17, 106);
            this.lblRawDest.Name = "lblRawDest";
            this.lblRawDest.Size = new System.Drawing.Size(79, 16);
            this.lblRawDest.TabIndex = 15;
            this.lblRawDest.Text = "RAW目标：";
            // 
            // cmbDuplicateAction
            // 
            this.cmbDuplicateAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDuplicateAction.Font = new System.Drawing.Font("宋体", 12F);
            this.cmbDuplicateAction.FormattingEnabled = true;
            this.cmbDuplicateAction.Location = new System.Drawing.Point(277, 172);
            this.cmbDuplicateAction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbDuplicateAction.Name = "cmbDuplicateAction";
            this.cmbDuplicateAction.Size = new System.Drawing.Size(239, 24);
            this.cmbDuplicateAction.TabIndex = 8;
            // 
            // lblDuplicateAction
            // 
            this.lblDuplicateAction.AutoSize = true;
            this.lblDuplicateAction.Font = new System.Drawing.Font("宋体", 12F);
            this.lblDuplicateAction.Location = new System.Drawing.Point(274, 146);
            this.lblDuplicateAction.Name = "lblDuplicateAction";
            this.lblDuplicateAction.Size = new System.Drawing.Size(151, 16);
            this.lblDuplicateAction.TabIndex = 13;
            this.lblDuplicateAction.Text = "重复文件处理方式：";
            // 
            // chkListRawFormats
            // 
            this.chkListRawFormats.Font = new System.Drawing.Font("宋体", 12F);
            this.chkListRawFormats.FormattingEnabled = true;
            this.chkListRawFormats.Location = new System.Drawing.Point(20, 172);
            this.chkListRawFormats.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkListRawFormats.Name = "chkListRawFormats";
            this.chkListRawFormats.Size = new System.Drawing.Size(231, 214);
            this.chkListRawFormats.TabIndex = 7;
            // 
            // lblRawFormats
            // 
            this.lblRawFormats.AutoSize = true;
            this.lblRawFormats.Font = new System.Drawing.Font("宋体", 12F);
            this.lblRawFormats.Location = new System.Drawing.Point(17, 146);
            this.lblRawFormats.Name = "lblRawFormats";
            this.lblRawFormats.Size = new System.Drawing.Size(79, 16);
            this.lblRawFormats.TabIndex = 14;
            this.lblRawFormats.Text = "RAW格式：";
            // 
            // lstLog
            // 
            this.lstLog.Font = new System.Drawing.Font("宋体", 12F);
            this.lstLog.FormattingEnabled = true;
            this.lstLog.ItemHeight = 16;
            this.lstLog.Location = new System.Drawing.Point(277, 254);
            this.lstLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(358, 132);
            this.lstLog.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 412);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnStartBackup);
            this.Controls.Add(this.cmbDuplicateAction);
            this.Controls.Add(this.lblDuplicateAction);
            this.Controls.Add(this.chkListRawFormats);
            this.Controls.Add(this.lblRawFormats);
            this.Controls.Add(this.btnSelectRawDest);
            this.Controls.Add(this.txtRawDestPath);
            this.Controls.Add(this.lblRawDest);
            this.Controls.Add(this.btnSelectJpegDest);
            this.Controls.Add(this.txtJpegDestPath);
            this.Controls.Add(this.lblJpegDest);
            this.Controls.Add(this.btnSelectSource);
            this.Controls.Add(this.txtSourcePath);
            this.Controls.Add(this.lblSource);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "照片备份工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button btnSelectSource;
        private Button btnSelectJpegDest;
        private Button btnSelectRawDest;
        private Button btnStartBackup;
        private TextBox txtSourcePath;
        private TextBox txtJpegDestPath;
        private TextBox txtRawDestPath;
        private ProgressBar progressBar;
        private Label lblProgress;
        private Label lblSource;
        private Label lblJpegDest;
        private Label lblRawDest;
        private ComboBox cmbDuplicateAction;
        private Label lblDuplicateAction;
        private CheckedListBox chkListRawFormats;
        private Label lblRawFormats;
        private ListBox lstLog;
        private ToolTip toolTip;
    }
}