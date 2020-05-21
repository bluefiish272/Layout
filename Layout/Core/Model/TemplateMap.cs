using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public class TemplateMap
    {
        public TemplateType Type { get; set; }
        public string PartialViewName { get; set; }
        public string Text { get; set; }
        public string ImagePath { get; set; }
    }
}
