using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailDto :IDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string CompanyName { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string RentDate { get; set; }
        public string ReturnDate { get; set; }
        public decimal DailyPrice { get; set; }
        public int ModelYear { get; set; }

    }
}
