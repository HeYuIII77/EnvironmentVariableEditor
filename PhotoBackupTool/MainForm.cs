using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace PhotoBackupTool
{
    public partial class MainForm : Form
    {
        private BackgroundWorker backupWorker;
        private Dictionary<string, string[]> photoFormats;

        public MainForm()
        {
            InitializeComponent();
            InitializePhotoFormats();
            InitializeControls();
            InitializeBackgroundWorker();
        }

        private void InitializePhotoFormats()
        {
            photoFormats = new Dictionary<string, string[]>
            {
                { "JPEG", new[] { ".jpg", ".jpeg" } },
                { "Nikon RAW", new[] { ".nef", ".nrw" } },
                { "Canon RAW", new[] { ".cr2", ".cr3", ".crw" } },
                { "Sony RAW", new[] { ".arw", ".sr2", ".srf" } },
                { "Fujifilm RAW", new[] { ".raf" } },
                { "Panasonic RAW", new[] { ".rw2", ".raw" } },
                { "Olympus RAW", new[] { ".orf" } },
                { "Pentax RAW", new[] { ".pef", ".ptx" } },
                { "Sigma RAW", new[] { ".x3f" } },
                { "Adobe DNG", new[] { ".dng" } }
            };
        }

        private void InitializeControls()
        {
            //读取缓存并恢复
            txtJpegDestPath.Text = Properties.Settings.Default.JpegDestPath;
            txtRawDestPath.Text = Properties.Settings.Default.RawDestPath;

            // 初始化RAW格式复选框
            foreach (var format in photoFormats.Keys)
            {
                if (format != "JPEG")
                {
                    int idx = chkListRawFormats.Items.Add(format, true);
                    // 恢复选中项
                    if (!string.IsNullOrEmpty(Properties.Settings.Default.RawFormats))
                    {
                        var saved = Properties.Settings.Default.RawFormats.Split(';');
                        chkListRawFormats.SetItemChecked(idx, saved.Contains(format));
                    }
                }
            }

            // 初始化重复文件处理选项
            cmbDuplicateAction.Items.Add("覆盖现有文件");
            cmbDuplicateAction.Items.Add("跳过现有文件");
            cmbDuplicateAction.Items.Add("重命名新文件");
            cmbDuplicateAction.SelectedIndex =0;

            // 设置工具提示
            toolTip.SetToolTip(txtSourcePath, "选择包含照片的源文件夹");
            toolTip.SetToolTip(txtJpegDestPath, "选择JPEG格式照片的备份目标文件夹");
            toolTip.SetToolTip(txtRawDestPath, "选择RAW格式照片的备份目标文件夹");
            toolTip.SetToolTip(chkListRawFormats, "选择要备份的RAW相机格式");

            //绑定更改事件，自动保存
            txtJpegDestPath.TextChanged += (s, e) => Properties.Settings.Default.JpegDestPath = txtJpegDestPath.Text;
            txtRawDestPath.TextChanged += (s, e) => Properties.Settings.Default.RawDestPath = txtRawDestPath.Text;
            chkListRawFormats.ItemCheck += (s, e) =>
            {
                BeginInvoke(new Action(() =>
                {
                    var selected = new List<string>();
                    foreach (var item in chkListRawFormats.CheckedItems)
                        selected.Add(item.ToString());
                    Properties.Settings.Default.RawFormats = string.Join(";", selected);
                }));
            };
        }

        private void InitializeBackgroundWorker()
        {
            backupWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            backupWorker.DoWork += BackupWorker_DoWork;
            backupWorker.ProgressChanged += BackupWorker_ProgressChanged;
            backupWorker.RunWorkerCompleted += BackupWorker_RunWorkerCompleted;
        }

        private void btnSelectSource_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "选择源文件夹";
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtSourcePath.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void btnSelectJpegDest_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "选择照片备份目标文件夹";
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtJpegDestPath.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void btnSelectRawDest_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "选择RAW照片备份目标文件夹";
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtRawDestPath.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void btnStartBackup_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            btnStartBackup.Enabled = false;
            lstLog.Items.Clear();
            lstLog.Items.Add("开始备份...");

            var settings = new BackupSettings
            {
                SourcePath = txtSourcePath.Text,
                JpegDestinationPath = txtJpegDestPath.Text,
                RawDestinationPath = txtRawDestPath.Text,
                SelectedRawFormats = GetSelectedRawFormats(),
                DuplicateAction = (DuplicateAction)cmbDuplicateAction.SelectedIndex,
                PreserveFolderStructure = true // 默认保留目录结构，可后续加UI选项
            };

            backupWorker.RunWorkerAsync(settings);
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(txtSourcePath.Text))
            {
                MessageBox.Show("请选择源文件夹", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtJpegDestPath.Text))
            {
                MessageBox.Show("请选择JPEG目标文件夹", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtRawDestPath.Text))
            {
                MessageBox.Show("请选择RAW目标文件夹", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!Directory.Exists(txtSourcePath.Text))
            {
                MessageBox.Show("源文件夹不存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private List<string> GetSelectedRawFormats()
        {
            var selectedFormats = new List<string>();
            foreach (var item in chkListRawFormats.CheckedItems)
            {
                if (photoFormats.ContainsKey(item.ToString()))
                {
                    selectedFormats.AddRange(photoFormats[item.ToString()]);
                }
            }
            return selectedFormats;
        }

        private void BackupWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var settings = (BackupSettings)e.Argument;
            var worker = (BackgroundWorker)sender;

            try
            {
                var backupManager = new BackupManager(worker, settings);
                backupManager.PerformBackup();
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        private void BackupWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            lblProgress.Text = $"{e.ProgressPercentage}% - {e.UserState}";

            if (e.UserState != null)
            {
                lstLog.Items.Add(e.UserState.ToString());
                lstLog.SelectedIndex = lstLog.Items.Count - 1;
                lstLog.ClearSelected();
            }
        }

        private void BackupWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnStartBackup.Enabled = true;

            if (e.Error != null || e.Result is Exception)
            {
                var exception = e.Error ?? (Exception)e.Result;
                lstLog.Items.Add($"备份失败: {exception.Message}");
                MessageBox.Show($"备份过程中发生错误: {exception.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                lstLog.Items.Add("备份完成！");
                MessageBox.Show("备份完成！", "完成",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            progressBar.Value = 0;
            lblProgress.Text = "准备就绪";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
            base.OnFormClosing(e);
        }
    }

    public enum DuplicateAction
    {
        Overwrite,
        Skip,
        Rename
    }

    public class BackupSettings
    {
        public string SourcePath { get; set; }
        public string JpegDestinationPath { get; set; }
        public string RawDestinationPath { get; set; }
        public List<string> SelectedRawFormats { get; set; }
        public DuplicateAction DuplicateAction { get; set; }
        public bool PreserveFolderStructure { get; set; } = true; // 新增，默认保留目录结构
    }
}
