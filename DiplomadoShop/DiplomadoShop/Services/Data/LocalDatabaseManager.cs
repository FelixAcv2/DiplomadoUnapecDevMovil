using DiplomadoShop.Contract.General;
using DiplomadoShop.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DiplomadoShop.Services.Data
{
    public class LocalDatabaseManager : IDisposable
    {
        SQLiteConnection _sqliteConnetion;

        public LocalDatabaseManager()
        {
        
            _sqliteConnetion = DependencyService.Get<ISQLite>().GetConnection();

            CreateTables();
        }

        private void CreateTables()
        {
            _sqliteConnetion.CreateTable<Customer>();
        }

        public void Dispose()
        {
            _sqliteConnetion.Dispose();
        }


        public void SaveCustomer(Customer customer) {
            bool _errors = false;
            using (var _db=_sqliteConnetion) {

                try
                {
                    _db.BeginTransaction();
                    _db.Insert(customer);

                }
                catch (Exception ex)
                {
                    _errors = true;

                    throw ex;
                }

                if (!_errors) _db.Commit();
            }
        
        }


        public IEnumerable<Customer> GetCustomers() {

            return _sqliteConnetion.Table<Customer>().ToList();
        }

    }
}
