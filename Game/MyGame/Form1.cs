using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame
{
    public partial class Form1 : Form
    {

        bool right, left;
        bool jump;
        int G = 20;
        int Force;
        int index = 0;

        public Form1()
        {
            InitializeComponent();
            //Block.Top = Screen.Height - Block.Height; // Start pos
            //Player.Top = Screen.Height - Player.Height; //Player pos
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            index++;
            // Gif replay
            if (right == true && index %15 == 0)
            {
                //Player.Image = Image.FromFile("walk_r.gif");
                Player.Image = Image.FromFile("walk_r.gif");
            }
            if (left == true && index % 15 == 0)
            {
                Player.Image = Image.FromFile("walk_l.gif");
            }



            // Side collision
            if (Player.Right > Block.Left && Player.Left< Block.Right - Player.Width && Player.Bottom< Block.Bottom && Player.Bottom>Block.Top)
            {
                right = false;
            }
            if (Player.Left < Block.Right && Player.Right > Block.Left + Player.Width && Player.Bottom < Block.Bottom && Player.Bottom > Block.Top)
            {
                left = false;
            }

            //***************
            if (right == true){ Player.Left += 5;}
            if (left == true) { Player.Left -= 5;}

            // Falling if jumping
            if (jump == true)
            {
                Player.Top -= Force;
                Force -= 1;
            }

            if (Player.Top + Player.Height >= Screen.Height)
            {
                Player.Top = Screen.Height - Player.Height; // Stop the falling to bottom
                if (jump == true)
                {
                    Player.Image = Image.FromFile("stand.png");
                }

                jump = false; 
            }
            else
            {
                Player.Top += 5; // Falling
            } 

            // Top collision
            if (Player.Left + Player.Width- 1 > Block.Left && Player.Left + Player.Width +5 < Block.Left + Block.Width + Player.Width && Player.Height + Player.Top >= Block.Top && Player.Top < Block.Top)
            {
                /*Player.Top = Screen.Height - Block.Height - Player.Height;
                Force = 0;
                if (jump == true)
                {
                    Player.Image = Image.FromFile("stand.png");
                }*/
                jump = false;
                Force = 0;
                Player.Top = Block.Location.Y - Player.Height;
            }

            // Head collision
            if (Player.Left + Player.Width - 1 > Block.Left && Player.Left + Player.Width + 5 < Block.Left + Block.Width + Player.Width && Player.Top - Block.Bottom <=10 && Player.Top - Block.Top > -10)
            {
                Force = -1;
                
            }
            if (Player.Left + Player.Width - 1 > Block2.Left && Player.Left + Player.Width + 5 < Block2.Left + Block2.Width + Player.Width && Player.Top - Block2.Bottom <= 10 && Player.Top - Block2.Top > -10)
            {
                Force = -1;

            }
            if (Block2.Bottom - Player.Top >= 10 && Player.Top - Block2.Top < -10)
            {
                Force = 1;

            }


            //***************

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) { right = true;
                //Player.Image = Image.FromFile("walk_r.gif");
            }
            if (e.KeyCode == Keys.Left) { left = true;
                //Player.Image = Image.FromFile("walk_l.gif");
            }
            if (e.KeyCode == Keys.Escape) { this.Close(); } //Escape -> Exit

            if (jump != true)
            {
                if (e.KeyCode == Keys.Space)
                {
                    jump = true;
                    Force = G;
                    Player.Image = Image.FromFile("jump.png");
                }
            }

        }

        private void Block_Click(object sender, EventArgs e)
        {

        }

        private void Screen_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) { right = false;
                Player.Image = Image.FromFile("stand.png");
            }
            if (e.KeyCode == Keys.Left) { left = false;
                Player.Image = Image.FromFile("stand.png");
            }
           
        }
    }
}
