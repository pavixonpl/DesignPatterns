using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Decorator.Autofac
{
    public interface IReportingService
    {
        string Report();
    }

    public class ReportingService : IReportingService
    {
        public string Report()
        {
            return "Here is your report";
        }
    }

    public class ReportingServiceWithLogging : IReportingService
    {
        private IReportingService decorated;

        public ReportingServiceWithLogging(IReportingService decorated)
        {
            if (decorated == null)
            {
                throw new ArgumentNullException(paramName: nameof(decorated));
            }
            this.decorated = decorated;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Commencing log...");
            sb.Append(decorated.Report());
            sb.AppendLine("Ending log...");
            return sb.ToString();
        }
    }

    public class Decorators
    {
        public string Invoke()
        {
            var b = new ContainerBuilder();
            b.RegisterType<ReportingService>().Named<IReportingService>("reporting");
            b.RegisterDecorator<IReportingService>(
                (context, service) => new ReportingServiceWithLogging(service), //with what is decorated
              "reporting"); //target of decoration


            using (var c = b.Build())
            {
                var r = c.Resolve<IReportingService>();
                return r.Report();
            }
        }
    }
}
