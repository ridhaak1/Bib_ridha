using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_ridha
{
    internal class NewsPaper : ReadingRoomItem
    {
        public override string Identification
        {
            get
            {
                string[] titleSplit = Title.Split(" ");
                string newtitel = "";
                DateTime idDate = this.date;
                string day = idDate.Day.ToString("00");
                string month = idDate.Month.ToString("00");
                string year = Convert.ToString(idDate.Year);
                string ddmmyyyy = day + month + year;
                foreach (var word in titleSplit)
                {
                    newtitel += word.Substring(0,1).ToUpper();
                }
                newtitel += ddmmyyyy;
                return newtitel;
            }
        }

        public override string Categorie
        {
            get
            {
                return "Krant";
            }
        }

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }


        public NewsPaper(string title, string publisher, DateTime date) : base(title, publisher)
        {
            this.date = date;
        }

    }
}
