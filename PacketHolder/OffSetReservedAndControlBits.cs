using System;
using System.Collections;

namespace PacketHolder
{
    public class OffSetReservedAndControlBits
    {
        public sbyte DataOffSet; // 4 bits
        public sbyte Reserved;// 3 bits
        #region Control Bits // 9 bits
        public bool NS;
        public bool CWR;
        public bool ECE;
        public bool URG;
        public bool ACK;
        public bool PSH;
        public bool RST;
        public bool SYN;
        public bool FIN;
        #endregion
        public BitArray bits
        {
            get
            {
                throw new NotImplementedException();    
            }
        }
    }
}