using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GnocFluentValidation.ValidationAttributes
{
    public class NumberValidation : ValidationAttribute, IClientValidatable
    {
        public string CommaSeperatedProperties { get; private set; }

        public NumberValidation(string commaSeperatedProperties)
        {
            if (!string.IsNullOrEmpty(commaSeperatedProperties))
                CommaSeperatedProperties = commaSeperatedProperties;
        }

        protected override ValidationResult IsValid
        (object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                return new ValidationResult("Là số cơ mà.");
            }
            return ValidationResult.Success;
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            return new[] { new ModelClientValidationSelectOneRule
            (FormatErrorMessage(metadata.DisplayName), 
        CommaSeperatedProperties.Split(new char[] { ',' })) };
        }

        public class ModelClientValidationSelectOneRule : ModelClientValidationRule
        {
            public ModelClientValidationSelectOneRule
        (string errorMessage, string[] strProperties)
            {
                ErrorMessage = errorMessage;
                ValidationType = "mycustomvalidation";
                for (int intIndex = 0; intIndex < strProperties.Length; intIndex++)
                {
                    ValidationParameters.Add("otherproperty" +
                    intIndex.ToString(), strProperties[intIndex]);
                }
            }
        }
    }
}