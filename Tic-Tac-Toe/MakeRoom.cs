using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pong
{
    public partial class MakeRoom : Form
    {
        public MakeRoom()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            Game newGame = new Game(true, textBox1.Text, 0,3,8080);
            Visible = false;
            if (!newGame.IsDisposed)
                newGame.ShowDialog();
            Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game newGame = new Game(false, textBox1.Text, 0, 3, 8000);
            Visible = false;
            if (!newGame.IsDisposed)
                newGame.ShowDialog();
            Visible = true;
        }

        private void quaylai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MakeRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            GiaoDienDaDangKi f = new GiaoDienDaDangKi();
            f.Show();
        }
    }
}
