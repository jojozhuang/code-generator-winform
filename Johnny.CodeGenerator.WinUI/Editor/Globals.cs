using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Drawing;

namespace Johnny.CodeGenerator.WinUI.Editor
{
    public static class Globals
    {
        public static int InRange(int x, int lo, int hi)
        {
            Debug.Assert(lo <= hi);

            //if (x < lo)
            //    return lo;
            //else if (x > hi)
            //    return hi;
            //else
            //    return x;

            return x < lo ? lo : (x > hi ? hi : x);

        }

        public static bool IsInRange(int x, int lo, int hi)
        {
            return x >= lo && x <= hi;
        }

        public static Color HalfMix(Color one, Color two)
        {
            return Color.FromArgb(
                (one.A + two.A) >> 1,
                (one.R + two.R) >> 1,
                (one.G + two.G) >> 1,
                (one.B + two.B) >> 1);
        }
    }
}
