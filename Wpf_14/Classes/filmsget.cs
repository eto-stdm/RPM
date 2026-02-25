using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_14;

namespace Wpf_14
{
    public partial class Films
    {
        public string getgenres
        {
            get
            {
                string total = "Жанры: ";

                foreach (Genres getgenres in this.Genres)
                {
                    total += $"{getgenres.Genre}, ";
                }

                total = total.Remove(total.Length - 2);

                return total;
            }
        }

    }
}