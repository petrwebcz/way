using System;
using System.IO;
using Xamarin.Essentials;

namespace WhereAreYou.MobileApp.Services
{
    public static class DbConstants
    {
        public const string DatabaseFilename = "WaySqlLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = FileSystem.AppDataDirectory;
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}
