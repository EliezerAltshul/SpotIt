using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotIt
{
    public partial class Form1 : Form
    {

        static string[] images = System.IO.Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, @"png"), "*.png");
        static List<Spot> userSpots = new List<Spot>();
        static List<Spot> compSpots = new List<Spot>();
        static Game game;
        static bool gameContinue;
        static int[] userCard;
        static int[] compCard;
        static int counter;
        static int timeMin = 0, timeSec = 0;
        static int bestTimeMin = int.MaxValue, bestTimeSec = int.MaxValue;
        public Form1()
        {
            InitializeComponent();

        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PlayButton = new System.Windows.Forms.Button();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.doneLabel = new System.Windows.Forms.Label();
            this.cardCountLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TimeMinLabel = new System.Windows.Forms.Label();
            this.TimeSecLabel = new System.Windows.Forms.Label();
            this.BestScore = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox8Comp = new System.Windows.Forms.PictureBox();
            this.pictureBox7Comp = new System.Windows.Forms.PictureBox();
            this.pictureBox6Comp = new System.Windows.Forms.PictureBox();
            this.pictureBox5Comp = new System.Windows.Forms.PictureBox();
            this.pictureBox4Comp = new System.Windows.Forms.PictureBox();
            this.pictureBox3Comp = new System.Windows.Forms.PictureBox();
            this.pictureBox2Comp = new System.Windows.Forms.PictureBox();
            this.pictureBox1Comp = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8Comp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7Comp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6Comp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5Comp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4Comp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3Comp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2Comp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1Comp)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayButton
            // 
            this.PlayButton.Location = new System.Drawing.Point(176, 12);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(75, 39);
            this.PlayButton.TabIndex = 2;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_ClickAsync);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Location = new System.Drawing.Point(346, 250);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(93, 93);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 11;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(246, 250);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(93, 93);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 10;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(147, 250);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(93, 93);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 9;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(346, 150);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(93, 93);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(246, 150);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(93, 93);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(147, 150);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // doneLabel
            // 
            this.doneLabel.AutoSize = true;
            this.doneLabel.Location = new System.Drawing.Point(257, 23);
            this.doneLabel.MinimumSize = new System.Drawing.Size(200, 0);
            this.doneLabel.Name = "doneLabel";
            this.doneLabel.Size = new System.Drawing.Size(200, 17);
            this.doneLabel.TabIndex = 12;
            // 
            // cardCountLabel
            // 
            this.cardCountLabel.AutoSize = true;
            this.cardCountLabel.Location = new System.Drawing.Point(463, 15);
            this.cardCountLabel.MinimumSize = new System.Drawing.Size(100, 0);
            this.cardCountLabel.Name = "cardCountLabel";
            this.cardCountLabel.Size = new System.Drawing.Size(100, 17);
            this.cardCountLabel.TabIndex = 13;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TimeMinLabel
            // 
            this.TimeMinLabel.AutoSize = true;
            this.TimeMinLabel.Location = new System.Drawing.Point(895, 23);
            this.TimeMinLabel.MinimumSize = new System.Drawing.Size(50, 0);
            this.TimeMinLabel.Name = "TimeMinLabel";
            this.TimeMinLabel.Size = new System.Drawing.Size(50, 17);
            this.TimeMinLabel.TabIndex = 15;
            // 
            // TimeSecLabel
            // 
            this.TimeSecLabel.AutoSize = true;
            this.TimeSecLabel.Location = new System.Drawing.Point(951, 23);
            this.TimeSecLabel.MinimumSize = new System.Drawing.Size(50, 0);
            this.TimeSecLabel.Name = "TimeSecLabel";
            this.TimeSecLabel.Size = new System.Drawing.Size(50, 17);
            this.TimeSecLabel.TabIndex = 16;
            // 
            // BestScore
            // 
            this.BestScore.AutoSize = true;
            this.BestScore.Location = new System.Drawing.Point(801, 40);
            this.BestScore.MinimumSize = new System.Drawing.Size(200, 0);
            this.BestScore.Name = "BestScore";
            this.BestScore.Size = new System.Drawing.Size(200, 17);
            this.BestScore.TabIndex = 17;
            this.BestScore.Text = "Best Score:";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Location = new System.Drawing.Point(196, 349);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(93, 93);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 18;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // pictureBox8
            // 
            this.pictureBox8.Location = new System.Drawing.Point(295, 349);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(93, 93);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 19;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Click += new System.EventHandler(this.pictureBox8_Click);
            // 
            // pictureBox8Comp
            // 
            this.pictureBox8Comp.Location = new System.Drawing.Point(705, 349);
            this.pictureBox8Comp.Name = "pictureBox8Comp";
            this.pictureBox8Comp.Size = new System.Drawing.Size(93, 93);
            this.pictureBox8Comp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8Comp.TabIndex = 27;
            this.pictureBox8Comp.TabStop = false;
            // 
            // pictureBox7Comp
            // 
            this.pictureBox7Comp.Location = new System.Drawing.Point(606, 349);
            this.pictureBox7Comp.Name = "pictureBox7Comp";
            this.pictureBox7Comp.Size = new System.Drawing.Size(93, 93);
            this.pictureBox7Comp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7Comp.TabIndex = 26;
            this.pictureBox7Comp.TabStop = false;
            // 
            // pictureBox6Comp
            // 
            this.pictureBox6Comp.Location = new System.Drawing.Point(756, 250);
            this.pictureBox6Comp.Name = "pictureBox6Comp";
            this.pictureBox6Comp.Size = new System.Drawing.Size(93, 93);
            this.pictureBox6Comp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6Comp.TabIndex = 25;
            this.pictureBox6Comp.TabStop = false;
            // 
            // pictureBox5Comp
            // 
            this.pictureBox5Comp.Location = new System.Drawing.Point(656, 250);
            this.pictureBox5Comp.Name = "pictureBox5Comp";
            this.pictureBox5Comp.Size = new System.Drawing.Size(93, 93);
            this.pictureBox5Comp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5Comp.TabIndex = 24;
            this.pictureBox5Comp.TabStop = false;
            // 
            // pictureBox4Comp
            // 
            this.pictureBox4Comp.Location = new System.Drawing.Point(557, 250);
            this.pictureBox4Comp.Name = "pictureBox4Comp";
            this.pictureBox4Comp.Size = new System.Drawing.Size(93, 93);
            this.pictureBox4Comp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4Comp.TabIndex = 23;
            this.pictureBox4Comp.TabStop = false;
            // 
            // pictureBox3Comp
            // 
            this.pictureBox3Comp.Location = new System.Drawing.Point(756, 150);
            this.pictureBox3Comp.Name = "pictureBox3Comp";
            this.pictureBox3Comp.Size = new System.Drawing.Size(93, 93);
            this.pictureBox3Comp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3Comp.TabIndex = 22;
            this.pictureBox3Comp.TabStop = false;
            // 
            // pictureBox2Comp
            // 
            this.pictureBox2Comp.Location = new System.Drawing.Point(656, 150);
            this.pictureBox2Comp.Name = "pictureBox2Comp";
            this.pictureBox2Comp.Size = new System.Drawing.Size(93, 93);
            this.pictureBox2Comp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2Comp.TabIndex = 21;
            this.pictureBox2Comp.TabStop = false;
            // 
            // pictureBox1Comp
            // 
            this.pictureBox1Comp.Location = new System.Drawing.Point(557, 150);
            this.pictureBox1Comp.Name = "pictureBox1Comp";
            this.pictureBox1Comp.Size = new System.Drawing.Size(93, 94);
            this.pictureBox1Comp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1Comp.TabIndex = 20;
            this.pictureBox1Comp.TabStop = false;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1182, 628);
            this.Controls.Add(this.pictureBox8Comp);
            this.Controls.Add(this.pictureBox7Comp);
            this.Controls.Add(this.pictureBox6Comp);
            this.Controls.Add(this.pictureBox5Comp);
            this.Controls.Add(this.pictureBox4Comp);
            this.Controls.Add(this.pictureBox3Comp);
            this.Controls.Add(this.pictureBox2Comp);
            this.Controls.Add(this.pictureBox1Comp);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.BestScore);
            this.Controls.Add(this.TimeSecLabel);
            this.Controls.Add(this.TimeMinLabel);
            this.Controls.Add(this.cardCountLabel);
            this.Controls.Add(this.doneLabel);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.PlayButton);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8Comp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7Comp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6Comp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5Comp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4Comp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3Comp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2Comp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1Comp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BestScore.Text += " Minute: " + 0 + " Second: " + 0;
            userSpots.Add(new Spot(this.pictureBox1, -1));
            userSpots.Add(new Spot(this.pictureBox2, -1));
            userSpots.Add(new Spot(this.pictureBox3, -1));
            userSpots.Add(new Spot(this.pictureBox4, -1));
            userSpots.Add(new Spot(this.pictureBox5, -1));
            userSpots.Add(new Spot(this.pictureBox6, -1));
            userSpots.Add(new Spot(this.pictureBox7, -1));
            userSpots.Add(new Spot(this.pictureBox8, -1));

            compSpots.Add(new Spot(this.pictureBox1Comp, -1));
            compSpots.Add(new Spot(this.pictureBox2Comp, -1));
            compSpots.Add(new Spot(this.pictureBox3Comp, -1));
            compSpots.Add(new Spot(this.pictureBox4Comp, -1));
            compSpots.Add(new Spot(this.pictureBox5Comp, -1));
            compSpots.Add(new Spot(this.pictureBox6Comp, -1));
            compSpots.Add(new Spot(this.pictureBox7Comp, -1));
            compSpots.Add(new Spot(this.pictureBox8Comp, -1));

        }

        private void PlayButton_ClickAsync(object sender, EventArgs e)
        {
            game = new Game(8, images);
            gameContinue = true;

            counter = game.elems.Length - 3;

            userCard = game.Deck.Pop();
            compCard = game.Deck.Pop();

            DisplayCards(userCard, userSpots, compCard, compSpots);

            doneLabel.Text = "";
            TimeMinLabel.Text = "";
            TimeMinLabel.Text = "";

        }



        private void DisplayCards(int[] userCard, List<Spot> userSpots, int[] compCard, List<Spot> compSpot)
        {
            gameContinue = counter > 0;
            for (int i = 0; i < userCard.Length; i++)
            {
                userSpots[i].itemNumber = userCard[i];
                userSpots[i].picturBox.Image = Image.FromFile(images[userCard[i]]);
                cardCountLabel.Text = "Cards Left: " + counter;
            }

            for (int i = 0; i < compCard.Length; i++)
            {
                compSpots[i].itemNumber = compCard[i];
                compSpots[i].picturBox.Image = Image.FromFile(images[compCard[i]]);
                cardCountLabel.Text = "Cards Left: " + counter;
            }
            if (!gameContinue || counter == 0)
            {
                doneLabel.Text = "Completed! Play Again???";
                ShowBestScore();
            }

        }

        private void DisplayNextCards()
        {
            if (gameContinue && counter != 0)
            {
                counter--;

                userCard = compCard;
                compCard = game.Deck.Pop();
                DisplayCards(userCard, userSpots, compCard, compSpots);

            }

        }

        private bool isCorrectMatch(int[] userCard, int[] compCard, PictureBox picture)
        {
            var imageNumber = userSpots.Where(s => s.picturBox.Equals(picture)).Select(s => s.itemNumber);
            return game.SpotMatch(imageNumber.FirstOrDefault(), userCard, compCard);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (isCorrectMatch(userCard, compCard, pictureBox1) && gameContinue)
                DisplayNextCards();
            gameContinue = game.Deck.Count != 0;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (isCorrectMatch(userCard, compCard, pictureBox2) && gameContinue)
                DisplayNextCards();
            gameContinue = game.Deck.Count != 0;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (isCorrectMatch(userCard, compCard, pictureBox3) && gameContinue)
                DisplayNextCards();
            gameContinue = game.Deck.Count != 0;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (isCorrectMatch(userCard, compCard, pictureBox4) && gameContinue)
                DisplayNextCards();
            gameContinue = game.Deck.Count != 0;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (isCorrectMatch(userCard, compCard, pictureBox5) && gameContinue)
                DisplayNextCards();
            gameContinue = game.Deck.Count != 0;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (isCorrectMatch(userCard, compCard, pictureBox6) && gameContinue)
                DisplayNextCards();
            gameContinue = game.Deck.Count != 0;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (isCorrectMatch(userCard, compCard, pictureBox7) && gameContinue)
                DisplayNextCards();
            gameContinue = game.Deck.Count != 0;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (isCorrectMatch(userCard, compCard, pictureBox8) && gameContinue)
                DisplayNextCards();
            gameContinue = game.Deck.Count != 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (gameContinue && counter != 0)
            {
                TimeSecLabel.Text = "Seconds: " + ++timeSec;
                if (timeSec >= 60)
                {
                    TimeMinLabel.Text = "Minute: " + ++timeMin;
                    TimeSecLabel.Text = "Seconds: " + (timeSec = 0);
                }
            }
        }

        private void ShowBestScore()
        {
            if (timeMin < bestTimeMin || (timeMin == bestTimeMin && (timeSec < bestTimeSec)))
            {
                bestTimeMin = timeMin;
                bestTimeSec = timeSec;
                BestScore.Text = " Minute: " + bestTimeMin + " Second: " + bestTimeSec;
            }

            timeSec = 0;
            timeMin = 0;
        }

    }
}