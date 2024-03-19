using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Laba10
{
    public class Helecopter:Aircraft
    {
        protected int bladesCount;
        public int BladesCount
        {
            get => bladesCount;
            set
            {
                if (value < 1 || value > 10)
                    throw new Exception("Количество лопастей может быть от 1 до 10!");
                else
                    bladesCount = value;
            }
        }
        public Helecopter() : base()
        {
            BladesCount = 4;
        }
        public Helecopter(string model, int productionYear, string engineType, int crewNumber, int id, int bladesCount) : base(model, productionYear, engineType, crewNumber, id)
        {
            BladesCount = bladesCount;
        }
        public override bool Equals(object? obj)
        {
            Helecopter h = obj as Helecopter;
            if (h != null)
                return h.Model == this.Model
                    && h.ProductionYear == this.ProductionYear
                    && h.EngineType == this.EngineType
                    && h.CrewNumber == this.CrewNumber
                    && h.BladesCount == this.BladesCount;
            else return false;
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"количество лопастей: {BladesCount} шт");
        }
        public override string ToString()
        {
            return base.ToString() + $"\nКоличество лопастей: {BladesCount}";
        }
        [ExcludeFromCodeCoverage]
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите количество лопастей вертолета:");
            try
            {
                BladesCount = int.Parse(Console.ReadLine());
            }
            catch
            {
                BladesCount = 4;
            }
        }
        public override void RandomInit()
        {
            base.RandomInit();
            Model = "Вертолет";
            BladesCount = rnd.Next(1, 10);
        }
    }
}
