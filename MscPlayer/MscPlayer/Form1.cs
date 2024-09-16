using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace MscPlayer
{
    public partial class Form1 : Form
    {
        WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
        public Form1()
        {
            InitializeComponent();
        }
        string[] paths, files;
        bool play = false;



        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if(ofd.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                files = ofd.FileNames;
                paths = ofd.FileNames;

                for (int x = 0;x < files.Length; x++)
                {
                    track_list.Items.Add($"{x+1}.{files[x]}");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            button2.Text = "Play";
            play = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!play)
            {
                player.controls.play();
                button2.Text = "Pause";
                play = true;
            }
            else
            {
                player.controls.pause();
                button2.Text = "Play";
                play = false;
            }
                
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (track_list.SelectedIndex < track_list.Items.Count - 1)
                track_list.SelectedIndex = track_list.SelectedIndex + 1;   
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(track_list.SelectedIndex>0)
                track_list.SelectedIndex = track_list.SelectedIndex - 1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (player.playState == WMPLib.WMPPlayState.wmppsPlaying) 
            {
                progressBar1.Maximum = (int)player.controls.currentItem.duration;
                progressBar1.Value = (int)player.controls.currentPosition;
            }
        }

        private void track_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                player.URL = paths[track_list.SelectedIndex];
                player.controls.play();
                button2.Text = "Pause";
                play = true;
            }
            catch { }
        }

    }
}
