using System;
using System.Collections;

namespace PacketHolder
{
    public class Options
    {
        public sbyte EndOfOptionsList; //8
        public sbyte NoOperationPadding; //8
        public uint MaxSegmentSize; //32
        public uint WindowScale; //24
        public ushort SelectiveAcknowledgementPermitted;
        //SACK andrew haaaalp

        public DateTime TimeStamp; // 80 bits
        public BitArray Bits
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}