using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Builder.Exercise
{
    public class CodeBuilder
    {
        private readonly string _className;
        private ClassElement _rootClass;

        public CodeBuilder(string className)
        {
            _className = className;
            _rootClass = new ClassElement(className, string.Empty);
        }

        public CodeBuilder AddField(string name, string type)
        {
            var e = new ClassElement(name, type);
            _rootClass.Elements.Add(e);
            return this;
        }

        public override string ToString()
        {
            return _rootClass.ToString();
        }
    }

    public class ClassElement
    {
        public string Name;
        public string Type;
        public List<ClassElement> Elements = new List<ClassElement>();

        public ClassElement(string name, string type)
        {
            Name = name;
            this.Type = type;
        }
        public string ToStringImpl()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"public class {Name}").AppendLine("{");
            foreach (var e in Elements)
                sb.AppendLine($"  public {e.Type} {e.Name};");
            sb.AppendLine("}");
            return sb.ToString();
        }
        public override string ToString()
        {
            return ToStringImpl();
        }
    }
}
