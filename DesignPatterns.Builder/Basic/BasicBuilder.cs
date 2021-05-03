using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Builder.Basic
{
    public class BasicBuilder
    {
        public void Init()
        {
            Console.WriteLine("Without:");
            PrintHTMLElementWithoutBuilder();
            Console.WriteLine("\n\nWith:");
            PrintHTMLElementWithBuilder();
            Console.ReadKey();
        }

        //Main problem without builder is that you can't easy control a indentSize,
        //so try to imagine that it is a very important element in complex object
        //Busines wan't to change number size of indent from 2 to 3, in this case you need to add space before every element
        //imagine 1000 elements, it sounds like a job for a Computer science student xd
        private void PrintHTMLElementWithoutBuilder()
        {
            var sb = new StringBuilder();

            var words = new string[] { "hello", "world" };
            sb.Append("<ul>");
            foreach (var word in words)
                sb.Append($"\n  <li>\n    {word}\n  </li>");
            sb.Append("\n</ul>");
            Console.WriteLine(sb);
        }

        private void PrintHTMLElementWithBuilder()
        {
            var builder = new HTMLBuilder("ul");
            builder.AddChild("li", "hello").AddChild("li", "world");
            Console.WriteLine(builder.ToString());
        }
    }

    public class HTMLBuilder
    {
        private readonly string rootName;
        HTMLElement root = new HTMLElement();

        public HTMLBuilder(string rootName)
        {
            this.rootName = rootName;
            root.Name = rootName;
        }

        //this doesn't scale very well, but its just needed to show how builder works
        public HTMLBuilder AddChild(string childName, string childText)
        {
            var e = new HTMLElement(childName, childText);
            root.Elements.Add(e);
            return this;
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new HTMLElement() { Name = rootName };
        }
    }

    public class HTMLElement
    {
        public string Name;
        public string Text;
        public List<HTMLElement> Elements = new List<HTMLElement>();
        public const int indentSize = 2;
        public HTMLElement()
        {

        }

        public HTMLElement(string name, string text)
        {
            Name = name;
            Text = text;
        }

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', indentSize * indent);
            sb.AppendLine($"{i}<{Name}>");

            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.AppendLine(Text);
            }

            foreach (var e in Elements)
                sb.Append(e.ToStringImpl(indent + 1));

            sb.AppendLine($"{i}</{Name}>");
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }
}
