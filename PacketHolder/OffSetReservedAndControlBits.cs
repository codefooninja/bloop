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
                ushort value = 0;
                PlaceAndShift(ref value, Convert.ToUInt16(DataOffSet), 4);
                PlaceAndShift(ref value, Convert.ToUInt16(Reserved), 3);
                PlaceAndShift(ref value, Convert.ToUInt16(NS), 1);
                PlaceAndShift(ref value, Convert.ToUInt16(CWR), 1);
                PlaceAndShift(ref value, Convert.ToUInt16(ECE), 1);
                PlaceAndShift(ref value, Convert.ToUInt16(URG), 1);
                PlaceAndShift(ref value, Convert.ToUInt16(ACK), 1);
                PlaceAndShift(ref value, Convert.ToUInt16(PSH), 1);
                PlaceAndShift(ref value, Convert.ToUInt16(RST), 1);
                PlaceAndShift(ref value, Convert.ToUInt16(SYN), 1);
                PlaceAndShift(ref value, Convert.ToUInt16(FIN), 1);

                return new PacketHeader().ConvertToBinary(value);



            }
        }
        private void PlaceAndShift(ref ushort value, ushort data,ushort size)
        {
            data = Convert.ToUInt16(data & (TwoPowX(size)));//clear out any bits that may not be valid
            value = Convert.ToUInt16(size << value); //shift left size
            value = Convert.ToUInt16(value | data);//insert value into binary


        }
        public int TwoPowX(int power)
        {
            return (1 << power);
        }
    }
}