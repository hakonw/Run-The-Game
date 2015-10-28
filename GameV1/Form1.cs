using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameGameGameV1GernGame {
    public partial class MainWindow : Form {
        bool flip_is_right = false;
        private int antijump = 0;

        List<Panel> blockList = new List<Panel>();
        private System.Windows.Forms.Panel panel;

        #region antiflic 
        /// <summary>
        /// fixing the antiflic
        /// from http://stackoverflow.com/a/25648710
        /// </summary>
        protected override CreateParams CreateParams {
            get {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }
        #endregion

        public MainWindow() {
            InitializeComponent();

            reset();
            Settings.gameover = true;
            Menu m = new Menu();
            //m.menuBackground(this);


        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e) {
            Input.ChangeState(e.KeyCode, true);
        }

        private void MainWindow_KeyUp(object sender, KeyEventArgs e) {
            Input.ChangeState(e.KeyCode, false);
        }

        private void UpdateScreen(object sender, EventArgs e) {

            if (Settings.gameover) {// checks if gameover
                if (Input.KeyPressed(Keys.Escape)) { Application.Exit(); } // quits
                                    

            } else {
                if (Input.KeyPressed(Settings.boost) && Settings.mspeed == Settings.mspeedD) { Settings.mspeed = Settings.mspeedB; } else if (!Input.KeyPressed(Settings.boost) && Settings.mspeed != Settings.mspeedD) { Settings.mspeed = Settings.mspeedD; }
                if (Input.KeyPressed(Settings.left)) { MovePlayer("left"); }
                if (Input.KeyPressed(Settings.right)) { MovePlayer("right"); }
                if (Input.KeyPressed(Settings.up)) { MovePlayer("up", 10, false, 0); }
                if (Input.KeyPressed(Settings.down)) { MovePlayer("down"); }
                if (Input.KeyPressed(Keys.R)) { reset(); } // resets
                if (Input.KeyPressed(Keys.Escape)) { Application.Exit(); } // quits
                if (Input.KeyPressed(Keys.Z)) { blockList.Add(block(this.player.Location.X + this.player.Width / 4, this.player.Location.Y + this.player.Height + 1, 32, 32, Color.Brown, Settings.boxt)); }

            }
            MovePlayer("down", 2);

        } // runs every tick


        private void MovePlayer(string direction = null, int m = 3, bool force = false, int boost = 1) {
            if (!collisioncheck(this.player, blockList) || force) {
                m = m * ((Settings.mspeed-1)*boost+1);
                switch (direction) {
                    case "left":
                        this.player.Location = new Point(this.player.Location.X - m, this.player.Location.Y);
                        Flip("left");
                        break;
                    case "right":
                        this.player.Location = new Point(this.player.Location.X + m, this.player.Location.Y);
                        Flip("right");
                        break;
                    case "up":
                        if (antijump < Settings.tickjump) {
                            this.player.Location = new Point(this.player.Location.X, this.player.Location.Y - m);
                            antijump++;
                        }
                        break;
                    case "down":
                        this.player.Location = new Point(this.player.Location.X, this.player.Location.Y + m);
                        break;
                    default:
                        break;
                }
                if (collisioncheck(this.player, blockList)) { MovePlayer(direction, -m/Settings.mspeed, true); antijump = 0; }

            }
        } // used to move the player

        private void Flip(string s) {
            if (s == "left" && flip_is_right) {
                player.BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                flip_is_right = false;
            } else if (s == "right" && !flip_is_right) {
                player.BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                flip_is_right = true;
            }
        } // used to flip image on player


        private Panel block(int x, int y, int width, int height, Color? c = null, Image img = null) {
            this.panel = new System.Windows.Forms.Panel();
            this.panel.BackColor = c ?? Color.Transparent;
            this.panel.Location = new Point(x, y);
            this.panel.Size = new Size(width, height);
            this.panel.Name = "A block";
            this.panel.Visible = true;
            this.panel.BackgroundImage = img;
            this.panel.BackgroundImageLayout = ImageLayout.Stretch;
            this.Controls.Add(this.panel);
            return this.panel;
        } // used to create a block on the screen

        private void drawplatform() {
            for(int i = 0; i < 1 + this.Width / Settings.boxw; i++) {
                blockList.Add(block(i*Settings.boxw, this.Height-Settings.boxh, Settings.boxh, Settings.boxw, Color.Brown, Settings.boxt));
            }
        }

        private bool collisioncheck(Panel p, List<Panel> LP) {
            foreach(Panel pane1 in LP) {
                if (pane1 == null || p == null) { break; }
                if (p.Bounds.IntersectsWith(pane1.Bounds)) {
                    return true;
                }
            }
            return false;
        }

        private void reset() {
            /*
            for (int i = 0; i < blockList.Count; i++) {
                if (blockList[i] == null) { break; }
                blockList[i].Dispose();
                //blockList[i] = null; commented out, fucked up my chi
                blockList.RemoveAt(i); // or blockList.Remove(blockList[i]);
            }
            */
            foreach (Panel pp in blockList) {
                pp.Dispose();
            }
            blockList.Clear();

            new Settings(); //intilialize the settings
            this.player.BackgroundImage = Settings.playert;
            flip_is_right = false;
            antijump = 0;
            _tick.Interval = 1000 / Settings.tspeed; // set the tickrate 
            _tick.Start(); // start the timer
            drawplatform(); // redraw the platform
            this.player.Location = new Point(this.Width/2, this.Height/2); // posission of player
            Settings.gameover = false;
        }

        //end
    }
}
