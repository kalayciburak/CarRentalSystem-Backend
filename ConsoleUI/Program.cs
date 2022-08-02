using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI {
    internal class Program {
        static void Main(string[] args) {
            var carManager = new CarManager(new EfCarDal());

            // foreach (var car in carManager.GetAll()) {
            //     Console.WriteLine($"{car.ModelYear}, {car.DailyPrice}$, {car.Description}");
            // }
            
            // foreach (var car in carManager.GetCarsByColorId(2)) {
            //     Console.WriteLine($"{car.ModelYear} {car.DailyPrice}$, {car.Description}");
            // }
            
            // foreach (var car in carManager.GetCarsByBrandId(3)) {
            //     Console.WriteLine($"{car.ModelYear} {car.DailyPrice}$, {car.Description}");
            // }
            
            // var newCar = new Car{
            //     CarId = 11,
            //     BrandId = 3,
            //     ColorId = 2,
            //     ModelYear = 2019,
            //     DailyPrice = 100,
            //     Description = "New Car"
            // };
            
            // carManager.Add(newCar);
        }
    }
}