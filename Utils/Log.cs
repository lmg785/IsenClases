using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace IsenClases.Utils
{
    public sealed class Log
    {
        private static readonly string logFile = "log.txt";
        private static Log _instance = null;
        private static readonly object _lock = new object();

        private Log()
        {
            lock (_lock)
            {
                if (!File.Exists(logFile))
                    File.Create(logFile);
            }
        }

        public static Log Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Log();
                }

                return _instance;
            }
        }

        public void WriteLog(String info)
        {
            lock (_lock)
            {
                try
                {
                    File.AppendAllText(logFile, "[" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "] " + info + System.Environment.NewLine);
                }
                catch (Exception e) 
                {
                    Console.WriteLine("Ha habido un error: " + e.Message);
                }
            }
        }
    }

}