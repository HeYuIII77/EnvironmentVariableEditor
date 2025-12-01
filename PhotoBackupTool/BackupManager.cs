using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoBackupTool
{
    public class BackupManager
    {
        private readonly BackgroundWorker worker;
        private readonly BackupSettings settings;
        private readonly string[] jpegExtensions = { ".jpg", ".jpeg" };

        public BackupManager(BackgroundWorker worker, BackupSettings settings)
        {
            this.worker = worker;
            this.settings = settings;
        }

        public void PerformBackup()
        {
            // 创建目标目录
            Directory.CreateDirectory(settings.JpegDestinationPath);
            Directory.CreateDirectory(settings.RawDestinationPath);

            // 获取所有照片文件
            var allFiles = Directory.GetFiles(settings.SourcePath, "*.*", SearchOption.AllDirectories)
                .Where(file => IsPhotoFile(file))
                .ToArray();

            int totalFiles = allFiles.Length;
            int processedFiles = 0;

            worker.ReportProgress(0, "开始处理文件...");

            foreach (var sourceFile in allFiles)
            {
                if (worker.CancellationPending)
                    return;

                try
                {
                    ProcessFile(sourceFile, totalFiles, ref processedFiles);
                }
                catch (Exception ex)
                {
                    throw new Exception($"处理文件 {sourceFile} 时出错: {ex.Message}");
                }
            }

            worker.ReportProgress(100, "备份完成");
        }

        private bool IsPhotoFile(string filePath)
        {
            var extension = Path.GetExtension(filePath).ToLower();
            return jpegExtensions.Contains(extension) ||
                   settings.SelectedRawFormats.Contains(extension);
        }

        private void ProcessFile(string sourceFile, int totalFiles, ref int processedFiles)
        {
            var extension = Path.GetExtension(sourceFile).ToLower();
            var fileName = Path.GetFileName(sourceFile);
            string destinationPath;

            // 确定目标路径
            if (jpegExtensions.Contains(extension))
            {
                destinationPath = Path.Combine(settings.JpegDestinationPath, fileName);
            }
            else
            {
                destinationPath = Path.Combine(settings.RawDestinationPath, fileName);
            }

            // 处理重复文件
            if (File.Exists(destinationPath))
            {
                destinationPath = HandleDuplicateFile(destinationPath);
                if (destinationPath == null) // 跳过文件
                {
                    processedFiles++;
                    worker.ReportProgress(CalculateProgress(processedFiles, totalFiles),
                        $"跳过: {fileName}");
                    return;
                }
            }

            // 复制文件
            File.Copy(sourceFile, destinationPath, true);
            processedFiles++;

            worker.ReportProgress(CalculateProgress(processedFiles, totalFiles),
                $"已复制: {fileName}");
        }

        private string HandleDuplicateFile(string destinationPath)
        {
            switch (settings.DuplicateAction)
            {
                case DuplicateAction.Overwrite:
                    return destinationPath;

                case DuplicateAction.Skip:
                    return null;

                case DuplicateAction.Rename:
                    return GetUniqueFileName(destinationPath);

                default:
                    return destinationPath;
            }
        }

        private string GetUniqueFileName(string filePath)
        {
            string directory = Path.GetDirectoryName(filePath);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
            string extension = Path.GetExtension(filePath);

            int counter = 1;
            string newFilePath;

            do
            {
                newFilePath = Path.Combine(directory,
                    $"{fileNameWithoutExtension}_{counter}{extension}");
                counter++;
            } while (File.Exists(newFilePath));

            return newFilePath;
        }

        private int CalculateProgress(int processed, int total)
        {
            return total == 0 ? 0 : (int)((double)processed / total * 100);
        }
    }
}
