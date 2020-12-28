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
        static int bestTimeMin = Int32.MaxValue, bestTimeSec = Int32.MaxValue;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PlayButton = new System.Windows.Forms.Button();
            this.CompCard = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox6Comp = new System.Windows.Forms.PictureBox();
            this.pictureBox5Comp = new System.Windows.Forms.PictureBox();
            this.pictureBox4Comp = new System.Windows.Forms.PictureBox();
            this.pictureBox1Comp = new System.Windows.Forms.PictureBox();
            this.pictureBox2Comp = new System.Windows.Forms.PictureBox();
            this.pictureBox3Comp = new System.Windows.Forms.PictureBox();
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
            this.CompCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6Comp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5Comp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4Comp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1Comp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2Comp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3Comp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            // CompCard
            // 
            this.CompCard.ColumnCount = 3;
            this.CompCard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.CompCard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.CompCard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.CompCard.Controls.Add(this.pictureBox6Comp, 2, 1);
            this.CompCard.Controls.Add(this.pictureBox5Comp, 1, 1);
            this.CompCard.Controls.Add(this.pictureBox4Comp, 0, 1);
            this.CompCard.Controls.Add(this.pictureBox1Comp, 0, 0);
            this.CompCard.Controls.Add(this.pictureBox2Comp, 1, 0);
            this.CompCard.Controls.Add(this.pictureBox3Comp, 2, 0);
            this.CompCard.Location = new System.Drawing.Point(696, 147);
            this.CompCard.Name = "CompCard";
            this.CompCard.RowCount = 2;
            this.CompCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.CompCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.CompCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.CompCard.Size = new System.Drawing.Size(300, 200);
            this.CompCard.TabIndex = 4;
            // 
            // pictureBox6Comp
            // 
            this.pictureBox6Comp.Location = new System.Drawing.Point(202, 103);
            this.pictureBox6Comp.Name = "pictureBox6Comp";
            this.pictureBox6Comp.Size = new System.Drawing.Size(93, 93);
            this.pictureBox6Comp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6Comp.TabIndex = 5;
            this.pictureBox6Comp.TabStop = false;
            // 
            // pictureBox5Comp
            // 
            this.pictureBox5Comp.Location = new System.Drawing.Point(102, 103);
            this.pictureBox5Comp.Name = "pictureBox5Comp";
            this.pictureBox5Comp.Size = new System.Drawing.Size(93, 93);
            this.pictureBox5Comp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5Comp.TabIndex = 4;
            this.pictureBox5Comp.TabStop = false;
            // 
            // pictureBox4Comp
            // 
            this.pictureBox4Comp.Location = new System.Drawing.Point(3, 103);
            this.pictureBox4Comp.Name = "pictureBox4Comp";
            this.pictureBox4Comp.Size = new System.Drawing.Size(93, 93);
            this.pictureBox4Comp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4Comp.TabIndex = 3;
            this.pictureBox4Comp.TabStop = false;
            // 
            // pictureBox1Comp
            // 
            this.pictureBox1Comp.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1Comp.Name = "pictureBox1Comp";
            this.pictureBox1Comp.Size = new System.Drawing.Size(93, 94);
            this.pictureBox1Comp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1Comp.TabIndex = 0;
            this.pictureBox1Comp.TabStop = false;
            // 
            // pictureBox2Comp
            // 
            this.pictureBox2Comp.Location = new System.Drawing.Point(102, 3);
            this.pictureBox2Comp.Name = "pictureBox2Comp";
            this.pictureBox2Comp.Size = new System.Drawing.Size(93, 93);
            this.pictureBox2Comp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2Comp.TabIndex = 1;
            this.pictureBox2Comp.TabStop = false;
            // 
            // pictureBox3Comp
            // 
            this.pictureBox3Comp.Location = new System.Drawing.Point(202, 3);
            this.pictureBox3Comp.Name = "pictureBox3Comp";
            this.pictureBox3Comp.Size = new System.Drawing.Size(93, 93);
            this.pictureBox3Comp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3Comp.TabIndex = 2;
            this.pictureBox3Comp.TabStop = false;
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
            this.doneLabel.Size = new System.Drawing.Size(200, 20);
            this.doneLabel.TabIndex = 12;
            // 
            // cardCountLabel
            // 
            this.cardCountLabel.AutoSize = true;
            this.cardCountLabel.Location = new System.Drawing.Point(463, 15);
            this.cardCountLabel.MinimumSize = new System.Drawing.Size(100, 0);
            this.cardCountLabel.Name = "cardCountLabel";
            this.cardCountLabel.Size = new System.Drawing.Size(100, 20);
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
            this.TimeMinLabel.Size = new System.Drawing.Size(50, 20);
            this.TimeMinLabel.TabIndex = 15;
            // 
            // TimeSecLabel
            // 
            this.TimeSecLabel.AutoSize = true;
            this.TimeSecLabel.Location = new System.Drawing.Point(951, 23);
            this.TimeSecLabel.MinimumSize = new System.Drawing.Size(50, 0);
            this.TimeSecLabel.Name = "TimeSecLabel";
            this.TimeSecLabel.Size = new System.Drawing.Size(50, 20);
            this.TimeSecLabel.TabIndex = 16;
            // 
            // BestScore
            // 
            this.BestScore.AutoSize = true;
            this.BestScore.Location = new System.Drawing.Point(801, 40);
            this.BestScore.MinimumSize = new System.Drawing.Size(200, 0);
            this.BestScore.Name = "BestScore";
            this.BestScore.Size = new System.Drawing.Size(200, 20);
            this.BestScore.TabIndex = 17;
            this.BestScore.Text = "Best Score:";
            this.BestScore.Click += new System.EventHandler(this.BestScore_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1182, 628);
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
            this.Controls.Add(this.CompCard);
            this.Controls.Add(this.PlayButton);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.CompCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6Comp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5Comp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4Comp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1Comp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2Comp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3Comp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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

            compSpots.Add(new Spot(this.pictureBox1Comp, -1));
            compSpots.Add(new Spot(this.pictureBox2Comp, -1));
            compSpots.Add(new Spot(this.pictureBox3Comp, -1));
            compSpots.Add(new Spot(this.pictureBox4Comp, -1));
            compSpots.Add(new Spot(this.pictureBox5Comp, -1));
            compSpots.Add(new Spot(this.pictureBox6Comp, -1));

        }

        private  void PlayButton_ClickAsync(object sender, EventArgs e)
        {
            game = new Game(6, images);
            gameContinue = true;
            
            counter = game.elems.Length-3;

            userCard = game.Deck.Pop();

            DisplayCards(userCard, userSpots);

            compCard = game.Deck.Pop();

            DisplayCards(compCard, compSpots);
            
        }

        

        private void DisplayCards(int[] card, List<Spot> spots)
        {
            gameContinue = counter > 0;
            for (int i = 0; i < card.Length; i++)
            {
                spots[i].itemNumber = card[i];
                spots[i].picturBox.Image = Image.FromFile(images[card[i]]);
                cardCountLabel.Text = "Cards Left: " + counter;
            }
            if (!gameContinue)
            {
                doneLabel.Text = "Completed! Play Again???";
                ShowBestScore();
            }
            
        }

        private void DisplayNextCards()
        {

            if (gameContinue)
            {
                counter--;

                userCard = compCard;
                DisplayCards(userCard, userSpots);

                compCard = game.Deck.Pop();
                DisplayCards(compCard, compSpots);
            }
           
        }

        private bool isCorrectMatch(int[] userCard, int[] compCard, PictureBox picture)
        {
            var imageNumber = userSpots.Where(s => s.picturBox.Equals(picture)).Select(s => s.itemNumber);
            return game.SpotMatch(imageNumber.FirstOrDefault(), userCard, compCard);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(isCorrectMatch(userCard, compCard, pictureBox1) && gameContinue)
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

        private void BestScore_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (gameContinue)
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
            if(timeMin < bestTimeMin || (timeMin == bestTimeMin && (timeSec < bestTimeSec)))
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