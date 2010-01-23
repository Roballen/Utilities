using System;
using System.Text;

namespace Utilities
{
    /// <summary>
    /// Clipper backward compatible encryption class
    /// </summary>
    public class CCrypto
    {
        private readonly int[] CryptoDecode = {
                                                  189, 57, 147, 251, 73, 166, 149, 187, 220, 196, 28, 211, 114, 68, 190, 105,
                                                  155, 206, 9, 185, 198, 172, 213, 127, 239, 217, 224, 133, 193, 99, 203, 205,
                                                  250, 42, 178, 160, 5, 122, 89, 97, 32, 63, 53, 44, 22, 4, 37, 106,
                                                  61, 56, 180, 62, 177, 96, 163, 231, 151, 51, 81, 248, 191, 14, 176, 168,
                                                  49, 245, 221, 225, 104, 170, 154, 16, 209, 158, 91, 7, 216, 60, 19, 80,
                                                  88, 159, 26, 78, 142, 11, 79, 52, 143, 109, 212, 229, 102, 8, 43, 115,
                                                  66, 36, 95, 125, 195, 31, 146, 162, 222, 194, 38, 253, 218, 165, 67, 55,
                                                  119, 72, 235, 186, 152, 247, 0, 3, 77, 124, 254, 40, 100, 113, 204, 215,
                                                  214, 128, 29, 90, 112, 93, 39, 135, 71, 199, 86, 50, 238, 18, 85, 157,
                                                  41, 15, 69, 123, 230, 120, 240, 134, 45, 87, 48, 226, 75, 126, 167, 161,
                                                  223, 64, 234, 46, 117, 25, 219, 130, 13, 116, 255, 233, 58, 12, 242, 111,
                                                  47, 227, 252, 201, 107, 207, 30, 131, 110, 174, 1, 10, 94, 108, 6, 121,
                                                  33, 202, 23, 76, 118, 150, 210, 35, 183, 59, 232, 164, 92, 181, 200, 138,
                                                  24, 65, 136, 17, 27, 188, 137, 101, 98, 2, 192, 132, 141, 241, 171, 70,
                                                  54, 34, 103, 148, 169, 129, 182, 153, 236, 246, 179, 244, 21, 74, 145, 20,
                                                  237, 139, 156, 184, 82, 249, 144, 175, 197, 173, 208, 243, 83, 140, 228, 84
                                              };

        private readonly int[] CryptoEncode = {
                                                  118, 186, 217, 119, 45, 36, 190, 75, 93, 18, 187, 85, 173, 168, 61, 145,
                                                  71, 211, 141, 78, 239, 236, 44, 194, 208, 165, 82, 212, 10, 130, 182, 101,
                                                  40, 192, 225, 199, 97, 46, 106, 134, 123, 144, 33, 94, 43, 152, 163, 176,
                                                  154, 64, 139, 57, 87, 42, 224, 111, 49, 1, 172, 201, 77, 48, 51, 41,
                                                  161, 209, 96, 110, 13, 146, 223, 136, 113, 4, 237, 156, 195, 120, 83, 86,
                                                  79, 58, 244, 252, 255, 142, 138, 153, 80, 38, 131, 74, 204, 133, 188, 98,
                                                  53, 39, 216, 29, 124, 215, 92, 226, 68, 15, 47, 180, 189, 89, 184, 175,
                                                  132, 125, 12, 95, 169, 164, 196, 112, 149, 191, 37, 147, 121, 99, 157, 23,
                                                  129, 229, 167, 183, 219, 27, 151, 135, 210, 214, 207, 241, 253, 220, 84, 88,
                                                  246, 238, 102, 2, 227, 6, 197, 56, 116, 231, 70, 16, 242, 143, 73, 81,
                                                  35, 159, 103, 54, 203, 109, 5, 158, 63, 228, 69, 222, 21, 249, 185, 247,
                                                  62, 52, 34, 234, 50, 205, 230, 200, 243, 19, 115, 7, 213, 0, 14, 60,
                                                  218, 28, 105, 100, 9, 248, 20, 137, 206, 179, 193, 30, 126, 31, 17, 181,
                                                  250, 72, 198, 11, 90, 22, 128, 127, 76, 25, 108, 166, 8, 66, 104, 160,
                                                  26, 67, 155, 177, 254, 91, 148, 55, 202, 171, 162, 114, 232, 240, 140, 24,
                                                  150, 221, 174, 251, 235, 65, 233, 117, 59, 245, 32, 3, 178, 107, 122, 170
                                              };

        /// <summary>
        /// Decode to String - this does not work the same way as C++
        /// </summary>
        /// <param name="cIn"></param>
        /// <returns></returns>
        public string Decode(string cIn)
        {
            var cOut = new StringBuilder("");

            for (int i = 0; i < cIn.Length; ++i)
                cOut.Append(Convert.ToChar(CryptoDecode[Convert.ToInt16(cIn[i])]));

            return cOut.ToString();
        }

        /// <summary>
        /// Encode to String - this does not work the same way as C++
        /// </summary>
        /// <param name="cIn"></param>
        /// <returns></returns>
        public string Encode(string cIn)
        {
            var cOut = new StringBuilder("");

            for (int i = 0; i < cIn.Length; ++i)
                cOut.Append(Convert.ToChar(CryptoEncode[Convert.ToInt16(cIn[i])]));

            return cOut.ToString();
        }

        /// <summary>
        /// Encode to sbyte array - this is C++ compatible
        /// </summary>
        /// <param name="cIn"></param>
        /// <returns></returns>
        public sbyte[] SEncode(string cIn)
        {
            var aOut = new sbyte[cIn.Length];

            for (int i = 0; i < cIn.Length; ++i)
            {
                byte b = Convert.ToByte(CryptoEncode[Convert.ToInt16(cIn[i])]);
                sbyte s;
                s = b > 127 ? Convert.ToSByte(b - 256) : Convert.ToSByte(b);
                aOut[i] = s;
            }

            return aOut;
        }

        /// <summary>
        /// Decode sbyte array - this is C++ compatible
        /// </summary>
        /// <param name="sIn"></param>
        /// <returns></returns>
        public string SDecode(sbyte[] sIn)
        {
            var cOut = new StringBuilder("");

            for (int i = 0; i < sIn.Length; ++i)
            {
                int n = Convert.ToInt16(sIn[i]);

                if (n < 0)
                    n = n + 256;

                cOut.Append(Convert.ToChar(CryptoDecode[n]));
            }

            return cOut.ToString();
        }

        public byte[] BEncode(string cIn)
        {
            var aOut = new byte[cIn.Length];

            for (int i = 0; i < cIn.Length; ++i)
            {
                byte b = Convert.ToByte(CryptoEncode[Convert.ToInt16(cIn[i])]);

                if (b > 256)
                    b = Convert.ToByte(b - 256);

                aOut[i] = b;
            }

            return aOut;
        }

        /// <summary>
        /// Decode sbyte array - this is C++ compatible
        /// </summary>
        /// <param name="sIn"></param>
        /// <returns></returns>
        public string BDecode(byte[] sIn)
        {
            var cOut = new StringBuilder("");

            for (int i = 0; i < sIn.Length; ++i)
                cOut.Append(Convert.ToChar(CryptoDecode[sIn[i]]));

            return cOut.ToString();
        }
    }
}