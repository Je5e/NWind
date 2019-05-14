using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
  public partial  class Product
    {

       
        [NotMapped]
        public decimal Valor

        {
            get { return UnitPrice * UnitsInStock; }
            
        }

    }
}
