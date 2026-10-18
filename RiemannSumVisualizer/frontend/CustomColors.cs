using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace RiemannSumVisualizer.frontend
{
    public enum MidnightMath
    {
        TwilightBlack,
        TwilightGray,
        RoyalPlum,
        HumblePink,
        ChampagnePink
    }

    public static class MidnightMathColors
    {
        public static Color GetColor(MidnightMath color)
        {
            return color switch
            {
                MidnightMath.TwilightBlack => ColorTranslator.FromHtml("#21182B"),
                MidnightMath.TwilightGray => ColorTranslator.FromHtml("#35263F"),
                MidnightMath.RoyalPlum => ColorTranslator.FromHtml("#832161"),
                MidnightMath.HumblePink => ColorTranslator.FromHtml("#DA4167"),
                MidnightMath.ChampagnePink => ColorTranslator.FromHtml("#E9B8C4"),

                _ => Color.Empty
            };
        }
    }
}