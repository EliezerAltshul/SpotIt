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
    class Spot
    {
        public PictureBox picturBox { get; set; }
        public int itemNumber { get; set; }

        public Spot(PictureBox picturBox, int num)
        {
            this.picturBox = picturBox;
            itemNumber = num;
        }


    }
}
