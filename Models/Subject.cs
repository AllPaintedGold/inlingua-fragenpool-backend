using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Subject
    {
        public int SubjectId {get;set;}
        public string Name {get;set;}
        public List<Question> Questions {get;set;}
    }
}