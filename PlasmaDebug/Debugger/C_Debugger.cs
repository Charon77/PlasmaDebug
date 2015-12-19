using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlasmaDebug.Debugger
{
    class C_Debugger : IDebugger
    {

        Process _processGDB;
        ProcessStartInfo _gdbStartInfo = new ProcessStartInfo();

        private Object thisLock = new Object();

        StreamWriter _streamWriter;
        StreamReader _streamReader;

        Queue<string> _readQueue;

        Task t;
        private int _processID;

        private bool _user_wanted_break = false;

        public void Start()
        {
            #region Setting Parameters for GDB
            _gdbStartInfo = new ProcessStartInfo();
            _gdbStartInfo.FileName = "gdb.exe";
            _gdbStartInfo.Arguments = "--quiet"; //No version info
            _gdbStartInfo.UseShellExecute = false; //Why?
            _gdbStartInfo.RedirectStandardOutput = true;
            _gdbStartInfo.RedirectStandardInput = true;
            _gdbStartInfo.RedirectStandardError = true;
            _gdbStartInfo.CreateNoWindow = true;
            #endregion

            //Starts GDB process
            _processGDB = Process.Start(_gdbStartInfo);

            _streamWriter = _processGDB.StandardInput;
            _streamReader = _processGDB.StandardOutput;


            _readQueue = new Queue<string>();

            if (t == null)
            {
                t = Task.Run(() => { _ReadAndQueueTask(); });
            }

        }

        public void Attach(int processID)
        {
            
            _processID = processID;
            SendInput("attach " + _processID);
            ReadOutput(); // wait for continue
        }


        public void Detach()
        {
            SendInput("detach");
            ReadOutput(); // wait for continue
            _processGDB.Kill();
            _processID = 0;
        }

        public void Stop()
        {
            t.Dispose();
            _processGDB.Kill();
        }



        public void SendInput(string Command)
        {
            _streamWriter.WriteLine(Command);
        }

        


        //TODO: Async?
        public string ReadOutput()
        {
            int LastQueueCount = _readQueue.Count;
            
            int timeout=DateTime.Now.Millisecond;
            while (_readQueue.Count == 0) {
                //Debug.WriteLine(DateTime.Now.Millisecond-timeout);
                if(DateTime.Now.Millisecond - timeout>60)
                {
                    break;
                }
            }

            while(true)
            {
                Thread.Sleep(10);
                if (LastQueueCount==_readQueue.Count)
                {
                    break;
                }
                else
                {
                    LastQueueCount = _readQueue.Count;
                }
                    
            }

            if(_readQueue.Count>0)
            {
                string s = "";
                while(_readQueue.Count>0)
                {
                    s+= _readQueue.Dequeue();
                    s += "\n";
                }
                return s;
            }
            else
            {
                return "";
            }
        }


        void BreakAllLines()
        {
            //SendInput("rbreak ^[^_]");

            //All lines
            int i;
            for(i=0;i<100;i++)
            {
                SendInput("break " + i);
            }

            ReadOutput();
        }

        void DeleteAllBreakpoints()
        {
            SendInput("delete");
            Console.WriteLine(ReadOutput());
        }

        public void Continue()
        {
            BreakAllLines();
            _user_wanted_break = false;

            Task.Run(() =>
            {
                while(true)
                {
                    if(!_user_wanted_break)
                    {
                        SendInput("continue 1");
                        Console.WriteLine(ReadOutput());
                        Thread.Sleep(10);
                    }
                    else
                    {
                        _user_wanted_break = false;
                        break;
                    }
                }

            });


            
        }

        public void Break()
        {
            _user_wanted_break = true;
            DeleteAllBreakpoints();
            //SendInput("return");
            //ReadOutput();
        }


        #region Private Methods
        // Function to be run on other thread
        private void _ReadAndQueueTask()
        {
            while (true)
            {
                string s = _streamReader.ReadLine();
                if (s!=null && s.Length > 0)
                {
                    _readQueue.Enqueue(s);
                }
            }
        }



        #endregion
    }
}
