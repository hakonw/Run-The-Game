﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicGameV1 {
    public partial class Login : Form {
        public Login() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            GameGameGameV1GernGame.Settings.name = usernameBox.Text;
            this.Hide();
        }
    }
}
