using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;


namespace Morpion
{
    class StateObject
    {
        public static Socket workSocket = null;
        public const int BufferSize = 1024;
        public static byte[] buffer = new byte[BufferSize];
        public StringBuilder sb = new StringBuilder();

    }
}
