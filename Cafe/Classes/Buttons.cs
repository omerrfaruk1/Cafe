using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Cafe
{
    internal class Buttons
    {
        
        public List<Button> Create_Buttons(int btnnumber, int btnwidth , int btnheight , int ButtonSpacing , int ButtonsPerRow)
        {



                List<Button> buttons = new List<Button>();
                for (int i = 0; i < btnnumber; i++)
                {
                    Button button = new Button();
                    button.Text = $"{i + 1}";
                    button.Size = new System.Drawing.Size(btnwidth, btnheight);
                    buttons.Add(button);
                }
           

                int horizontalSpacing = btnwidth + ButtonSpacing;
                int verticalSpacing = btnheight + ButtonSpacing;

                for (int i = 0; i < buttons.Count; i++)
                {
                    int row = i / ButtonsPerRow; // Satır
                    int column = i % ButtonsPerRow; // Sütun

                    int x = column * horizontalSpacing;
                    int y = row * verticalSpacing;

                    buttons[i].Location = new System.Drawing.Point(x, y);

                    foreach (Button b in buttons)
                    {
                        b.FlatStyle = FlatStyle.Flat;
                        b.FlatAppearance.BorderSize = 0;
                    b.Font = new Font("Microsoft YaHei UI", 12, FontStyle.Bold);
                        b.BackColor = ColorTranslator.FromHtml("#375168");

                }
                }
            
            return buttons;
      
            }
        }
    }
