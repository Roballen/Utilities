namespace Utilities
{
    /// <summary>
    ///
    /// </summary>
    public class Base64Encoder
    {
        private readonly int blockCount;
        private readonly int length;
        private readonly int length2;
        private readonly int paddingCount;
        private readonly byte[] source;

        public Base64Encoder(byte[] input)
        {
            source = input;
            length = input.Length;

            if ((length%3) == 0)
            {
                blockCount = length/3;
            }
            else
            {
                paddingCount = 3 - (length%3); //need to add padding
                blockCount = (length + paddingCount)/3;
            }

            length2 = length + paddingCount; //or blockCount *3
        }

        public byte[] GetSource()
        {
            return source;
        }

        public char[] GetEncoded()
        {
            var source2 = new byte[length2];

            for (int x = 0; x < length2; x++)
            {
                if (x < length)
                    source2[x] = source[x];
                else
                    source2[x] = 0;
            }

            var buffer = new byte[blockCount*4];
            var result = new char[blockCount*4];

            for (int x = 0; x < blockCount; x++)
            {
                byte b1 = source2[x*3];
                byte b2 = source2[x*3 + 1];
                byte b3 = source2[x*3 + 2];

                var temp1 = (byte) ((b1 & 252) >> 2);

                var temp = (byte) ((b1 & 3) << 4);
                var temp2 = (byte) ((b2 & 240) >> 4);
                temp2 += temp; //second

                temp = (byte) ((b2 & 15) << 2);
                var temp3 = (byte) ((b3 & 192) >> 6);
                temp3 += temp; //third

                var temp4 = (byte) (b3 & 63);

                buffer[x*4] = temp1;
                buffer[x*4 + 1] = temp2;
                buffer[x*4 + 2] = temp3;
                buffer[x*4 + 3] = temp4;
            }

            for (int x = 0; x < blockCount*4; x++)
            {
                result[x] = SixBit2Char(buffer[x]);
            }

            //covert last "A"s to "=", based on paddingCount
            switch (paddingCount)
            {
                case 0:
                    break;
                case 1:
                    result[blockCount*4 - 1] = '=';
                    break;
                case 2:
                    result[blockCount*4 - 1] = '=';
                    result[blockCount*4 - 2] = '=';
                    break;
                default:
                    break;
            }
            return result;
        }

        public static char SixBit2Char(byte b)
        {
            var lookupTable = new[]
                                  {
                                      'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
                                      'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                                      'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                                      'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                                      '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '/'
                                  };

            if ((b >= 0) && (b <= 63))
            {
                return lookupTable[b];
            }
            else
            {
                //should not happen;
                return ' ';
            }
        }
    }

    public class Base64Decoder
    {
        private readonly int blockCount;
        private readonly int length;
        private readonly int length2;
        private readonly int paddingCount;
        private readonly char[] source;
        private int length3;

        public Base64Decoder(char[] input)
        {
            int temp = 0;
            source = input;
            length = input.Length;

            //find how many padding are there
            for (int x = 0; x < 2; x++)
            {
                if (input[length - x - 1] == '=')
                    temp++;
            }
            paddingCount = temp;
            //calculate the blockCount;
            //assuming all whitespace and carriage returns/newline were removed.
            blockCount = length/4;
            length2 = blockCount*3;
        }

        public char[] GetSource()
        {
            return source;
        }

        public byte[] GetDecoded()
        {
            var buffer = new byte[length]; //first conversion result
            var buffer2 = new byte[length2]; //decoded array with padding

            for (int x = 0; x < length; x++)
                buffer[x] = Char2SixBit(source[x]);

            for (int x = 0; x < blockCount; x++)
            {
                byte temp1 = buffer[x*4];
                byte temp2 = buffer[x*4 + 1];
                byte temp3 = buffer[x*4 + 2];
                byte temp4 = buffer[x*4 + 3];

                var b = (byte) (temp1 << 2);
                var b1 = (byte) ((temp2 & 48) >> 4);
                b1 += b;

                b = (byte) ((temp2 & 15) << 4);
                var b2 = (byte) ((temp3 & 60) >> 2);
                b2 += b;

                b = (byte) ((temp3 & 3) << 6);
                byte b3 = temp4;
                b3 += b;

                buffer2[x*3] = b1;
                buffer2[x*3 + 1] = b2;
                buffer2[x*3 + 2] = b3;
            }
            //remove paddings
            length3 = length2 - paddingCount;
            var result = new byte[length3];

            for (int x = 0; x < length3; x++)
            {
                result[x] = buffer2[x];
            }

            return result;
        }

        public static byte Char2SixBit(char c)
        {
            var lookupTable = new[]
                                  {
                                      'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
                                      'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                                      'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
                                      'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                                      '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '/'
                                  };
            if (c == '=')
                return 0;
            else
            {
                for (int x = 0; x < 64; x++)
                {
                    if (lookupTable[x] == c)
                        return (byte) x;
                }
                //should not reach here
                return 0;
            }
        }
    }
}