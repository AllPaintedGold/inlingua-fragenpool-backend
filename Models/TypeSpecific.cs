using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class TypeSpecific<T>
    {
        public T TypeSpecifics {get;set;}
    }
}