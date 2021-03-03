using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    class Car
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public short ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
