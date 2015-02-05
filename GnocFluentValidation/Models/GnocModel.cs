﻿using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using GnocFluentValidation.Models.Validations;

namespace GnocFluentValidation.Models
{
    [Validator(typeof(GnocValidation))]
    public class GnocModel : BaseModel
    {
        public string Name { get; set; }
        public int? Age { get; set; }

        [MaxLength(10)]
        //[Required]
        public string FisrtName { get; set; }
    }
}