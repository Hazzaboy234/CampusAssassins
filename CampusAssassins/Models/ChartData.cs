using System;
using System.Collections.Generic;
using System.Text;
using CampusAssassins.Helpers;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace CampusAssassins.Models
{
    public class ChartData
    {
        public string Text => $"{Constants.EmptySpaces}{Sector.Game}";
        public SKColor Color => Xamarin.Forms.Color.FromHex(Sector.Color).ToSKColor();

        public RotarySector Sector { get; set; }
    }
}
