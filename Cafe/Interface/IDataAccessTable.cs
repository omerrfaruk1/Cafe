using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Interface
{
    internal interface IDataAccessTable
    {
        IDataReader GetDataTableByTableInfo(string name);
        IDataReader GetDataTableByName(string name);
        IDataReader GetDataTableByChanged(string name);
        IDataReader GetAllFullTables();

     
    }
}
