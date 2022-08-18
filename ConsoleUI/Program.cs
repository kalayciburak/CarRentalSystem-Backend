using System;
using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI {
    internal class Program {
        static void Main(string[] args) {
            var carManager = new CarManager(new EfCarDal());
            var brandManager = new BrandManager(new EfBrandDal());
            var colorManager = new ColorManager(new EfColorDal());
            var userManager = new UserManager(new EfUserDal());
            var customerManager = new CustomerManager(new EfCustomerDal());
            var rentalManager = new RentalManager(new EfRentalDal());

            // CarTest(carManager);

            // BrandTest(brandManager);

            // ColorTest(colorManager);

            // UserTest(userManager);

            // CustomerTest(customerManager);

            // RentalTest(rentalManager);
        }

        private static void CarTest(CarManager carManager) {
            foreach (var car in carManager.GetCarDetails().Data) {
                Console.WriteLine($"{car.CarName} / {car.BrandName} / {car.ColorName}");
            }

            // var newCar = new Car {
            //     CarId = 13,
            //     BrandId = 5,
            //     ColorId = 6,
            //     ModelYear = 1999,
            //     DailyPrice = 120,
            //     Description = "Car Deneme 3"
            // };
            //
            // var result = carManager.Add(newCar);
            // Console.WriteLine(result.Message);
        }

        private static void BrandTest(BrandManager brandManager) {
            // var newBrand = new Brand {
            //     BrandId = 11,
            //     BrandName = "Renault"
            // };
            //
            // brandManager.Add(newBrand);

            foreach (var brand in brandManager.GetAll().Data) {
                Console.WriteLine($"{brand.BrandName}");
            }

            Console.WriteLine(brandManager.GetById(5).Data.BrandName);
        }

        private static void ColorTest(ColorManager colorManager) {
            // var newColor = new Color {
            //     ColorId = 1,
            //     ColorName = "Black"
            // };
            //
            // colorManager.Update(newColor);

            foreach (var color in colorManager.GetAll().Data) {
                Console.WriteLine(color.ColorName);
            }

            Console.WriteLine(colorManager.GetById(6).Data.ColorName);
        }

        // private static void UserTest(UserManager userManager) {
        //     var newUser = new User {
        //         UserId = 11,
        //         FirstName = "Burak",
        //         LastName = "Kalaycı",
        //         Email = "tbyte@gmail.com",
        //         Password = "5581475315"
        //     };
        //
        //     userManager.Add(newUser);
        //
        //     foreach (var user in userManager.GetAll().Data) {
        //         Console.WriteLine($"{user.FirstName} {user.LastName} / {user.Email}");
        //     }
        // }

        private static void CustomerTest(CustomerManager customerManager) {
            var newCustomer = new Customer {
                CustomerId = 11,
                UserId = 11,
                CompanyName = "Google"
            };

            customerManager.Add(newCustomer);

            foreach (var customer in customerManager.GetAll().Data) {
                Console.WriteLine(customer.CompanyName);
            }
        }

        private static void RentalTest(RentalManager rentalManager) {
            var newRental = new Rental {
                RentalId = 11,
                CustomerId = 3,
                CarId = 1,
                RentDate = new DateTime(2022, 1, 10),
                ReturnDate = new DateTime(2022, 6, 23),
            };

            rentalManager.Add(newRental);

            foreach (var rental in rentalManager.GetRentalDetails().Data) {
                Console.WriteLine(
                    $"{rental.CustomerName} / {rental.CarName} / {rental.RentDate.Year} - {rental.ReturnDate.Year}");
            }
        }
    }
}