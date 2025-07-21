using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
            using System.Diagnostics;
using System.Windows.Threading;
using System.Windows;

namespace AutoKeyHelper.VisionProcess
{
    class GetPythonData
    {
        public void GetVisionLocation(System.Windows.Controls.TextBox DataChecker)
        {
            DataChecker.Text = "Process Start";
            string pythonPath = @"D:\YOLOv5\venv\Scripts\python.exe"; // 虛擬環境中的 python.exe
            string scriptPath = @"D:\YOLOv5\yolov5\GetScreenMonitor_v5.py";
            string workingDir = @"D:\YOLOv5\yolov5";

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = pythonPath,
                Arguments = $"\"{scriptPath}\"",
                WorkingDirectory = workingDir,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = false,
                CreateNoWindow = true
            };

            Process process = new Process();
            process.StartInfo = psi;

            // 接收標準輸出
            process.OutputDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        DataChecker.Text = e.Data;
                    });

                    Console.WriteLine("Python Output: " + e.Data);
                }
            };


            // 接收錯誤輸出
            process.ErrorDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        DataChecker.Text = e.Data;
                    });
                    Console.WriteLine("Python Error: " + e.Data);
                }
            };

            process.Start();
            process.BeginOutputReadLine();
            //process.BeginErrorReadLine();
        }



    }
}
