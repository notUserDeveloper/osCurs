using System;
using System.Linq;

namespace WebService.Helpers
{
    public static class SequenceHelper
    {
        public static bool[] GetSequence(int numberToSequence)
        {
            char[] sequenceArray = Convert.ToString(numberToSequence, 2).ToCharArray();
            Array.Reverse(sequenceArray);
            return new string(sequenceArray).Select(c => c == '1').ToArray();
        }
    }
}