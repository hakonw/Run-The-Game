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
        private bool flip_is_right = false;
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
            UpdateScreen(null, null);
            new Menu().creation(this, true);


        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e) {
            Input.ChangeState(e.KeyCode, true);
            if (Input.KeyPressed(Settings.quit)) { Application.Exit(); } // Exits the game
        }

        private void MainWindow_KeyUp(object sender, KeyEventArgs e) {
            Input.ChangeState(e.KeyCode, false);
        }

        private void UpdateScreen(object sender, EventArgs e) {
            //if (!_tick.Enabled) { _tick.Enabled = true; }



            if (Input.KeyPressed(Keys.Escape)) { new Menu().creation(this); } // Goes to the meny
            if (Input.KeyPressed(Settings.restart)) { reset(); } // resets

            if (Settings.gameover) {// checks if gameover
                
            } else {
                if (outside(this.player)) {
                    Settings.gameover = true;
                }
                #region movement controll
                if (Input.KeyPressed(Settings.boost) && Settings.mspeed == Settings.mspeedD) { Settings.mspeed = Settings.mspeedB; } else if ((!Input.KeyPressed(Settings.boost) || !Input.KeyPressed(Settings.sneak)) && Settings.mspeed != Settings.mspeedD) { Settings.mspeed = Settings.mspeedD; } //used to increas the speed
                if (Input.KeyPressed(Settings.sneak) && Settings.mspeed == Settings.mspeedD) { Settings.mspeed = Settings.mspeedB/4; } //used to reduce the speed
                if (Input.KeyPressed(Settings.left)) { MovePlayer("left"); }
                if (Input.KeyPressed(Settings.right)) { MovePlayer("right"); }
                if (Input.KeyPressed(Settings.up)) { MovePlayer("up", 10, false, 0); } // moves player up 10*2(movement pr tick) pr tick, not forced (checking for collision), will not be boosted
                if (Input.KeyPressed(Settings.down)) { MovePlayer("down"); }

                if (Input.KeyPressed(Keys.S)) {
                    Panel p_1 = block(this.player.Location.X + this.player.Width / 4, this.player.Location.Y + this.player.Height + 1, Settings.boxw, Settings.boxh, Color.Brown, Settings.boxt);
                    if (p_1 != null) { blockList.Add(p_1); }
                }
                if (Input.KeyPressed(Keys.W)) {
                    Panel p_1 = block(this.player.Location.X + this.player.Width / 4, this.player.Location.Y - Settings.boxh, Settings.boxw, Settings.boxh, Color.Brown, Settings.boxt);
                    if (p_1 != null) { blockList.Add(p_1); }
                }
                if (Input.KeyPressed(Keys.A)) {
                    Panel p_1 = block(this.player.Location.X - Settings.boxw, this.player.Location.Y + this.player.Height/4, Settings.boxw, Settings.boxh, Color.Brown, Settings.boxt);
                    if (p_1 != null) { blockList.Add(p_1); }
                }
                if (Input.KeyPressed(Keys.D)) {
                    Panel p_1 = block(this.player.Location.X + this.player.Width, this.player.Location.Y + this.player.Height / 4, Settings.boxw, Settings.boxh, Color.Brown, Settings.boxt);
                    if (p_1 != null) { blockList.Add(p_1); }
                }
                #endregion movement controll
            }
            MovePlayer("down", 2); //  Non-Accelerating gravity,  might change to more real accelerating gravity

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
                if (collisioncheck(this.player, blockList)) { try { MovePlayer(direction, -m / Settings.mspeed, true); } catch (System.StackOverflowException) { /* "infinite loop" */ MovePlayer(direction, -m*2 / Settings.mspeed, true); } antijump = 0; }

                labelTick.Text = "Score: "+Convert.ToString(Settings.Score++);  // tells and keeps track of the core

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


        private Panel block(int x, int y, int width = 32, int height = 32, Color? c = null, Image img = null) {
            this.panel = new System.Windows.Forms.Panel();
            this.panel.BackColor = c ?? Color.Transparent;
            this.panel.Location = new Point(x, y);
            this.panel.Size = new Size(width, height);
            this.panel.Name = "A block";
            this.panel.Visible = true;
            this.panel.BackgroundImage = img;
            this.panel.BackgroundImageLayout = ImageLayout.Stretch;
            this.Controls.Add(this.panel);

            //removes block if it collides with another one
            foreach (Panel p in blockList) {
                if (p == null || this.panel == null) { break; }
                if (this.panel.Bounds.IntersectsWith(p.Bounds)) {
                    this.Controls.Remove(this.panel);
                    this.panel.Dispose();
                    return null;
                }
            }
            return this.panel;
        } // used to create a block on the screen

        private void drawplatform() {
            for(int i = 0; i < 1 + this.Width / Settings.boxw; i++) {
                blockList.Add(block(i*Settings.boxw, this.Height-Settings.boxh, Settings.boxh, Settings.boxw, Color.Brown, Settings.boxt));
            }
        }

        private bool outside(Panel p) {
            if ((p.Location.X > -p.Width && p.Location.X < (this.Width)) && (p.Location.Y > -p.Height && p.Location.Y < (this.Height))) {
                return false;
            }
            Console.WriteLine(p.Location.X + " thisX | windowX " + this.Height + " || " + p.Location.Y + " thisY | windowY " + this.Width);
            return true;
        }

        private bool collisioncheck(Panel p, List<Panel> LP) {
            foreach(Panel pane1 in LP) {
                if (pane1 == null || p == null) { break; }
                if (p.Bounds.IntersectsWith(pane1.Bounds)) {
                    return true;
                }
            }
            return false;
        } // used to check if collision between two panels

       private void reset() {
            foreach (Panel pp in blockList) {
                if (pp == null || blockList == null) { break; }
                pp.Dispose();
            } // goes thru all the panels in the lists and disposes of them
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
            Settings.Score = 0;
            Input.ChangeState(Settings.restart, false);
        }

        //end
    }
}
