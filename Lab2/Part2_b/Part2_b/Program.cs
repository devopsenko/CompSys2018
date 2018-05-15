using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2_b
{
    class Program
    {
        public static void Main(string[] args)
        {
            DivisionResult result = RemShiftDivider.Devide(9, 4);

            Console.WriteLine(result.Quotient);
            Console.WriteLine(result.Remainder);
            Console.WriteLine(result.Def);
            Console.Read();
        }
    }
    public static class RemShiftDivider
    {
        public static DivisionResult Devide(int dividend, int divisor)
        {
            int lenght;
            long r = (long)Math.Abs(dividend);
            string def = string.Format("divident: {0} \n divisor: {1} ", Convert.ToString(dividend, 2), Convert.ToString(divisor, 2));
            long b = ((long)Math.Abs(divisor)) << 32;
            int q = 0;
            def += string.Format("remainder = {0}\n", Convert.ToString(r, 2));
            for (lenght = 0; dividend != 0; dividend >>= 1, lenght++) ;
            def += string.Format("Shift the remainder register to {0} bits left to optimize algorithm\n\n", 32 - lenght - 1);
            r <<= (32 - lenght - 1);
            for (int i = 0; i < lenght + 1; i++)
            {

                r <<= 1;
                def += string.Format("shift left remainder to 1 bit {0}\n", Convert.ToString(r, 2));
                def += "subtract  divisor from remainder:\n ";
                def += string.Format("remainder: {0} divisor: {1}\n", Convert.ToString(r, 2), Convert.ToString(divisor, 2));
                r += -b;
                def += string.Format("operation result: (remainder) {0}\n", Convert.ToString(r, 2));
                q <<= 1;
                if (r < 0)
                {
                    r += b;
                    def += string.Format("Restoring the remainder original value:\n{0}\nShift quotient register left to 1 bit: {1}\n\n  ", Convert.ToString(r, 2), Convert.ToString(q, 2));

                }
                else
                {
                    q++;
                    def += string.Format("Shift quotient register left to 1 bit and plus 1:  {0}\n\n", Convert.ToString(q, 2));
                }

            }
            r >>= 32;
            if (dividend < 0)
            {
                r = -r;
                q = -q;
            }
            return new DivisionResult { Def = def, Remainder = r, Quotient = q };
        }
    }

    public class DivisionResult
    {
        public string Def { get; set; }
        public long Remainder { get; set; }
        public int Quotient { get; set; }
    }
}