using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerExam.Util
{
    public class DES
    {
        /// <summary>
        /// 初始值置IP
        /// </summary>
        public byte[] BitIP = 
             { 57, 49, 41, 33, 25, 17,  9,  1,
             59, 51, 43, 35, 27, 19, 11,  3,
             61, 53, 45, 37, 29, 21, 13,  5,
             63, 55, 47, 39, 31, 23, 15,  7,
             56, 48, 40, 32, 24, 16,  8,  0,
             58, 50, 42, 34, 26, 18, 10,  2,
             60, 52, 44, 36, 28, 20, 12,  4,
             62, 54, 46, 38, 30, 22, 14,  6};

        /// <summary>
        /// 逆初始置IP-1
        /// </summary>
        byte[] BitCP = 
                {39,  7, 47, 15, 55, 23, 63, 31,
              38,  6, 46, 14, 54, 22, 62, 30,
              37,  5, 45, 13, 53, 21, 61, 29,
              36,  4, 44, 12, 52, 20, 60, 28,
              35,  3, 43, 11, 51, 19, 59, 27,
              34,  2, 42, 10, 50, 18, 58, 26,
              33,  1, 41,  9, 49, 17, 57, 25,
              32,  0, 40,  8, 48, 16, 56, 24};

        /// <summary>
        /// 位选择函数E
        /// </summary>
        byte[] BitExp = 
        { 31, 0, 1, 2, 3, 4, 3, 4, 5, 6, 7, 8, 7, 8, 9,10,
      11,12,11,12,13,14,15,16,15,16,17,18,19,20,19,20,
      21,22,23,24,23,24,25,26,27,28,27,28,29,30,31,0};

        /// <summary>
        /// 置换函数P
        /// </summary>
        byte[] BitPM = 
        {15, 6,19,20,28,11,27,16, 0,14,22,25, 4,17,30, 9,
       1, 7,23,13,31,26, 2, 8,18,12,29, 5,21,10, 3,24 };

        /// <summary>
        /// S盒
        /// </summary>
        byte[,] sBox = 
        { { 14,  4, 13,  1,  2, 15, 11,  8,  3, 10,  6, 12,  5,  9,  0,  7,
         0, 15,  7,  4, 14,  2, 13,  1, 10,  6, 12, 11,  9,  5,  3,  8,
         4,  1, 14,  8, 13,  6,  2, 11, 15, 12,  9,  7,  3, 10,  5,  0,
        15, 12,  8,  2,  4,  9,  1,  7,  5, 11,  3, 14, 10,  0,  6, 13},
        {15,  1,  8, 14,  6, 11,  3,  4,  9,  7,  2, 13, 12,  0,  5, 10,
         3, 13,  4,  7, 15,  2,  8, 14, 12,  0,  1, 10,  6,  9, 11,  5,
         0, 14,  7, 11, 10,  4, 13,  1,  5,  8, 12,  6,  9,  3,  2, 15,
        13,  8, 10,  1,  3, 15,  4,  2, 11,  6,  7, 12,  0,  5, 14,  9},
        {10,  0,  9, 14,  6,  3, 15,  5,  1, 13, 12,  7, 11,  4,  2,  8,
        13,  7,  0,  9,  3,  4,  6, 10,  2,  8,  5, 14, 12, 11, 15,  1,
        13,  6,  4,  9,  8, 15,  3,  0, 11,  1,  2, 12,  5, 10, 14,  7,
         1, 10, 13,  0,  6,  9,  8,  7,  4, 15, 14,  3, 11,  5,  2, 12},
        {7, 13, 14,  3,  0,  6,  9, 10,  1,  2,  8,  5, 11, 12,  4, 15,
        13,  8, 11,  5,  6, 15,  0,  3,  4,  7,  2, 12,  1, 10, 14,  9,
        10,  6,  9,  0, 12, 11,  7, 13, 15,  1,  3, 14,  5,  2,  8,  4,
         3, 15,  0,  6, 10,  1, 13,  8,  9,  4,  5, 11, 12,  7,  2, 14},
        {2, 12,  4,  1,  7, 10, 11,  6,  8,  5,  3, 15, 13,  0, 14,  9,
        14, 11,  2, 12,  4,  7, 13,  1,  5,  0, 15, 10,  3,  9,  8,  6,
         4,  2,  1, 11, 10, 13,  7,  8, 15,  9, 12,  5,  6,  3,  0, 14,
        11,  8, 12,  7,  1, 14,  2, 13,  6, 15,  0,  9, 10,  4,  5,  3},
        {12,  1, 10, 15,  9,  2,  6,  8,  0, 13,  3,  4, 14,  7,  5, 11,
        10, 15,  4,  2,  7, 12,  9,  5,  6,  1, 13, 14,  0, 11,  3,  8,
         9, 14, 15,  5,  2,  8, 12,  3,  7,  0,  4, 10,  1, 13, 11,  6,
         4,  3,  2, 12,  9,  5, 15, 10, 11, 14,  1,  7,  6,  0,  8, 13},
        {4, 11,  2, 14, 15,  0,  8, 13,  3, 12,  9,  7,  5, 10,  6,  1,
        13,  0, 11,  7,  4,  9,  1, 10, 14,  3,  5, 12,  2, 15,  8,  6,
         1,  4, 11, 13, 12,  3,  7, 14, 10, 15,  6,  8,  0,  5,  9,  2,
         6, 11, 13,  8,  1,  4, 10,  7,  9,  5,  0, 15, 14,  2,  3, 12},
        {13,  2,  8,  4,  6, 15, 11,  1, 10,  9,  3, 14,  5,  0, 12,  7,
         1, 15, 13,  8, 10,  3,  7,  4, 12,  5,  6, 11,  0, 14,  9,  2,
         7, 11,  4,  1,  9, 12, 14,  2,  0,  6, 10, 13, 15,  3,  5,  8,
         2,  1, 14,  7,  4, 10,  8, 13, 15, 12,  9,  0,  3,  5,  6, 11}};

        /// <summary>
        /// 选择置换PC-1
        /// </summary>
        byte[] BitPMC1 = 
        {56, 48, 40, 32, 24, 16,  8,
       0, 57, 49, 41, 33, 25, 17,
       9,  1, 58, 50, 42, 34, 26,
      18, 10,  2, 59, 51, 43, 35,
      62, 54, 46, 38, 30, 22, 14,
       6, 61, 53, 45, 37, 29, 21,
      13,  5, 60, 52, 44, 36, 28,
      20, 12,  4, 27, 19, 11,  3};

        /// <summary>
        /// 选择置换PC-2
        /// </summary>
        byte[] BitPMC2 = 
        {13, 16, 10, 23,  0,  4,
       2, 27, 14,  5, 20,  9,
      22, 18, 11,  3, 25,  7,
      15,  6, 26, 19, 12,  1,
      40, 51, 30, 36, 46, 54,
      29, 39, 50, 44, 32, 47,
      43, 48, 38, 55, 33, 52,
      45, 41, 49, 35, 28, 31};

        byte[][] subKey = 
        {
            new byte[6],
            new byte[6],
            new byte[6],
            new byte[6],
            new byte[6],
            new byte[6],
            new byte[6],
            new byte[6],
            new byte[6],
            new byte[6],
            new byte[6],
            new byte[6],
            new byte[6],
            new byte[6],
            new byte[6],
            new byte[6]
        };

        private void initPermutation(ref byte[] inData)
        {
            byte[] newData = { 0, 0, 0, 0, 0, 0, 0, 0 };
            int i;
            for (i = 0; i < 64; i++)
                if ((inData[BitIP[i] >> 3] & (1 << (7 - (BitIP[i] & 0x07)))) != 0)
                    newData[i >> 3] = (byte)(newData[i >> 3] | (1 << (7 - (i & 0x07))));
            for (i = 0; i < 8; i++)
                inData[i] = newData[i];
        }

        private void conversePermutation(ref byte[] inData)
        {
            byte[] newData = { 0, 0, 0, 0, 0, 0, 0, 0 };
            int i;
            for (i = 0; i < 64; i++)
                if ((inData[BitCP[i] >> 3] & (1 << (7 - (BitCP[i] & 0x07)))) != 0)
                    newData[i >> 3] = (byte)(newData[i >> 3] | (1 << (7 - (i & 0x07))));
            for (i = 0; i < 8; i++)
                inData[i] = newData[i];
        }

        private void expand(byte[] inData, ref byte[] outData)
        {
            int i;
            for (i = 0; i < 5; i++)
                outData.SetValue((byte)0, i);
            for (i = 0; i < 48; i++)
                if ((inData[BitExp[i] >> 3] & (1 << (7 - (BitExp[i] & 0x07)))) != 0)
                    outData[i >> 3] = (byte)(outData[i >> 3] | (1 << (7 - (i & 0x07))));
        }

        private void permutation(ref byte[] inData)
        {
            byte[] newData = { 0, 0, 0, 0 };
            int i;
            for (i = 0; i < 32; i++)
                if ((inData[BitPM[i] >> 3] & (1 << (7 - (BitPM[i] & 0x07)))) != 0)
                    newData[i >> 3] = (byte)(newData[i >> 3] | (1 << (7 - (i & 0x07))));
            for (i = 0; i < 4; i++)
                inData[i] = newData[i];
        }

        private byte si(byte s, byte inbyte)
        {
            byte c;
            c = (byte)((inbyte & 0x20) | ((inbyte & 0x1e) >> 1) | ((inbyte & 0x01) << 4));
            return (byte)(sBox[s, c] & 0x0f);
        }

        private void permutationChoose1(byte[] inData, ref byte[] outData)
        {
            int i;
            for (i = 0; i < 6; i++)
                outData.SetValue((byte)0, i);
            for (i = 0; i < 56; i++)
                if ((inData[BitPMC1[i] >> 3] & (1 << (7 - (BitPMC1[i] & 0x07)))) != 0)
                    outData[i >> 3] = (byte)(outData[i >> 3] | (1 << (7 - (i & 0x07))));
        }

        private void permutationChoose2(byte[] inData, ref byte[] outData)
        {
            int i;
            for (i = 0; i < 5; i++)
                outData.SetValue((byte)0, i);
            for (i = 0; i < 48; i++)
                if ((inData[BitPMC2[i] >> 3] & (1 << (7 - (BitPMC2[i] & 0x07)))) != 0)
                    outData[i >> 3] = (byte)(outData[i >> 3] | (1 << (7 - (i & 0x07))));
        }

        private void cycleMove(ref byte[] inData, byte bitMove)
        {
            int i;
            for (i = 0; i < bitMove; i++)
            {
                inData[0] = (byte)((inData[0] << 1) | (inData[1] >> 7));
                inData[1] = (byte)((inData[1] << 1) | (inData[2] >> 7));
                inData[2] = (byte)((inData[2] << 1) | (inData[3] >> 7));
                inData[3] = (byte)((inData[3] << 1) | ((inData[0] & 0x10) >> 4));
                inData[0] = (byte)((inData[0] & 0x0f));
            }
        }

        private void makeKey(byte[] inKey, ref byte[][] outKey)
        {
            byte[] bitDisplace = { 1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1 };
            byte[] outData56 = new byte[7];
            byte[] key28l = new byte[4];
            byte[] key28r = new byte[4];
            byte[] key56o = new byte[7];
            int i;

            this.permutationChoose1(inKey, ref outData56);

            key28l[0] = (byte)(outData56[0] >> 4);
            key28l[1] = (byte)((outData56[0] << 4) | (outData56[1] >> 4));
            key28l[2] = (byte)((outData56[1] << 4) | (outData56[2] >> 4));
            key28l[3] = (byte)((outData56[2] << 4) | (outData56[3] >> 4));
            key28r[0] = (byte)(outData56[3] & 0x0f);
            key28r[1] = outData56[4];
            key28r[2] = outData56[5];
            key28r[3] = outData56[6];

            for (i = 0; i < 16; i++)
            {
                cycleMove(ref key28l, bitDisplace[i]);
                cycleMove(ref key28r, bitDisplace[i]);
                key56o[0] = (byte)((key28l[0] << 4) | (key28l[1] >> 4));
                key56o[1] = (byte)((key28l[1] << 4) | (key28l[2] >> 4));
                key56o[2] = (byte)((key28l[2] << 4) | (key28l[3] >> 4));
                key56o[3] = (byte)((key28l[3] << 4) | (key28r[0]));
                key56o[4] = key28r[1];
                key56o[5] = key28r[2];
                key56o[6] = key28r[3];
                this.permutationChoose2(key56o, ref outKey[i]);
            }
        }

        private void encry(byte[] inData, byte[] subKey, ref byte[] outData)
        {
            byte[] outBuf = new byte[6];
            byte[] buf = new byte[8];
            int i;

            this.expand(inData, ref outBuf);
            for (i = 0; i < 6; i++)
                outBuf[i] = (byte)(outBuf[i] ^ subKey[i]);
            buf[0] = (byte)(outBuf[0] >> 2);
            buf[1] = (byte)(((outBuf[0] & 0x03) << 4) | (outBuf[1] >> 4));
            buf[2] = (byte)(((outBuf[1] & 0x0f) << 2) | (outBuf[2] >> 6));
            buf[3] = (byte)(outBuf[2] & 0x3f);
            buf[4] = (byte)(outBuf[3] >> 2);
            buf[5] = (byte)(((outBuf[3] & 0x03) << 4) | (outBuf[4] >> 4));
            buf[6] = (byte)(((outBuf[4] & 0x0f) << 2) | (outBuf[5] >> 6));
            buf[7] = (byte)(outBuf[5] & 0x3f);
            for (i = 0; i < 8; i++) buf[i] = this.si((byte)i, buf[i]);
            for (i = 0; i < 4; i++) outBuf[i] = (byte)((buf[i * 2] << 4) | buf[i * 2 + 1]);
            this.permutation(ref outBuf);
            for (i = 0; i < 4; i++) outData[i] = outBuf[i];
        }

        private void desData(TDesMode desMode, byte[] inData, ref byte[] outData)
        {
            int i, j;
            byte[] temp = new byte[4];
            byte[] buf = new byte[4];
            for (i = 0; i < 8; i++) outData[i] = inData[i];
            this.initPermutation(ref outData);
            if (desMode == TDesMode.dmEncry)
            {
                for (i = 0; i < 16; i++)
                {
                    for (j = 0; j < 4; j++) temp[j] = outData[j];
                    for (j = 0; j < 4; j++) outData[j] = outData[j + 4];
                    this.encry(outData, subKey[i], ref buf);
                    for (j = 0; j < 4; j++) outData[j + 4] = (byte)(temp[j] ^ buf[j]);
                }

                for (j = 0; j < 4; j++) temp[j] = outData[j + 4];
                for (j = 0; j < 4; j++) outData[j + 4] = outData[j];
                for (j = 0; j < 4; j++) outData[j] = temp[j];
            }
            else if (desMode == TDesMode.dmDecry)
            {
                for (i = 15; i >= 0; i--)
                {
                    for (j = 0; j < 4; j++) temp[j] = outData[j];
                    for (j = 0; j < 4; j++) outData[j] = outData[j + 4];
                    this.encry(outData, subKey[i], ref buf);
                    for (j = 0; j < 4; j++) outData[j + 4] = (byte)(temp[j] ^ buf[j]);
                }

                for (j = 0; j < 4; j++) temp[j] = outData[j + 4];
                for (j = 0; j < 4; j++) outData[j + 4] = outData[j];
                for (j = 0; j < 4; j++) outData[j] = temp[j];
            }
            this.conversePermutation(ref outData);
        }

        public static byte[] EncryStr(byte[] str, byte[] Key)
        {
            byte[] StrByte = new byte[8];
            byte[] OutByte = new byte[8];
            byte[] KeyByte = { 0, 0, 0, 0, 0, 0, 0, 0 };
            byte[] StrResult = new byte[] { };
            int i, j;
            DES des = new DES();

            if ((str.Length > 0) && (int)(str[str.Length - 1]) == 0)
                throw new Exception("Error: the last char is NULL char.");

            if (str.Length % 8 != 0)
            {
                int sLength = str.Length;
                Array.Resize<byte>(ref str, str.Length + (8 - str.Length % 8));
                for (i = 0; i < 8 - sLength % 8; i++)
                    str[sLength + i] = 0;
            }

            for (j = 0; j < Key.Length; j++)
            {
                if (j >= 8) break;
                KeyByte[j] = Key[j];
            }
            des.makeKey(KeyByte, ref des.subKey);

            for (i = 0; i < str.Length / 8; i++)
            {
                for (j = 0; j < 8; j++)
                    StrByte[j] = str[i * 8 + j];
                des.desData(TDesMode.dmEncry, StrByte, ref OutByte);
                //StrResult = StrResult + Encoding.ASCII.GetString(OutByte);
                Array.Resize<byte>(ref StrResult, StrResult.Length + OutByte.Length);
                OutByte.CopyTo(StrResult, StrResult.Length - OutByte.Length);
            }

            return StrResult;
        }

        public static byte[] EncryStr(string str, string Key)
        {
            byte[] byStr = Encoding.Default.GetBytes(str);
            byte[] byKey = Encoding.Default.GetBytes(Key);
            return EncryStr(byStr, byKey);
        }

        public static byte[] DecryStr(byte[] Str, byte[] Key)
        {
            byte[] StrByte = new byte[8];
            byte[] OutByte = new byte[8];
            byte[] KeyByte = { 0, 0, 0, 0, 0, 0, 0, 0 };
            byte[] StrResult = new byte[] { };
            int i, j;
            DES des = new DES();

            if (Str.Length % 8 != 0)
                for (i = 0; i < 8 - Str.Length % 8; i++)
                    Str[i] = 0;

            for (j = 0; j < Key.Length; j++)
            {
                if (j >= 8) break;
                KeyByte[j] = Key[j];
            }
            des.makeKey(KeyByte, ref des.subKey);

            for (i = 0; i < Str.Length / 8; i++)
            {
                for (j = 0; j < 8; j++)
                    StrByte[j] = Str[i * 8 + j];
                des.desData(TDesMode.dmDecry, StrByte, ref OutByte);
                //StrResult = StrResult + Encoding.ASCII.GetString(OutByte);
                Array.Resize<byte>(ref StrResult, StrResult.Length + OutByte.Length);
                OutByte.CopyTo(StrResult, StrResult.Length - OutByte.Length);
            }
            while ((StrResult.Length > 0) && ((int)StrResult[StrResult.Length - 1] == 0))
                Array.Resize<byte>(ref StrResult, StrResult.Length - 1);

            return StrResult;
        }

        public static string DecryStr(byte[] str, string Key)
        {
            //byte[] byStr = Encoding.Default.GetBytes(str);
            byte[] byKey = Encoding.Default.GetBytes(Key);
            return Encoding.ASCII.GetString(DecryStr(str, byKey));
        }

        public static string EncryStrHex(string Str, string Key)
        {
            string StrResult, Temp;// TempResult,
            int i;

            byte[] byEncStr = EncryStr(Str, Key);
            StrResult = "";
            for (i = 0; i < byEncStr.Length; i++)
            {
                Temp = string.Format("{0:x}", byEncStr[i]);
                if (Temp.Length == 1)
                    Temp = "0" + Temp;
                StrResult = StrResult + Temp;
            }

            return StrResult.ToUpper();
        }

        public static string DecryStrHex(string StrHex, string Key)
        {
            string Temp;// Str,
            int i;
            byte[] byTemp = new byte[StrHex.Length / 2];

            //Str = "";
            for (i = 0; i < StrHex.Length / 2; i++)
            {
                Temp = StrHex.Substring(i * 2, 2);
                byTemp[i] = (byte)HexToInt(Temp);
            }
            //Str = Encoding.ASCII.GetString(byTemp);

            return DecryStr(byTemp, Key);
        }

        public static int HexToInt(string Hex)
        {
            int i, Res;
            byte by;

            byte[] byHex = Encoding.ASCII.GetBytes(Hex);

            Res = 0;
            for (i = 0; i < Hex.Length; i++)
            {
                by = byHex[i];
                if ((by >= 0x30) && (by <= 0x39))
                    Res = Res * 16 + by - 0x30;
                else if ((by >= Encoding.ASCII.GetBytes("A")[0]) && (by <= Encoding.ASCII.GetBytes("F")[0]))
                    Res = Res * 16 + by - Encoding.ASCII.GetBytes("A")[0] + 10;
                else if ((by >= Encoding.ASCII.GetBytes("a")[0]) && (by <= Encoding.ASCII.GetBytes("f")[0]))
                    Res = Res * 16 + by - Encoding.ASCII.GetBytes("a")[0] + 10;
                else
                    throw new Exception("Error: not a Hex String");
            }

            return Res;
        }

        public static string EncryStrHexUTF8(string Str, string Key)
        {
            string StrResult, Temp;//TempResult, 
            int i;

            byte[] byStr = Encoding.Default.GetBytes(Str);
            byStr = Encoding.Convert(Encoding.Default, Encoding.UTF8, byStr);

            byte[] byKey = Encoding.Default.GetBytes(Key);
            byKey = Encoding.Convert(Encoding.Default, Encoding.UTF8, byKey);

            StrResult = "";
            byte[] byTR = EncryStr(byStr, byKey);

            for (i = 0; i < byTR.Length; i++)
            {
                Temp = string.Format("{0:x}", (int)byTR[i]);
                if (Temp.Length == 1) Temp = "0" + Temp;
                StrResult = StrResult + Temp;
            }
            return StrResult.ToUpper();
        }

        public static string DecryStrHexUTF8(string StrHex, string Key)
        {
            string Temp;
            int i;
            byte[] byTemp = new byte[StrHex.Length / 2];

            for (i = 0; i < StrHex.Length / 2; i++)
            {
                Temp = StrHex.Substring(i * 2, 2);
                byTemp[i] = (byte)HexToInt(Temp);
            }

            byte[] byKey = Encoding.Default.GetBytes(Key);
            byKey = Encoding.Convert(Encoding.Default, Encoding.UTF8, byKey);

            //return HttpUtility.UrlDecode(DES.DecryStr(byTemp, byKey), Encoding.UTF8);
            return Encoding.UTF8.GetString(DES.DecryStr(byTemp, byKey));
        }
    }

    public enum TDesMode
    {
        dmEncry, dmDecry
    }
}
