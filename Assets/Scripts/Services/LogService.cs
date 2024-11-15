using System;
using System.Collections.Concurrent;
using System.IO;
using System.Text;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;
using Application = UnityEngine.Device.Application;
using ThreadPriority = System.Threading.ThreadPriority;

namespace Core.Core.Services
{
    public class LogService : IDisposable, ITickable
    {
        public const string LogFileName = "Log";
        public const string LogsDirectoryName = "Logs";
        private const string LogTimeFormat = "{0:dd/MM/yyyy HH:mm:ss:ffff} [{1}]: {2}\r";

        private readonly string FullFilePath;
        private object lockerObject = new object();
        
        private readonly Thread _logSaveThread;
        private readonly ConcurrentQueue<string> _logsQueue = new ConcurrentQueue<string>();
        private bool _threadIsActive;

        public LogService()
        {
            Application.logMessageReceived += OnLogReceived;

            FullFilePath = Path.Combine(GetDirectoryPath(), $"{LogFileName}_{DateTime.UtcNow:yyyy-MM-dd}.log");
            
            var directoryPath = GetDirectoryPath();
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            if (File.Exists(FullFilePath))
                File.Delete(FullFilePath);

            _logSaveThread = new Thread(LogsSave)
            {
                IsBackground = true,
                Priority = ThreadPriority.BelowNormal
            };
            _logSaveThread.Start();
        }

        private void LogsSave()
        {
            while (_logSaveThread.IsAlive)
            {
                if (_logsQueue.IsEmpty)
                {
                    Thread.Sleep(5);
                    continue;
                }
                
                while (_logsQueue.IsEmpty == false)
                {
                    if (_logsQueue.TryPeek(out var s) == false)
                    {
                        Thread.Sleep(5);
                        continue;
                    }

                    if (TryAppend(s) == true)
                        _logsQueue.TryDequeue(out var result);
                }

            }
        }

        private bool TryAppend(string s)
        {
            try
            {
                lock (lockerObject)
                {
                    using FileStream fileStream = File.Open(FullFilePath, FileMode.Append);
                    fileStream.Write(Encoding.UTF8.GetBytes(s));
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        private string GetDirectoryPath()
        {
            return Path.Combine(Application.persistentDataPath, LogsDirectoryName);
        }
        
        private void OnLogReceived(string message, string stacktrace, LogType type)
        {
            _logsQueue.Enqueue($"{string.Format(LogTimeFormat, DateTime.UtcNow, type, message)}\r");
        }

        public void Dispose()
        {
            Application.logMessageReceived -= OnLogReceived;
            _threadIsActive = false;
            _logSaveThread?.Abort();
        }

        public void Tick()
        {
#if UNITY_EDITOR
            if (Input.GetKeyUp(KeyCode.A))
            {
                UnityEditor.EditorUtility.RevealInFinder(GetDirectoryPath());
            }
#endif
        }
    }
}