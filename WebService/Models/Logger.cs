using log4net;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace WebService.Models
{
    public static class Logger
    {
        public static bool IsDebugEnabled => Log.IsDebugEnabled;

        public static bool IsInfoEnabled => Log.IsInfoEnabled;

        public static bool IsWarnEnabled => Log.IsWarnEnabled;

        public static bool IsErrorEnabled => Log.IsErrorEnabled;

        public static bool IsFatalEnabled => Log.IsFatalEnabled;

        private static ILog Log { get; } = LogManager.GetLogger(typeof(log4net.Repository.Hierarchy.Logger));
        

        private static string GetHeader(string memberName, string sourceFilePath, int sourceLineNumber = 0)
        {
            if (string.IsNullOrEmpty(memberName) || string.IsNullOrEmpty(sourceFilePath)) return null;
            var fileName = (new FileInfo(sourceFilePath)).Name;
            var className = fileName.Split('.').First();
            var header = $"[{className}.{memberName}.{sourceLineNumber}] ";
            return header;
        }
        public static void DebugWithoutHeader(string msg)
        {
            Log.Debug(msg);
        }

        public static void Info(string msg,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (Log.IsDebugEnabled)
            {
                msg = GetHeader(memberName, sourceFilePath, sourceLineNumber) + msg;
            }
            Log.Info(msg);
        }

        public static void Info(string msg, Exception ex,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (Log.IsDebugEnabled)
            {
                msg = GetHeader(memberName, sourceFilePath, sourceLineNumber) + msg;
            }
            Log.Info(msg, ex);
        }
        public static void Debug(string msg,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (Log.IsDebugEnabled)
            {
                msg = GetHeader(memberName, sourceFilePath, sourceLineNumber) + msg;
            }
            Log.Debug(msg);
        }
        public static void Debug(string msg, Exception ex,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (Log.IsDebugEnabled)
            {
                msg = GetHeader(memberName, sourceFilePath, sourceLineNumber) + msg;
            }
            Log.Debug(msg, ex);
        }

        public static Action<string, Exception> OnLogError;
        public static void Error(string msg,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (Log.IsDebugEnabled)
            {
                msg = GetHeader(memberName, sourceFilePath, sourceLineNumber) + msg;
            }
            Log.Error(msg);
            var act = OnLogError;
            if (act != null)
            {
                act(msg, null);
            }
        }

        public static void Error(string msg, Exception ex,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (Log.IsDebugEnabled)
            {
                msg = GetHeader(memberName, sourceFilePath, sourceLineNumber) + msg;
            }
            Log.Error(msg, ex);
            var act = OnLogError;
            if (act != null)
            {
                act(msg, ex);
            }
        }

        public static void Warn(string msg,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (Log.IsDebugEnabled)
            {
                msg = GetHeader(memberName, sourceFilePath, sourceLineNumber) + msg;
            }
            Log.Warn(msg);
        }
        public static void Warn(string msg, Exception ex,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (Log.IsDebugEnabled)
            {
                msg = GetHeader(memberName, sourceFilePath, sourceLineNumber) + msg;
            }
            Log.Warn(msg, ex);
        }

        public static Action<string, Exception> OnLogFatal;
        public static void Fatal(string msg,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (Log.IsDebugEnabled)
            {
                msg = GetHeader(memberName, sourceFilePath, sourceLineNumber) + msg;
            }
            Log.Fatal(msg);
            var act = OnLogFatal;
            if (act != null)
            {
                act(msg, null);
            }
        }
        public static void Fatal(string msg, Exception ex,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (Log.IsDebugEnabled)
            {
                msg = GetHeader(memberName, sourceFilePath, sourceLineNumber) + msg;
            }
            Log.Fatal(msg, ex);
            var act = OnLogFatal;
            if (act != null)
            {
                act(msg, ex);
            }
        }
    }
}