using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class MultipleChoice
    {
        public string Question {get;set;}
        public List<string> Answers {get;set;}
    }
}