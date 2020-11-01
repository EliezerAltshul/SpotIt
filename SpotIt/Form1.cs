using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotIt
{
    public partial class Form1 : Form
    {
        static int[] arr = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                         11, 12, 13, 14, 15, 16, 17, 18,
                         19, 20, 21};
        static Game game = new Game(arr);
        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.ListBox1 = new System.Windows.Forms.Label();
            this.ListBox2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.InputButton = new System.Windows.Forms.Button();
            this.Conformation = new System.Windows.Forms.Label();
            this.ListLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 29);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(165, 335);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // listView2
            // 
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(202, 29);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(165, 335);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // ListBox1
            // 
            this.ListBox1.AutoSize = true;
            this.ListBox1.Location = new System.Drawing.Point(12, 9);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(42, 17);
            this.ListBox1.TabIndex = 2;
            this.ListBox1.Text = "List 1";
            // 
            // ListBox2
            // 
            this.ListBox2.AutoSize = true;
            this.ListBox2.Location = new System.Drawing.Point(321, 9);
            this.ListBox2.Name = "ListBox2";
            this.ListBox2.Size = new System.Drawing.Size(42, 17);
            this.ListBox2.TabIndex = 3;
            this.ListBox2.Text = "List 2";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(183, 370);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 4;
            // 
            // InputButton
            // 
            this.InputButton.Location = new System.Drawing.Point(102, 369);
            this.InputButton.Name = "InputButton";
            this.InputButton.Size = new System.Drawing.Size(75, 23);
            this.InputButton.TabIndex = 5;
            this.InputButton.Text = "Confirm";
            this.InputButton.UseVisualStyleBackColor = true;
            // 
            // Conformation
            // 
            this.Conformation.AutoSize = true;
            this.Conformation.Location = new System.Drawing.Point(180, 395);
            this.Conformation.Name = "Conformation";
            this.Conformation.Size = new System.Drawing.Size(0, 17);
            this.Conformation.TabIndex = 6;
            // 
            // ListLabel
            // 
            this.ListLabel.AutoSize = true;
            this.ListLabel.Location = new System.Drawing.Point(373, 29);
            this.ListLabel.Name = "ListLabel";
            this.ListLabel.Size = new System.Drawing.Size(0, 17);
            this.ListLabel.TabIndex = 7;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(670, 442);
            this.Controls.Add(this.ListLabel);
            this.Controls.Add(this.Conformation);
            this.Controls.Add(this.InputButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ListBox2);
            this.Controls.Add(this.ListBox1);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int count = 0;
            foreach (int[] card in game.Deck)
            {
                count++;
                ListLabel.Text += ("\nCard " + count + ": ");
                foreach (int elem in card)
                    ListLabel.Text += (elem + ", ");
            }

        }
    }
}