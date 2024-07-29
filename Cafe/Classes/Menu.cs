using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class Menu
    {
        Buttons button = new Buttons();

        private List<Items> ItemList { get; set; } = new List<Items>();
        public void AddItem(string name, string category, double price)
        {
            Items items = new Items
            {
                name = name,
                category = category,
                price = price
            };

            ItemList.Add(items);
        }

        public List<Button> GetItem(string kategori)
        {
            List<Button> buttons = new List<Button>();

            var item = ItemList.Where(i => i.category.Equals(kategori, StringComparison.OrdinalIgnoreCase)).ToList();


            var btn = button.Create_Buttons(item.Count, 50, 50, 10, 4);
            int k = 0;
            foreach (var itemcategory in item)
            {

                btn[k].Text = itemcategory.name;
                k++;
                //panel1.Controls.Add(btn[i]);
            }
            return btn;

        }

        
    }
}