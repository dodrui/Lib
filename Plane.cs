using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba10
{
    public class Plane:Aircraft
    {
        protected int passengers;
        protected int maxFlightLength;
        public int Passengers
        {
            get => passengers;
            set
            {
                if (value < 0 || value > 1000)
                    throw new Exception("Количество пассажиров может быть от 0 до 1000!");
                else
                    passengers = value;
            }
        }
        public int MaxFlightLength
        {
            get => maxFlightLength;
            set
            {
                if (value < 0 || value > 25000)
                    throw new Exception("Дальность полета может быть от 0 до 25000!");
                else
                    maxFlightLength = value;
            }
        }
        public Plane() : base()
        {
            Passengers = 300;
            MaxFlightLength = 5000;
        }
        public Plane(string model, int productionYear, string engineType, int crewNumber, int id, int passengers,
            int maxFlightLength) : base(model, productionYear, engineType, crewNumber, id)
        {
            Passengers = passengers;
            MaxFlightLength = maxFlightLength;
        }
        public override bool Equals(object? obj)
        {
            Plane p = obj as Plane;
            if (p != null)
                return p.Model == this.Model
                    && p.ProductionYear == this.ProductionYear
                    && p.EngineType == this.EngineType
                    && p.CrewNumber == this.CrewNumber
                    && p.Passengers == this.Passengers
                    && p.MaxFlightLength == this.MaxFlightLength;
            else return false;
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"вместимость: {Passengers} чел, максимальная дистанция полета: {MaxFlightLength} км");
        }
        public override string ToString()
        {
            return base.ToString() + $"\nВместимость: {Passengers} чел, Максимальная дистанция полета: {MaxFlightLength} км";
        }
        [ExcludeFromCodeCoverage]
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите вместимость самолета:");
            try
            {
                Passengers = int.Parse(Console.ReadLine());
            }
            catch
            {
                Passengers = 300;
            }
            Console.WriteLine("Введите максимальную дистанцию полета самолета:");
            try
            {
                MaxFlightLength = int.Parse(Console.ReadLine());
            }
            catch
            {
                MaxFlightLength = 5000;
            }
        }
        public override void RandomInit()
        {
            base.RandomInit();
            Model = "Самолет";
            Passengers = rnd.Next(0, 1000);
            MaxFlightLength = rnd.Next(0, 25000);
        }
    }
}
