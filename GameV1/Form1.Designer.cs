namespace GameGameGameV1GernGame {
    partial class MainWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this._tick = new System.Windows.Forms.Timer(this.components);
            this.labelTick = new System.Windows.Forms.Label();
            this.gameoverText = new System.Windows.Forms.Label();
            this.enemy = new System.Windows.Forms.Panel();
            this.player = new System.Windows.Forms.Panel();
            this.Scoreboard = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _tick
            // 
            this._tick.Tick += new System.EventHandler(this.UpdateScreen);
            // 
            // labelTick
            // 
            this.labelTick.AutoSize = true;
            this.labelTick.BackColor = System.Drawing.Color.Transparent;
            this.labelTick.Location = new System.Drawing.Point(0, 0);
            this.labelTick.Name = "labelTick";
            this.labelTick.Size = new System.Drawing.Size(38, 13);
            this.labelTick.TabIndex = 1;
            this.labelTick.Text = "Score:";
            // 
            // gameoverText
            // 
            this.gameoverText.AutoSize = true;
            this.gameoverText.BackColor = System.Drawing.Color.Transparent;
            this.gameoverText.Font = new System.Drawing.Font("Microsoft Sans Serif", 32.25F);
            this.gameoverText.ForeColor = System.Drawing.Color.Tomato;
            this.gameoverText.Location = new System.Drawing.Point(386, 88);
            this.gameoverText.Name = "gameoverText";
            this.gameoverText.Size = new System.Drawing.Size(234, 51);
            this.gameoverText.TabIndex = 2;
            this.gameoverText.Text = "Game over";
            this.gameoverText.Visible = false;
            // 
            // enemy
            // 
            this.enemy.BackColor = System.Drawing.Color.Transparent;
            this.enemy.BackgroundImage = global::BasicGameV1.Properties.Resources.enemy_0;
            this.enemy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.enemy.ForeColor = System.Drawing.Color.Transparent;
            this.enemy.Location = new System.Drawing.Point(3, 30);
            this.enemy.Name = "enemy";
            this.enemy.Size = new System.Drawing.Size(57, 56);
            this.enemy.TabIndex = 3;
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.BackgroundImage = global::BasicGameV1.Properties.Resources.player_0;
            this.player.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.player.Location = new System.Drawing.Point(424, 238);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(57, 59);
            this.player.TabIndex = 0;
            // 
            // Scoreboard
            // 
            this.Scoreboard.AutoSize = true;
            this.Scoreboard.BackColor = System.Drawing.Color.Transparent;
            this.Scoreboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Scoreboard.Location = new System.Drawing.Point(774, 73);
            this.Scoreboard.Name = "Scoreboard";
            this.Scoreboard.Size = new System.Drawing.Size(125, 240);
            this.Scoreboard.TabIndex = 4;
            this.Scoreboard.Text = "Spermi:10000\r\nSpermi:9999\r\nSpermi:9998\r\nSpermi:9997\r\nSpermi:9996\r\nSpermi:9995\r\nSp" +
    "ermi:9994\r\nSpermi:9993\r\nSpermi:9992\r\nSpermi:9991\r\n";
            this.Scoreboard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Scoreboard.Visible = false;
            this.Scoreboard.Click += new System.EventHandler(this.scoreboardR);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 525);
            this.Controls.Add(this.Scoreboard);
            this.Controls.Add(this.enemy);
            this.Controls.Add(this.gameoverText);
            this.Controls.Add(this.labelTick);
            this.Controls.Add(this.player);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainWindow";
            this.Text = "The Game?";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel player;
        public System.Windows.Forms.Timer _tick;
        private System.Windows.Forms.Label labelTick;
        private System.Windows.Forms.Label gameoverText;
        private System.Windows.Forms.Panel enemy;
        private System.Windows.Forms.Label Scoreboard;
    }
}

