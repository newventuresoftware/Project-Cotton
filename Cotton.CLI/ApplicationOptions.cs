using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotton.CLI
{
    public class ApplicationOptions
    {
        public string PagesSource { get; set; }

        public string OutputFile { get; set; }

        public Mode Mode { get; set; }

    }
}
