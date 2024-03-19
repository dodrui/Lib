using Laba10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba9
{
    public class Runner : IInit
    {
        private double speed;
        private double distance;
        protected Random rnd = new Random();
        public static int count;
        public double Speed
        {
            get
            {
                return speed;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Ошибка! Скорость не может быть отрицательной!");
                }
                else
                {
                    speed = value;
                }
            }
        }
        public double Distance
        {
            get
            {
                return distance;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Ошибка! Дистанция не может быть отрицательной!");
                }
                else
                {
                    distance = value;
                }
            }
        }
        public Runner()
        {
            Speed = 5;
            Distance = 100;
            count++;
        }
        public Runner(double speed, double distance)
        {
            Speed = speed;
            Distance = distance;
            count++;
        }
        public Runner(Runner r)
        {
            Speed = r.Speed;
            Distance = r.Distance;
            count++;
        }
        public void Show()
        {
            Console.WriteLine($"Скорость: {Speed} км/ч; дистанция: {Distance} км");
        }
        public static int GetCount => count;
        public double GetTime()
        {
            double s = this.Speed;
            double d = this.Distance;
            double time = d / s;
            return Math.Round(time, 2);
        }
        public static Runner operator ++(Runner r) 
        {
            r.Distance += 0.1;
            return r;
        }
        public static Runner operator --(Runner r) 
        { 
            r.Speed -= 0.05;
            return r;
        }
        public static explicit operator double(Runner r) 
        {
            double difference;
            difference = r.speed / 19;
            return difference;
        }
        public static implicit operator string(Runner r)
        {
            double tempTime = r.GetTime();
            int hh = (int)tempTime;
            tempTime = tempTime - hh;
            tempTime *= 60;
            int mm = (int)tempTime;
            tempTime = tempTime - mm;
            tempTime *= 60;
            int ss = (int)Math.Round(tempTime);
            string fullTime = StringTime(hh) + ":" + StringTime(mm) + ":" + StringTime(ss);
            return fullTime;
        }
        public static double operator -(Runner r1, Runner r2)
        {
            double fullDistance = 15;
            double fullSpeed = r1.Speed + r2.Speed;
            if (0 == fullSpeed)
            {
                return -1;
            }
            double meetTime = fullDistance / fullSpeed;
            return meetTime;
        }
        public static Runner operator ^(Runner r1, double sp)
        {
            Runner temp = r1; 
            temp.speed = r1.Speed + sp;
            return temp;
        }
        public static Runner operator ^(double sp, Runner r1)
        {
            Runner temp = r1;
            temp.speed = r1.Speed + sp;
            return temp;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not Runner) return false;
            return ((Runner)obj).Speed == this.Speed && ((Runner)obj).Distance == this.Distance;
        }
        static string StringTime(double x)
        {
            string sx = x.ToString();
            if (x < 10)
                sx = "0" + sx;
            return sx;
        }
        public void AntiCounter(int i)
        {
            while (i > 0)
            {
                count--;
                i--;
            }
            
        }
        public static bool operator >(Runner r1, Runner r2)
        {
            bool isTrue = false;
            double time1 = r1.GetTime();
            double dis1 = r1.Distance;
            double time2 = r2.GetTime();
            double dis2 = r2.Distance;
            if (dis1 > dis2)
            isTrue = true;
            if (dis1 == dis2)
            {
                if (time1 > time2)
                    isTrue = true;
            }
            return isTrue;
        }
        public static bool operator <(Runner r1, Runner r2)
        {
            bool isTrue = true;
            double timeM = r1.GetTime();
            double disM = r1.Distance;
            double timeJ = r2.GetTime();
            double disJ = r2.Distance;
            if (disM > disJ)
                isTrue = false;
            if (disM == disJ)
            {
                if (timeM > timeJ)
                    isTrue = false;
            }
            return isTrue;
        }

        public virtual void Init()
        {
            Console.WriteLine("Введите скорость бегуна:");
            try
            {
                Speed = int.Parse(Console.ReadLine());
            }
            catch
            {
                Speed = 5;
            }
            Console.WriteLine("Введите скорость бегуна:");
            try
            {
                Distance = int.Parse(Console.ReadLine());
            }
            catch
            {
                Distance = 100;
            }
        }
        public virtual void RandomInit()
        {
            Speed = rnd.Next(1, 50);
            Distance = rnd.Next(1, 1000);
        }
    }
}
