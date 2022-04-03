using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingCpncerns.Validation
{
    public static class ValidationTool
    {
        //i validator fluent validator ün bir arayüzü validatör referansları tutması iiçin

        //1. referans doğrulanma kurallarının oldığı sınıf 2. param doğrılanacak sınıf
        public static void Validate(IValidator validator,object entity)
        {
            var context = new ValidationContext<object>(entity);
            //AirplaneValidator airplaneValidator = new AirplaneValidator(); i validator burayı tutuyor
            var result = validator.Validate(context);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

        }
    }
}
