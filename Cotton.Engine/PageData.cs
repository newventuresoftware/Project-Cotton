using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewVentureSoftware.Cotton.Engine
{
    public class PageData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        public string PageURL { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }
    }
}
