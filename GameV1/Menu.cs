using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GameGameGameV1GernGame {
    class Menu {
        private System.Windows.Forms.Panel panelB = new System.Windows.Forms.Panel();

        public Menu() {
            //gjør menystuff her
        }

        public void menuBackground(MainWindow f) {
            this.panelB.BackColor = Color.DimGray;
            //this.panelB.BackColor = Color.FromArgb(200, Color.Gray); //? mah CHI no like
            this.panelB.Location = new Point(0, 0);
            this.panelB.Size = new Size(f.Width, f.Height);
            this.panelB.Name = "Menu Bakground";
            this.panelB.Visible = true;
            this.panelB.Enabled = true;
            f.Controls.Add(this.panelB);
            this.panelB.BringToFront();
        }



    }
}
