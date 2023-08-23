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
    public partial class Music : Form
    {
        public Music()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = "FILE_20210513_221817_MusicGamePingpong.wav";
            player.PlayLooping();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = "FILE_20210513_221817_MusicGamePingpong.wav";
            player.Stop();
        }

        private void Music_Load(object sender, EventArgs e)
        {

        }
    }
}
