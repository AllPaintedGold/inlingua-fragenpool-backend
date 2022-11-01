using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Question
    {
        public int Id {get; set;}
        public string Subject {get;set;}
        public string Type {get;set;}
        public DateTime DateOfCreation {get;set;}
        public int CreatedBy {get;set;}
        public DateTime DateOfLastChange {get;set;}
        public int LastChangedBy {get; set;}
        
        [Column(TypeName= "json")]
        public TypeSpecific<Type> TypeSpecifics{ get;set;}

    }
}