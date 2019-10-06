using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartWithNothing
{
    public partial class Game : Form
    {
        public int speed = 1;
        public int racerSpeed = 15;

        public bool racing = false;
        public bool training = false;
        public bool doneRace = false;
        public bool doneTrain = false;
        public bool addSpeed = false;


        public Game()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            racing = true;
            addSpeed = false;
            player.Left = 35;
            player.Top = 225;
            racer.Left = 35;
            racer.Top = 10;

            button2.Visible = false;
        }

        private void GameTick_Tick(object sender, EventArgs e)
        {
            if (racing == true)
            {
                player.Left += speed;
            }

            if (player.Bounds.IntersectsWith(pictureBox1.Bounds) && racing == true)
            {
                racing = false;
                doneRace = true;
                player.Left = 35;
                player.Top = 225;
                racer.Left = 35;
                racer.Top = 10;
                button2.Visible = true;

                MessageBox.Show("You Won");
            }

            if (racer.Bounds.IntersectsWith(pictureBox1.Bounds) && racing == true)
            {
                racing = false;
                doneRace = true;
                player.Left = 35;
                player.Top = 225;
                racer.Left = 35;
                racer.Top = 10;
                button2.Visible = true;

                MessageBox.Show("You Lost");
            }

            if (doneRace == true)
            {
                player.Left += 0;
                racer.Left += 0;
            }

            if (training == true)
            {
                player.Left += speed;
            }

            if (player.Bounds.IntersectsWith(pictureBox1.Bounds) && training == true)
            {
                doneTrain = true;
                training = false;
                player.Left = 35;
                player.Top = 225;
                addSpeed = true;

                button1.Visible = true;
            }

            if (addSpeed == true)
            {
                button3.Visible = true;
            }

            if (addSpeed == false)
            {
                button3.Visible = false;
            }

            if (racing == true)
            {
                racer.Visible = true;
                racer.Left += racerSpeed;
            }

            if (speed > 35)
            {
                racerSpeed = 50;
            }

            if (speed > 60)
            {
                racerSpeed = 100;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            training = true;
            player.Left = 35;
            player.Top = 225;
            racer.Visible = false;

            button1.Visible = false;
        }

        private void Game_Load(object sender, EventArgs e)
        {
            racer.Visible = false;

            song.URL = "Speed.wav";
            song.settings.volume = 65;
            song.settings.setMode("loop", true);
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            if (doneTrain == true)
            {
                speed += 1;
                addSpeed = false;
            }

            Console.WriteLine(speed);
        }
    }
}
