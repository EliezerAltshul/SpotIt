using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotIt
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                           11, 12, 13, 14, 15, 16, 17, 18,
                           19, 20, 21};
            Game game = new Game(nums);

            int i = 0;
            foreach (int[] card in game.Deck)
            {
                i++;
                foreach (int num in card)
                    Console.Write(i + ": " + num + ", ");
                Console.WriteLine();
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
