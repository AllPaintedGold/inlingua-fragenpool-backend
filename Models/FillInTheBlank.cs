using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class FillInTheBlank
    {
        public List<string> TextParts {get;set;}
        public List<List<string>> Options {get;set;}
    }
}