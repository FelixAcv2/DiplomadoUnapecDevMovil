using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomadoShop.Contract.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();

    }
}
