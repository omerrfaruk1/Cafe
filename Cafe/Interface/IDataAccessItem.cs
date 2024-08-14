using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Cafe.Interface
{
    internal interface IDataAccessItem
    {
        DataTable GetItemInfos(string name , string tablaName);

        
    }
}
