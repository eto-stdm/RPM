using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Wpf17
{
    public partial class ProductOrder
    {
        public string All
        {
            get
            {
                return $"Название: {Product.Name}, Количество: {Amount}, Цена: {Price}";
            }
        }
    }
}
