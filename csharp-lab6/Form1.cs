using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_6_CSHARP
{
    public partial class Form1 : Form
    {
        delegate void setValue(int value);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread t1 = new Thread(new ParameterizedThreadStart(workingThread));
            Thread t2 = new Thread(new ParameterizedThreadStart(workingThread));
            t1.Start(25);
            t2.Start(75);
        }
        
        private void workingThread(object obj)
        {
            int val = (int)obj;
            for (int i = 0; i < 10000; i++)
            {
                trackBar1.Invoke(new setValue(s => trackBar1.Value = s), val);
                
                label2.Text = Convert.ToString(trackBar1.Value);
                Thread.Sleep(100);
            }
        }
    }
}
