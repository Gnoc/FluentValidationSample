using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using FluentValidation;

namespace GnocFluentValidation.Models.Validations
{
    public class GnocValidation : AbstractValidator<GnocModel>
    {
        public GnocValidation()
        {
            var doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath("/App_Data/ValidationRules.xml"));
            var maxLength = doc.SelectSingleNode(".//MaxLength");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Chưa nhập kìa ku")
                .Length(0, Int32.Parse(maxLength.InnerText)).WithMessage("Lố òi!");
        }
    }
}