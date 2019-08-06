using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OdeToFood.Core
{

    public class Restaurant 
    {
        public int Id { get; set; }
        [Required ,StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(250)]
        public string Address { get; set; }
        public CuisineType Cuisine { get; set; }

      

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //   //throw new NotImplementedException();
        //}
    }
}
