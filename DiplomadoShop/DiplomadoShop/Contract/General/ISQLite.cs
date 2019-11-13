using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomadoShop.Contract.General
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();

    }
}
