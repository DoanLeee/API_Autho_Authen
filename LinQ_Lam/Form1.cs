using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinQ_Lam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      

        private void Form1_Load(object sender, EventArgs e)
        {
            int[] Numbers = { 1, 2, 3, 4, 20, 30, 40 };
            var resul1t = Numbers.Select(x => Math.Sqrt(x)).ToList();

            //anonymous type
            var result2 = Numbers.Select(x => new
            {
                Numbers = x,
                Tincan = Math.Sqrt(x),
                Sin = Math.Sin(x),
                Cos = Math.Cos(x),
            }).ToList();

        }
    }
}
