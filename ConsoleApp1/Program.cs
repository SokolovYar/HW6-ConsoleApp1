using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
         public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Point ()
        {
            X = 0;
            Y = 0; 
        }
        public override string ToString()
        {
            return $"[{X};{Y}]";
        }
    }

    internal class Triangle : IEnumerator<Point>
    {
        Point[] _point = new Point[3];
        protected int _index = -1;
        public Triangle(Point[] point)
        {
            _point = point;
        }
        public Point Current { get { return _point[_index]; } }
        object IEnumerator.Current { get; } 
        public bool MoveNext()
        {
            if (_index >= _point.Length) throw new InvalidOperationException(); //System.InvalidOperationException: После создания перечислителя семейство было изменено.
            if (_index >= _point.Length - 1) return false;
            _index++;
            return true;
        }
        public void Reset ()
        {
            _index = -1;
        }
        public void Dispose()
        { }

        public IEnumerator GetEnumerator()
        { return _point.GetEnumerator(); }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Point[] ArrPoint = new Point[3];
            ArrPoint[0] = new Point(1, 1);
            ArrPoint[1] = new Point(2, 2);
            ArrPoint[2] = new Point(3, 3);

            Triangle MyTriangle = new Triangle(ArrPoint);

            foreach (var it in MyTriangle)
            {
                Console.WriteLine(it);
            }
            Console.WriteLine();
        }
    }
}
