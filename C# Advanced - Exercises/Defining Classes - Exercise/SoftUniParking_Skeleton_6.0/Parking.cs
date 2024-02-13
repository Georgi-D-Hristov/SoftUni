namespace SoftUniParking
{
    using System.Collections.Generic;
    using System.Linq;

    public class Parking
    {
		private List<Car> cars;
		private int capacity;

        public Parking(int capacity)
        {
            cars = new List<Car>();
            Capacity = capacity;
        }

        public int Count => cars.Count;

        public List<Car> Cars
		{
			get =>cars; 
			set => cars = value; 
		}

        public int Capacity 
        { 
            get => capacity;
            set => capacity = value; 
        }

        public string AddCar(Car car)
        {
            Car searchCar = CarExists(car.RegistrationNumber);
            if (searchCar!=null)
            {
                return "Car with that registration number, already exists!";
            }
            else if(cars.Count>=Capacity)
            {
                return "Parking is full!";
            }
            else
            {
                cars.Add(car);
               // Capacity--;
                var result = $"Successfully added new car {car.Make} {car.RegistrationNumber}";
                return result ;
            }
        }
        public string RemoveCar(string registrationNumber)
        {
            Car searchCar = CarExists(registrationNumber);
            if (searchCar == null)
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                cars.Remove(searchCar);
                //Capacity++;
                var result = $"Successfully removed {registrationNumber}";
                return result;
            }
        }


        public Car GetCar(string registrationNumber)
        {
            var car = CarExists(registrationNumber);
            if (car!=null)
            {
                return car;
            }
            return null;
        }

       public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach(var regNumber in RegistrationNumbers)
            {
                var car = CarExists(regNumber);
                if(car!=null) 
                {
                    cars.Remove(car);
                   // Capacity++;
                }
            }
        }

        private Car CarExists(string registrationNumber)
        {
            return cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
        }

        
    }
}
