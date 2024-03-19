using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace Laba10
{
    public class IdNumber
    {
        public int number; 
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Id должен быть не менее 0");
                }
            }
        }
        public IdNumber(int number)
        {
            this.Number = number;
        }
        public override string ToString()
        {
            return Number.ToString();
        }
        public override bool Equals(object? obj)
        {
            if(obj is IdNumber n)
                return this.Number == n.Number;
            return false;
        }
    }
    public class Aircraft : IInit, IComparable, ICloneable
    {
        public IdNumber id;
        static string[] Models = { "Самолет", "Вертолет", "Истребитель" };
        static string[] EngineTypes = { "ДВС", "ВРД", "ТРД", "ПВРД", "ТВД", "ТВВД" };
        protected string model;
        protected int productionYear;
        protected string engineType;
        protected int crewNumber;
        protected Random rnd = new Random();
        public string Model
        {
            get => model;
            set
            {
                if (value == "")
                    throw new Exception("Графа модель судна не может быть пустой!");
                else
                    model = value;
            }
        }
        public int ProductionYear
        {
            get => productionYear;
            set
            {
                if (value < 1903 || value > 2024)
                    throw new Exception("Год производства должен быть от 1903 до 2024!");
                else
                    productionYear = value;
            }
        }
        public string EngineType
        {
            get => engineType;
            set
            {
                if (value == "")
                    throw new Exception("Графа тип двигателя не может быть пустой!");
                else
                    engineType = value;
            }
        }
        public int CrewNumber
        {
            get => crewNumber;
            set
            {
                if (value < 1 || value > 20)
                    throw new Exception("Экипаж должен составлять от 1 до 20 человек!");
                else
                    crewNumber = value;
            }
        }
        public Aircraft()
        {
            Model = "UnknownModel";
            ProductionYear = 1980;
            EngineType = "UnknownEngine";
            CrewNumber = 5;
            id = new IdNumber(1);
        }
        public Aircraft(string model, int productionYear, string engineType, int crewNumber, int number)
        {
            Model = model;
            ProductionYear = productionYear;
            EngineType = engineType;
            CrewNumber = crewNumber;
            id = new IdNumber(number);
        }
        public virtual void Show()
        {
            Console.WriteLine("==============");
            Console.WriteLine($"Модель: {model}, год производства: {productionYear}," +
                                $"\nтип двигателя: {engineType}, количество членов экипажа: {crewNumber}");
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is Aircraft a)
                return this.Model == a.Model 
                    && this.ProductionYear == a.ProductionYear 
                    && this.EngineType == a.EngineType 
                    && this.CrewNumber == a.CrewNumber;
            return false;
        }
        public override string ToString()
        {
            return $"ID: {id}" +
                $"\nМодель: {Model}, Год выпуска: {ProductionYear}, " +
                $"\nТип двигателя: {EngineType}, Число членов экипажа: {CrewNumber}";
        }
        [ExcludeFromCodeCoverage]
        public virtual void Init()
        {
            Console.WriteLine("Введите id");
            try
            {
                id.Number = int.Parse(Console.ReadLine());
            }
            catch
            {
                id.Number = 0;
            }
            Console.WriteLine("Введите модель");
            Model = Console.ReadLine();
            Console.WriteLine("Введите год производства");
            try
            {
                ProductionYear = int.Parse(Console.ReadLine());
            }
            catch
            {
                ProductionYear = 2010;
            }
            Console.WriteLine("Введите тип двигателя");
            EngineType = Console.ReadLine();
            Console.WriteLine("Введите количество членов экипажа");
            try
            {
                CrewNumber = int.Parse(Console.ReadLine());
            }
            catch
            {
                CrewNumber = 5;
            }
        }
        public virtual void RandomInit()
        {
            Model = Models[rnd.Next(Models.Length)];
            ProductionYear = rnd.Next(1903, 2024);
            EngineType = EngineTypes[rnd.Next(EngineTypes.Length)];
            CrewNumber = rnd.Next(1, 20);
            id.Number = rnd.Next(1, 100);
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) return -1;
            if (obj is not Aircraft) return -1;
            Aircraft a = obj as Aircraft;
            return String.Compare(this.EngineType, a.EngineType);
        }

        public virtual object Clone()
        {
            return new Aircraft(Model, ProductionYear, EngineType, CrewNumber, id.Number);
        }

        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
    } 
}
