using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Core.Configuration
{
    public interface IConfiguration
    {
        string SectionName { get; }
    }
}
