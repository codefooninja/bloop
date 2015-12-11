using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketHolder
{
    public class PacketHolder<T>
    {
        public PacketHeader Header;
        public PacketBody<T> Body;
    }
}
