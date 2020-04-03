using System;
using System.Collections.Generic;
using System.Text;

namespace eMids.QA.Application.Common.Config
{
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        public string DatabaseConnectionString { get; set; }
        public string WebAPIUrl { get; set; }
    }
    public interface IApplicationConfiguration
    {
        string DatabaseConnectionString { get; set; }
        string WebAPIUrl { get; set; }
    }
}
