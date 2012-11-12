using System;
using System.ComponentModel.DataAnnotations;
//using System.Linq;

namespace BusinessObjects
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
        //public string rowversion { get; set; }
    }
}
