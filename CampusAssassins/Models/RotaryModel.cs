using System;
using System.Collections.Generic;
using System.Text;

namespace CampusAssassins.Models
{
    public class RotaryModel
    {
        public List<RotarySector> Sectors { get; set; }

    }
    public class RotarySector
    {
        public string Game { get; set; }
        public string Color { get; set; }
    }
}
