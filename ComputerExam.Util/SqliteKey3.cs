using System;
using System.Collections.Generic;
using System.Web;
using System.Runtime.InteropServices;
using System.Text;

namespace ComputerExam.Util
{
    public class SqliteKey3 : IDisposable
    {
        public const int SQLITE_OK = 0;
        [DllImport("sqlite3key.dll", EntryPoint = "sqlite3_key", CallingConvention = CallingConvention.Cdecl)]
        static extern int sqlite3_key(IntPtr db, byte[] key, int keylen);
        [DllImport("sqlite3key.dll", EntryPoint = "sqlite3_rekey", CallingConvention = CallingConvention.Cdecl)]
        static extern int sqlite3_rekey(IntPtr db, byte[] key, int keylen);
        [DllImport("sqlite3key.dll", EntryPoint = "sqlite3_close", CallingConvention = CallingConvention.Cdecl)]
        static extern int sqlite3_close(IntPtr db);
        [DllImport("sqlite3key.dll", EntryPoint = "sqlite3_finalize", CallingConvention = CallingConvention.Cdecl)]
        static extern int sqlite3_finalize(IntPtr stmHandle);
        [DllImport("sqlite3key.dll", EntryPoint = "sqlite3_errmsg", CallingConvention = CallingConvention.Cdecl)]
        static extern string sqlite3_errmsg(IntPtr db);
        //[DllImport("sqlite3key.dll", EntryPoint = "sqlite3_open")]
        [DllImport("sqlite3key.dll", EntryPoint = "sqlite3_open", CallingConvention = CallingConvention.Cdecl)]
        static extern int sqlite3_open(byte[] filename, out IntPtr db);
        private IntPtr _db;
        public bool ChangePassWord(string path, string oldPassWord, string newPassword)
        {
            if (sqlite3_open(Encoding.UTF8.GetBytes(path), out _db) != SQLITE_OK)
                throw new Exception("无法打开数据库: " + path);
            byte[] oldpassWord = null;
            byte[] newpassWord = null;
            int oldLength = 0, newLength = 0;
            if (!string.IsNullOrEmpty(oldPassWord))
            {
                oldpassWord = Encoding.UTF8.GetBytes(oldPassWord);
                oldLength = oldpassWord.Length;
            }
            if (!string.IsNullOrEmpty(newPassword))
            {
                newpassWord = Encoding.UTF8.GetBytes(newPassword);
                newLength = newPassword.Length;
            }
            int i = sqlite3_key(_db, oldpassWord, oldLength);
            int j = sqlite3_rekey(_db, newpassWord, newLength);
            CloseDatabase();
            if (j != SQLITE_OK)
            {
                throw new Exception(sqlite3_errmsg(_db));
            }
            return true;
        }
        public bool ChangePassWordByGB2312(string path, string oldPassWord, string newPassword)
        {
            if (sqlite3_open(Encoding.UTF8.GetBytes(path), out _db) != SQLITE_OK)
                throw new Exception("无法打开数据库: " + path);
            byte[] oldpassWord = null;
            byte[] newpassWord = null;
            int oldLength = 0, newLength = 0;
            if (!string.IsNullOrEmpty(oldPassWord))
            {
                oldpassWord = Encoding.GetEncoding("gb2312").GetBytes(oldPassWord);
                oldLength = oldpassWord.Length;
            }
            if (!string.IsNullOrEmpty(newPassword))
            {
                newpassWord = Encoding.GetEncoding("gb2312").GetBytes(newPassword);
                newLength = newPassword.Length;
            }
            int i = sqlite3_key(_db, oldpassWord, oldLength);
            int j = sqlite3_rekey(_db, newpassWord, newLength);
            CloseDatabase();
            if (j != SQLITE_OK)
            {
                //throw new Exception(sqlite3_errmsg(_db));
                return false;
            }
            return true;
        }
        public void CloseDatabase()
        {
            if (_db.ToInt32() != 0)
            {
                sqlite3_close(_db);
            }
        }
        public void Dispose()
        {
            CloseDatabase();
        }
    }
}