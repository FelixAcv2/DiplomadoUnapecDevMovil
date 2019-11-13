using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DiplomadoShop.Contract.General;
using DiplomadoShop.Droid.Services;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseService))]
namespace DiplomadoShop.Droid.Services
{
    
   public class DatabaseService : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var _sqliteFilename = "shop.db3";
            string _documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var _path = Path.Combine(_documentsPath, _sqliteFilename);
            var conn = new SQLite.SQLiteConnection(_path);
            return conn;

        }
    }
}