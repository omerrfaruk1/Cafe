using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe.Classes
{
    public class AddItems
    {
        public List<Button> GetItemsNameByCategory(string category)
        {
            Menu menuItem = new Menu();

            List<Button> btn = menuItem.GetItemName(category);

                return btn;
        }
        
    }
}
