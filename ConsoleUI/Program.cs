using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI {
    internal class Program {
        static void Main(string[] args) {
            var carManager = new CarManager(new EfCarDal());
            var brandManager = new BrandManager(new EfBrandDal());
            var colorManager = new ColorManager(new EfColorDal());

            // CarTest(carManager);
            
            // BrandTest(brandManager);
            
            // ColorTest(colorManager);

        }

        private static void CarTest(CarManager carManager) {
            foreach (var car in carManager.GetAll()) {
                Console.WriteLine($"{car.ModelYear}, {car.DailyPrice}$, {car.Description}");
            }

            foreach (var car in carManager.GetCarsByColorId(2)) {
                Console.WriteLine($"{car.ModelYear} {car.DailyPrice}$, {car.Description}");
            }

            foreach (var car in carManager.GetCarsByBrandId(3)) {
                Console.WriteLine($"{car.ModelYear} {car.DailyPrice}$, {car.Description}");
            }
            
            foreach (var car in carManager.GetCarDetails()) {
                Console.WriteLine($"{car.CarName} / {car.BrandName} / {car.ColorName}");
            }
            
            var newCar = new Car {
                CarId = 11,
                BrandId = 3,
                ColorId = 2,
                ModelYear = 2019,
                DailyPrice = 100,
                Description = "New Car Deneme"
            };

            carManager.Update(newCar);
        }
        
        private static void BrandTest(BrandManager brandManager) {
            var newBrand = new Brand {
                BrandId = 11,
                BrandName = "Renault"
            };
            
            brandManager.Add(newBrand);
            
            foreach (var brand in brandManager.GetAll()) {
                Console.WriteLine($"{brand.BrandName}");
            }

            Console.WriteLine(brandManager.GetById(5).BrandName);
        }

        private static void ColorTest(ColorManager colorManager) {
            var newColor = new Color {
                ColorId = 1,
                ColorName = "Black"
            };
            
            colorManager.Update(newColor);
            
            foreach (var color in colorManager.GetAll()) {
                Console.WriteLine(color.ColorName);
            }

            Console.WriteLine(colorManager.GetById(6).ColorName);
        }
    }
}