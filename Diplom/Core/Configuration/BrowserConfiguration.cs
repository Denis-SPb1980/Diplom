using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Core.Configuration
{
    public class BrowserConfiguration : IConfiguration
    {
        public string SectionName => "Browser";
        public bool Headless { get; set; }
        public string? BrowserType { get; set; }
        public int ImplicityWait { get; set; }
    }
}
