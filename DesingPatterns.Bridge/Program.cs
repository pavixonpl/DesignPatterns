using Autofac;
using System;

namespace DesingPatterns.Bridge
{
    //Bridge is a pattern, which gives you an interface with commonly used methods in abstract type
    //For ex. in shape a method draw.
    //With interface you can specify a common draw enginge, for all shapes
    //It is very good design pattern, which has many possible uses
    //I've used it a lot, wihout knowing it's name
    class Program
    {
        static void Main(string[] args)
        {
            var demo = new Demo();
            demo.Main();
            Console.ReadKey();
        }
    }
    public interface IRenderer
    {
        void RenderCircle(float radius);
    }

    public class VectorRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing a circle of radius {radius}");
        }
    }

    public class RasterRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing pixels for circle of radius {radius}");
        }
    }

    public abstract class Shape
    {
        protected IRenderer renderer;

        // a bridge between the shape that's being drawn an
        // the component which actually draws it
        public Shape(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public abstract void Draw();
        public abstract void Resize(float factor);
    }

    public class Circle : Shape
    {
        private float radius;

        public Circle(IRenderer renderer, float radius) : base(renderer)
        {
            this.radius = radius;
        }

        public override void Draw()
        {
            renderer.RenderCircle(radius);
        }

        public override void Resize(float factor)
        {
            radius *= factor;
        }
    }

    public class Demo
    {
        public void Main()
        {

            var cb = new ContainerBuilder();
            cb.RegisterType<VectorRenderer>().As<IRenderer>();
            cb.Register((c, p) => new Circle(c.Resolve<IRenderer>(), p.Positional<float>(0)));
            using (var c = cb.Build())
            {
                var circle = c.Resolve<Circle>(new PositionalParameter(0, 5.0f));
                circle.Draw();
                circle.Resize(2);
                circle.Draw();
            }
        }
    }
}
