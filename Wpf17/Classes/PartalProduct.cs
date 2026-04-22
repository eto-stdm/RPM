using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf17
{
    public partial class Product
    {
        public double TotalRating
        {
            get
            {
                List<Rating> ratingList = Core.Context.Rating.Where(x => x.ProductID == ProductID).ToList();
                double sum = 0;
                foreach(Rating rating in ratingList) { sum += rating.Value; }
                return sum / ratingList.Count;
            }
        }
    }
}
