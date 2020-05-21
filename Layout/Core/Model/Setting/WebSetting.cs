using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public class WebSetting
    {
        public string CompanyId { get; set; }
        
    }

    public class Layout
    { 
        public string Location { get; set; }
        public int Order { get; set; }
        public string Template { get; set; }
        public string Content { get; set; }
    }
}
