using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameGameGameV1GernGame {

    public enum Direction {
        Up,
        Down,
        Left,
        Right
    } //will change it to this later

    public enum MenuOptions {
        Resume,
        Settings,
        Quit
    } //will maby change to this later

    class Settings {

    #region get;set values

        //world properties 
        public static bool gameover { get; set; }
        public static int Score { get; set; }
        public static int tspeed { get; set; }
        public static int tickjump { get; set; }
        public static Keys restart { get; set; }
        public static Keys quit { get; set; }
        //player properties
        public static int mspeed { get; set; }
        public static int mspeedD { get; set; }
        public static int mspeedB { get; set; }
        public static Keys left { get; set; }
        public static Keys right { get; set; }
        public static Keys up { get; set; }
        public static Keys down { get; set; }
        public static Keys boost { get; set; }
        public static Keys sneak { get; set; }
        public static System.Drawing.Image playert { get; set; }
        public static string name { get; set; } = "Krenger";
        //box properties
        public static int boxw { get; set; }
        public static int boxh { get; set; }
        public static System.Drawing.Image boxt { get; set; }
        //enemy properties
        public static System.Drawing.Image enemyt { get; set; }
        public static int espeed { get; set; }
        //other properties
        public static string scorefile { get; set; }
        //public static MenuOptions mOptions { get; set; }

        #endregion


        public Settings() {
            //world properties 
            gameover = false;
            tspeed = 32; // ticks
            tickjump = 10; // ammount of ticks you can jump
            restart = Keys.R; // restart button
            quit = Keys.Q; // quit button
            //name = null; // name of the person

            //player properties
            mspeed = 2; // this is pixelmovement*2 pr tick
            mspeedB = 4; // speed boosted, is taken -1 on 
            mspeedD = mspeed; // default value for mspeed
            left = Keys.Left; // key to move left
            right = Keys.Right; // .._.. right
            up = Keys.Up; // .._..  up
            down = Keys.Down; // .._.. down
            boost = Keys.Space; // .._.. boost
            sneak = Keys.ShiftKey; // .._.. sneak

            //box properties
            boxw = 32; // pixel width of the box
            boxh = boxw; // pixel height of the box
            boxt = BasicGameV1.Properties.Resources.crate_0; // box texture
            playert = BasicGameV1.Properties.Resources.player_0; // player texture

            //enemy properties
            enemyt = BasicGameV1.Properties.Resources.enemy_0;
            espeed = 2;

            //scoreboard 
            scorefile = @"C:\Users\" + Environment.UserName + @"\Desktop\Remember-the-one-time-i-tried-to-make-a-souffle.questionmark";
        }

    }
}
