// Необходимо разработать программу, которая включает класс автомобиль, гараж и мойка.
// Гараж будет является коллекцией машин. Мойка может только мыть машину. Необходимо делегировать мытью всех машин.

using System.Xml.Schema;

namespace Car
{
    public class Car
    {
        public string model;
        public string owner;
        private string number;
        public Car(string model, string number, string owner) 
        { 
            this.model = model;
            this.number = number;
            this.owner = owner;
        }
        public void PrintCar()
        {
            Console.WriteLine("Модель: ", model);
            Console.WriteLine("Номер машины: ", number);
            Console.WriteLine("Владелец: ", owner);
        }
    }

    class Garage
    {
        public List<Car> cars = new List<Car>();
        public delegate void CarDelegate(Car car);
        public void Do(CarDelegate active)
        {
            foreach (Car car in cars)
            {
                active(car);
                Thread.Sleep(1000);
            }
        }
    }
    class Moyka
    {
        public void Wash(Car car)
        {
            Console.WriteLine($"Подождите, машина {car.model} моется ...");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine($"Машина помылась. {car.owner} платите деняк: {car.model.Length} ");
            Console.WriteLine();
        }
        
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Garage garage = new Garage();
            garage.cars.Add(new Car("Mercedes-Benz E-Class", "А666АА", "Василий"));
            garage.cars.Add(new Car("BMW 7 Series", "P666OP", "Геннадий"));
            garage.cars.Add(new Car("Mazda CX-5", "о000оо", "Анатолий"));

            Moyka moyka = new Moyka();
            garage.Do(moyka.Wash);
        }
    }
}