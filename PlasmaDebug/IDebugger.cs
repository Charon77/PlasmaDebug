using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasmaDebug
{
    interface IDebugger
    {

        //Starts the debugger process
        void Start();

        //Stops the debugger process
        void Stop();

        void Attach(int processID);

        void Detach();

        void SendInput(string Command);

        String ReadOutput();
        void Continue();
        void Break();
    }
}
