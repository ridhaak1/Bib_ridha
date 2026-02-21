using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_ridha
{
    internal class Magazine : ReadingRoomItem
    {
        public override string Identification
        {
            get
            {
                string[] titleSplit = Title.Split(" ");
                string magTitel = "";
                foreach (var word in titleSplit)
                {
                    magTitel += word.Substring(0, 1).ToUpper();
                }
                string magMonth = month.ToString("00");
                string magYear = year.ToString("0000");
                magTitel += magMonth + magYear;
                return magTitel;
            }
        }

        public override string Categorie
        {
            get
            {
                return "Maandblad";
            }
        }

        private byte month;
        public byte Month
        {
            get { return month; }
            set
            {
                if (value > 12)
                {
                    throw new ArgumentException("De maand is maximaal 12.");
                }
                    month = value;
            }
        }

        private uint year;

        public Magazine(string title, string publisher) : base(title, publisher)
        {
        }

        public uint Year
        {
            get { return year; }
            set {
                if (value > 2500)
                {
                   throw new ArgumentException("“Het jaartal is maximaal 2500");
                }
                    year = value;
            }
        }

        public Magazine(string title, string publisher, byte month, uint year) : base(title, publisher)
        {
            Month = month;
            Year = year;
        }
    }
}
