using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TheDeepO.Models
{
    public class Choice
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set; }
    }
}
