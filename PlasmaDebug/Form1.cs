using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlasmaDebug
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Hi.");

            ProcessStartInfo _gdbStartInfo = new ProcessStartInfo();
            _gdbStartInfo.FileName = "gdb.exe";
            _gdbStartInfo.UseShellExecute = false; //Why?
            _gdbStartInfo.RedirectStandardOutput = true;
            _gdbStartInfo.RedirectStandardInput = true;
            _gdbStartInfo.RedirectStandardError = true;
            _gdbStartInfo.CreateNoWindow = true;
            Process p = Process.Start(_gdbStartInfo);

            StreamReader s = p.StandardOutput;

            string str = s.ReadLine();
            Console.WriteLine(str);




        }
    }
}
