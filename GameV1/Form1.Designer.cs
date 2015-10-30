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
            this.player = new System.Windows.Forms.Panel();
            this._tick = new System.Windows.Forms.Timer(this.components);
            this.labelTick = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 525);
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
    }
}

