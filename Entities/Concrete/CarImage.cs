using System;
using Core.Entities;

namespace Entities.Concrete {
    public class CarImage : IEntity {
        public int CarImageId { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateAdded { get; set; }
    }
}