using Core.Entities;
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string BrandModel { get; set; }
        public string ModelYear { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public int CategoryId { get; set; }
        public List<string> ImagePath { get; set; }
        public string CategoryName { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public int FindexPoint { get; set; }
    }
}
