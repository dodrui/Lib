using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Laba10
{
    public class Jet:Aircraft
    {
        protected string function;
        static string[] functions = { "фронтовой", "перехватчик", "палубный", "многофункциональный", "тактический" };
        public string Function
        {
            get => function;
            set
            {
                if (value == "")
                    throw new Exception("Графа функции не может быть пустой!");
                else
                    function = value;
            }
        }
        //Возвращает объект базового класса
        public Aircraft GetBase
        {
            get => new Aircraft("Истребитель", 2017, "ДВС", 3, 1);
        }
        public Jet() : base()
        {
            Function = "EmptyFunction";
        }
        public Jet(string model, int productionYear, string engineType, int crewNumber, int id, string function) : base(model, productionYear, engineType, crewNumber, id)
        {
            Function = function;
        }

        public override bool Equals(object? obj)
        {
            Jet j = obj as Jet;
            if (j != null)
                return j.Model == this.Model
                    && j.ProductionYear == this.ProductionYear
                    && j.EngineType == this.EngineType
                    && j.CrewNumber == this.CrewNumber
                    && j.Function == this.Function;
            else return false;
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"функция: {Function}");
        }
        public override string ToString()
        {
            return base.ToString() + $"\nФункция: {Function}";
        }
        [ExcludeFromCodeCoverage]
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите функцию истребителя:");
            Function = Console.ReadLine();
        }
        public override void RandomInit()
        {
            base.RandomInit();
            Model = "Истребитель";
            Function = functions[rnd.Next(functions.Length)];
        }
    }
}
