using System;
using System.IO;

namespace 移动家客WinApp.Comm
{
    public class Loger
    {
        public static void WriteLog(string msg, string fileName = "InfoData")
        {
            if (fileName != "Error")
            {
                return;
            }
            string filePath = AppDomain.CurrentDomain.BaseDirectory + $"Log\\{fileName}";
            if (!System.IO.Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            string logPath = AppDomain.CurrentDomain.BaseDirectory + $"Log\\{fileName}\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            try
            {
                using (StreamWriter sw = File.AppendText(logPath))
                {
                    sw.WriteLine("时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    sw.WriteLine("消息：" + msg);
                    sw.WriteLine();
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }
            catch (IOException e)
            {
                using (StreamWriter sw = File.AppendText(logPath))
                {
                    sw.WriteLine("时间：" + DateTime.Now.ToString("yyy-MM-dd HH:mm:ss"));
                    sw.WriteLine("异常：" + e.Message + "\r\n" + e.StackTrace);
                    sw.WriteLine();
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }
        }
    }
}