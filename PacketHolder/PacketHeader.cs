using System;
using System.Collections;
using System.Linq;

namespace PacketHolder
{
    public class PacketHeader
    {
        public byte[] Binary
        {
            get
            {
                return
                   ConvertToByteArray(
                    ConvertToBinary(SourcePort),
                    ConvertToBinary(DestinationPort),
                    ConvertToBinary(SequenceNumber),
                    ConvertToBinary(AcknowledgementNumber),
                    //ConvertToBinary(SourcePort),
                    ConvertToBinary(WindowSize),
                    ConvertToBinary(Checksum),
                    ConvertToBinary(UrgentPointer),
                    ConvertToBinary(NoOperationPadding),
                    ConvertToBinary(MaxSegmentSize),
                    ConvertToBinary(WindowScale),
                    ConvertToBinary(SelectiveAcknowledgementPermitted),
                    ConvertToBinary(SourcePort),
                    ConvertToBinary(padding)
                     );
            }
           
        }

        private byte[] ConvertToByteArray(params BitArray[] Arrays)
        {
            int length = 0;
            int byteToWrite = 0;
            foreach (BitArray Array in Arrays)
            {
                length += Array.Length;
            }
            byte[] bytesToReturn = new byte[Convert.ToInt32(Math.Ceiling((double)length / 8))];//turn into function
            length = 0;

            foreach (BitArray bits in Arrays)
            {
                if (bits.Count  % 8 !=0 )
                {
                    throw new Exception("Your bit does not match size, thus your packet will be bad and you should feel bad");
                    
                }
                byteToWrite += bits.Count / 8;
                bits.CopyTo(bytesToReturn, byteToWrite);
             }
            return bytesToReturn;
        }

        public ushort SourcePort;
        //16 bits
        public ushort DestinationPort; //16 bits
        public uint SequenceNumber; //32 bits
        public int AcknowledgementNumber; //32 bits

        public OffSetReservedAndControlBits OffsetAndControl;
      
        public ushort WindowSize;//16
        public ushort Checksum;//16
        public ushort UrgentPointer;//16

        #region Options
        public Options Options;
      

        public uint padding;//32 bits

        #endregion
        public BitArray ConvertToBinary(uint value)
        {
            return ConvertToBinary<uint>(value);
        }
        public BitArray ConvertToBinary(ushort value)
        {
            return ConvertToBinary<ushort>(value);
        }
        public BitArray ConvertToBinary(sbyte value)
        {
            return ConvertToBinary<sbyte>(value);
        }
        private BitArray ConvertToBinary<T>(T value)
        {
            BitArray b = new BitArray(new byte[Convert.ToInt32(value)]);
            int[] bits = b.Cast<bool>().Select(bit => bit ? 1 : 0).ToArray();
            return b;
        }
    }
}