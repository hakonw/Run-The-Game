using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GameGameGameV1GernGame {
    class Menu {
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label;
        private MainWindow ff;
        List<Label> Lab = new List<Label>();

        public Menu() {
            //gjør menystuff her
        }

        private void menuBackground(MainWindow f) {
            this.panel = new System.Windows.Forms.Panel();
            this.panel.BackColor = Color.White;
            this.panel.Location = new Point(0, 0);
            this.panel.Size = new Size(f.Width, f.Height);
            this.panel.Name = "Menu Bakground";
            this.panel.Visible = true;
            this.panel.Enabled = true;
            f.Controls.Add(this.panel);
            this.panel.BringToFront();
        } // method to make the menu

        private Label menuText(MainWindow f, int x, int y, string t, int sx = 200, int sy = 100) {
            this.label = new System.Windows.Forms.Label();
            this.label.Location = new Point(x,y);
            this.label.Name = t;
            this.label.Text = t;
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label.Size = new System.Drawing.Size(sx, sy);
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 30f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = Color.Black;
            f.Controls.Add(this.label);
            this.label.BringToFront();
            this.label.MouseEnter += new System.EventHandler(this.labelEnter);
            this.label.MouseLeave += new System.EventHandler(this.labelLeave);
            this.label.Click += new System.EventHandler(this.labelClick);
            return this.label;
        } // method to make a label

        public void creation(MainWindow f, bool n = false) { //må ha i instillinger
            ff = f;
            menuBackground(f);
            if (n) {
                Lab.Add(menuText(f, f.Width / 2 - 100, 20, "New Game"));
            } else {
                Lab.Add(menuText(f, f.Width / 2 - 100, 20, "Resume"));
            }
            //Lab.Add(menuText(f, f.Width/2-100, 220, "Options"));
            Lab.Add(menuText(f, f.Width/2-100, 220, "Restart"));
            Lab.Add(menuText(f, f.Width/2-100, 420, "Quit"));
            f._tick.Stop();
        } // creates the meny

        private void labelEnter(object sender, EventArgs e) {
            ((Label)sender).ForeColor = Color.Red; 

        } // colors the lable Red when hovering

        private void labelLeave(object sender, EventArgs e) {
            ((Label)sender).ForeColor = Color.Black;
        } // color the lable black when not hovering 

        private void labelClick(object sender, EventArgs e) {
            switch (((Label)sender).Name) {
                case "Resume":
                case "New Game":
                    decreation();
                    ff._tick.Start();
                    ff = null;
                    break;
                case "Restart":
                    decreation();
                    Input.ChangeState(Settings.restart, true);
                    ff._tick.Start();
                    ff = null;
                    break;
                case "Settings":
                    break;
                case "Quit":
                    Application.Exit();
                    break;
            }
        }

        private void decreation() {
            this.panel.Dispose();
            foreach (Label pp in Lab) {
                pp.Dispose();
            }
            Lab.Clear();
        } // removes the meny

        // end
    }
}

