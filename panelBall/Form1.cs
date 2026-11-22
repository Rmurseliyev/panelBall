
using System;
using System.Windows.Forms;

namespace panelBall
{
    public partial class Form1 : Form
    {
        int xal = 0;

        int topX = 5;
        int topY = 5;

        public Form1()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            timer1.Tick += timer1_Tick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Xal: 0";

            timer1.Interval = 20;
            timer1.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && panel1.Left > 0)
            {
                panel1.Left -= 20;
            }

            if (e.KeyCode == Keys.Right &&
                panel1.Right < ClientSize.Width)
            {
                panel1.Left += 20;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Left += topX;
            pictureBox1.Top += topY;

            if (pictureBox1.Left <= 0)
                topX = Math.Abs(topX);

            if (pictureBox1.Right >= ClientSize.Width)
                topX = -Math.Abs(topX);

            if (pictureBox1.Top <= 0)
                topY = Math.Abs(topY);

            if (pictureBox1.Bounds.IntersectsWith(panel1.Bounds)
                && topY > 0)
            {
                topY = -Math.Abs(topY);

                xal++;
                label1.Text = "Xal: " + xal;

                pictureBox1.Top = panel1.Top - pictureBox1.Height;
            }

            if (pictureBox1.Top > ClientSize.Height)
            {
                timer1.Stop();

                MessageBox.Show(
                    "Oyun bitdi!\nYekun xalınız: " + xal +
                    "\nYeni oyun üçün OK düyməsinə basın.",
                    "Oyun bitdi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                YeniOyun();
            }
        }

        private void YeniOyun()
        {
            xal = 0;
            label1.Text = "Xal: 0";

            pictureBox1.Left = 328;
            pictureBox1.Top = 102;

            panel1.Left = 283;

            topX = 5;
            topY = 5;

            timer1.Start();
            this.Focus();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
