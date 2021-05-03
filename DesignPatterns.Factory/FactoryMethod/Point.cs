using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory.FactoryMethod
{
    //Factory method gives a way to create more friendly named constructors
    //It is ok solution, when for ex. your constructor receives some parameters with the same type, but they should have different names
    public class Point
    {

        public static Point Default = new Point(0, 0);
        private double x, y;
        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        //Inner class is a solution which aggregates all factory methods used in point class
        public static class Factory
        {
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }
            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }
    }    

    //This class represents a situation, when factory pattern is a perfect fit
    public class PointWithoutFactory
    {
        public enum TypeOfCoordiantes
        {
            Cartesian,
            Polar
        }
        private double x, y;

        /// <summary>
        /// There should be an xml comment to be sure, that a is rho, and b i theta
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="typeOfCoordiantes"></param>
        public PointWithoutFactory(double a, double b, TypeOfCoordiantes typeOfCoordiantes = TypeOfCoordiantes.Cartesian)
        {
            switch (typeOfCoordiantes)
            {
                case TypeOfCoordiantes.Cartesian:
                    this.x = a;
                    this.y = b;
                    break;
                case TypeOfCoordiantes.Polar:
                    x = a*Math.Cos(b);
                    y = a*Math.Sin(b);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(typeOfCoordiantes));
            }
        }
    }
}
