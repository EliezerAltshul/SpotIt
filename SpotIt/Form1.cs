using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotIt
{
    public partial class Form1 : Form
    {

        static string[] images = System.IO.Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, @"png"), "*.png");
        static List<string> imageList = new List<string>();
        static PictureBox[] userPictures = new PictureBox[6];
        static PictureBox[] compPictures = new PictureBox[6];
        static Game game;
        static bool gameContinue = false;
        static int[] userCard;
        static int[] compCard;
        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.PlayButton = new System.Windows.Forms.Button();
            this.CompCard = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox6Comp = new System.Windows.Forms.PictureBox();
            this.pictureBox5Comp = new System.Windows.Forms.PictureBox();
            this.pictureBox4Comp = new System.Windows.Forms.PictureBox();
            this.pictureBox1Comp = new System.Windows.Forms.PictureBox();
            this.pictureBox2Comp = new System.Windows.Forms.PictureBox();
            this.pictureBox3Comp = new System.Windows.Forms.PictureBox();
            this.NextButton = new System.Windows.Forms.Button();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Label();
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
            this.PlayButton.Size = new System.Drawing.Size(75, 23);
            this.PlayButton.TabIndex = 2;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
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
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(257, 12);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(75, 23);
            this.NextButton.TabIndex = 5;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Location = new System.Drawing.Point(346, 250);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(93, 93);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 11;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(246, 250);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(93, 93);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 10;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(147, 250);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(93, 93);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 9;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(346, 150);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(93, 93);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(246, 150);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(93, 93);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(147, 150);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // timer
            // 
            this.timer.AutoSize = true;
            this.timer.Location = new System.Drawing.Point(338, 15);
            this.timer.Name = "timer";
            this.timer.Size = new System.Drawing.Size(0, 17);
            this.timer.TabIndex = 12;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1182, 628);
            this.Controls.Add(this.timer);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.NextButton);
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

            foreach (string image in images)
                imageList.Add(image);

            userPictures[0] = this.pictureBox1;
            userPictures[1] = this.pictureBox2;
            userPictures[2] = this.pictureBox3;
            userPictures[3] = this.pictureBox4;
            userPictures[4] = this.pictureBox5;
            userPictures[5] = this.pictureBox6;
            
            compPictures[0] = this.pictureBox1Comp;
            compPictures[1] = this.pictureBox2Comp;
            compPictures[2] = this.pictureBox3Comp;
            compPictures[3] = this.pictureBox4Comp;
            compPictures[4] = this.pictureBox5Comp;
            compPictures[5] = this.pictureBox6Comp;

        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            game = new Game(6);
            gameContinue = true;
            userCard = game.Deck.Pop();

            DisplayCards(userCard, userPictures);

            compCard = game.Deck.Pop();

            DisplayCards(compCard, compPictures);

        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if(gameContinue == true)
            {
                userCard = compCard;
                DisplayCards(userCard, userPictures);

                compCard = game.Deck.Pop();
                DisplayCards(compCard, compPictures);

                gameContinue = game.Deck.Count != 0;
            }
        }

        private void DisplayCards(int[] card, PictureBox[] pictures)
        {
            for (int i = 0; i < card.Length; i++)
            {
                pictures[i].Image = Image.FromFile(images[card[i]]);
            }
        }

        private void DisplayNextCards()
        {
            userCard = compCard;
            DisplayCards(userCard, userPictures);

            compCard = game.Deck.Pop();
            DisplayCards(compCard, compPictures);
        }

        private bool isCorrectMatch(int[] userCard, int[] compCard, PictureBox picture)
        {
            int imageNumber = imageList.IndexOf(picture.ImageLocation);
            return game.SpotMatch(imageNumber, userCard, compCard);
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
    }
}