using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqTrials
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lists and objects from tuts+ article by A. Mirkazemi (2/23/10)
   
            List<Car> ListOfCars = new List<Car>()  
            {  
                new Car {name = "Mitsubishi", owner = "Jeff" , model = 2005},  
                new Car {name = "Land Rover", owner = "Danny", model = 2001},  
                new Car {name = "Subaru"    , owner = "Smith", model = 2003},  
                new Car {name = "Toyota"    , owner = "Alex" , model = 1992},  
                new Car {name = "BMW"       , owner = "Danny", model = 2006},  
            };

            List<CarOwner> ListOfCarOwners = new List<CarOwner>()  
            {  
                new CarOwner {owner_name = "Danny", age = 22},  
                new CarOwner {owner_name = "Jeff" , age = 35},  
                new CarOwner {owner_name = "Smith", age = 19},  
                new CarOwner {owner_name = "Alex" , age = 40}  
            };  

            //  Let's play with some LINQ operators and view the results
            //  1) Basic restriction with WHERE, cars newer than 2004

            IEnumerable<Car> Cquery = from car in ListOfCars 
                                      where car.model > 2004
                                      select car;

            foreach (Car indx in Cquery) Console.WriteLine("Auto: {0} Year= {1}",indx.name,indx.model);
            Console.ReadLine();

            //  2) Aggregate, Average year of all the cars

            var avgYear = ListOfCars.Average(w => w.model);

            Console.WriteLine("Average car year = {0:g}",avgYear);
            Console.ReadLine();

            //  3) Take the 4 newest cars, list in order by year (oldest first)

            var aQuery = ListOfCars.OrderByDescending(w => w.model).Take(4).Reverse();

            foreach (var indx in aQuery) Console.WriteLine("Auto: {0} Year= {1}", indx.name, indx.model);
            Console.ReadLine();

            // 4) Join the two lists and see WHO owns WHICH cars

            var oQuery = from carowner in ListOfCarOwners
                              join car in ListOfCars on carowner.owner_name equals car.owner into carsGroup
                              select new { name = carowner.owner_name, cars = carsGroup };

            foreach (var carOwner in oQuery)
                foreach (var car in carOwner.cars)
                    Console.WriteLine("Owner name: {0}, car name: {1}, car model: {2}", carOwner.name, car.name, car.model);
                    Console.ReadLine();


            //  5) View all car owners by order of their age

            var aOwners = from owner in ListOfCarOwners
                            orderby owner.age
                            select owner;

            foreach (var indx in aOwners) Console.WriteLine("Name: {0} Age= {1}", indx.owner_name, indx.age);
            Console.ReadLine();
        }
    }
}
