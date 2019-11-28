
using DiplomadoShop.Contract.Data;
using DiplomadoShop.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Linq;
using System.Linq.Expressions;
using SQLiteNetExtensions.Extensions;
using System.Threading.Tasks;

namespace DiplomadoShop.Services.Data
{
    public class LocalDatabaseManager :IDisposable 
    {
        SQLiteConnection _sqliteConnetion;

        public LocalDatabaseManager()
        {
        
            _sqliteConnetion = DependencyService.Get<ISQLite>().GetConnection();
           // _sqliteConnetion.DropTable<Customer>();
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

        public int Insert<T>(T entity)
        {
            return _sqliteConnetion.Insert(entity);
        }

        public int Update<T>(T entity)
        {

            return _sqliteConnetion.Update(entity);
        }
        public IEnumerable<T> GetAll<T>() where T : new()
        {
            return _sqliteConnetion.Table<T>().AsEnumerable();
        }


        public List<T> GetAll<T>(Expression<Func<T, bool>> predicate, bool withChildren) where T : new()
        {
            if (withChildren)
            {
                return _sqliteConnetion.GetAllWithChildren<T>(predicate).ToList();
            }
            else
                return _sqliteConnetion.Table<T>().ToList();
        }

        public async Task<T> FindAsync<T>(Expression<Func<T, bool>> predicate, bool withChildren) where T : new()
        {


            var _task = Task.Run<T>(() => {

                if (withChildren)
                {
                    return _sqliteConnetion.GetAllWithChildren<T>(predicate).FirstOrDefault();
                }

                return _sqliteConnetion.Table<T>().FirstOrDefault(predicate);
            });

            return await _task;

        }


        public SQLiteConnection GetSqliteConnetion
        {

            get
            {
                if (_sqliteConnetion == null)
                    _sqliteConnetion = DependencyService.Get<ISQLite>().GetConnection();
                return _sqliteConnetion;
            }
        }

        //public void SaveCustomer(Customer customer) {
        //    bool _errors = false;
        //    using (var _db=_sqliteConnetion) {

        //        try
        //        {
        //            _db.BeginTransaction();
        //            _db.Insert(customer);

        //        }
        //        catch (Exception ex)
        //        {
        //            _errors = true;

        //            throw ex;
        //        }

        //        if (!_errors) _db.Commit();
        //    }

        //}


        //public int Insert<T>(T entity)
        //{
        //    return _sqliteConnetion.Insert(entity);
        //}

        //public IEnumerable<T> GetAll<T>() where T : new()
        //{
        //    return _sqliteConnetion.Table<T>().ToList();
        //}


        //public IEnumerable<Customer> GetCustomers() {

        //    return _sqliteConnetion.Table<Customer>().ToList();
        //}

    }
}
