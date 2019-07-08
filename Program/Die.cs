using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    /// <summary>
    /// Represents a single multi-sided die
    /// </summary>
    class Die
    {
        private byte faceValue;
        private bool isHeld;
        private byte numberOfSides;
        private static Random rand;

        static Die()
        {
            //Share once instance of Random across All instance of the Die class
            rand = new Random();
        }

        public Die() : this(6)
        {
        }

        public Die(byte numberOfSides)
        {
            Roll();
        }

        public byte FaceValue
        {
            get { return faceValue;}
            private set
            {
                if(value == 0)
                {
                    throw new Exception("die value cannot be 0");
                }
                
            }
        }

        public byte Roll()
        {
            if (isHeld)
            {
                return FaceValue;
            }

            const byte MinValue = 1;
            //offset because of exclusive max value in the random class
            byte MaxValue = (byte)(numberOfSides + 1);

            byte result = (byte)rand.Next(MinValue, MaxValue);

            faceValue = result;

            return result;
        }
    }
}
