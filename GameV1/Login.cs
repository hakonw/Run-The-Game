using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BasicGameV1 {
    public partial class Login : Form {
        public Login() {
            InitializeComponent();
        }


        private void go() {
            this.Hide();
        }

        private void loginButton_Click(object sender, EventArgs e) {
            //sjekke om valid brukernavn
            //så åpne spillet
            go();
        }

        private void skip_Click(object sender, EventArgs e) {
            //om du hater å logge inn
            go();
        }

        private void register_Click(object sender, EventArgs e) {
            //kode for å registrere
        }
    }
}
