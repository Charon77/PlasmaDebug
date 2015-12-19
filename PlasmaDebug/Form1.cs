using PlasmaDebug.Debugger;
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
        IDebugger debugger;


        public Form1()
        {
            
            InitializeComponent();
            debugger = new C_Debugger();
            debugger.Start();

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData==Keys.Enter)
            {
                debugger.SendInput(textBox1.Text);
                textBox1.Clear();
                Console.WriteLine(debugger.ReadOutput());
            }
        }

        

        private void cmdContinue_Click(object sender, EventArgs e)
        {
            debugger.Continue();
        }

        private void cmdBreak_Click(object sender, EventArgs e)
        {
            debugger.Break();
        }

        private void cmdAttach_Click(object sender, EventArgs e)
        {
            int pid;
            int.TryParse(txtPID.Text, out pid);
            debugger.Attach(pid);
        }

    }
}
