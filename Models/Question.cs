using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Question
    {
        [Required]public int Id {get; set;}
        [Required]public string KindOfQuestion {get;set;}
        [Required]public DateTime DateOfCreation {get;set;}
        [Required]public string CreatedBy {get;set;}
        public DateTime DateOfLastChange {get;set;}
        public string? LastChangedBy {get; set;}
        
        [Required,Column(TypeName= "json")]
        public TypeSpecific<Type> TypeSpecifics{ get;set;}

        [Required]public int SubjectId {get;set;} 
        public Subject Subject {get;set;}


    }
}