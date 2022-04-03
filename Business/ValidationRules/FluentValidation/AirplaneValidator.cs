using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{

    //doğrulama kurallarının olduğu class
    public class AirplaneValidator : AbstractValidator<Airplane>
    {
        public AirplaneValidator()
        {
            //boş olamaz
            RuleFor(a => a.AirplaneName).NotEmpty();
            //minimum uzunluk 2 karakter olmalı
            RuleFor(a => a.AirplaneName).MinimumLength(2);
            //a helikkopter ise(category) birim fiyat 10 a eşit yada büyük olmalı
            //RuleFor(a => a.UnitPrice).GreaterThanOrEqualTo(10).When(a => a.CategoryId == 1);
            //sıfırdan büyük olmalı
            RuleFor(a => a.UnitPrice).GreaterThan(0);

            //kendi metodumuz, kendi mesajımızla beraber
            RuleFor(a => a.AirplaneName).Must(AileBaslamali).WithMessage("Ürün Adı a ile başlamalı");

        }

        //her ürün a ile başlamalı
        public bool AileBaslamali(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
