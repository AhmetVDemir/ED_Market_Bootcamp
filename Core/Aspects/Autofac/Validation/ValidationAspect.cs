using Castle.DynamicProxy;
using Core.CrossCuttingCpncerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        public Type _validatorType;
        public ValidationAspect(Type validatorType)
        {

            //defensive coding; tipi kontrol et doğrılanabiliyor mu
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınırı değildir");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //Activatır reflectionu ile çalışma anında validatörün instance sını ayarla(new le)
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //verilen validatör ün base tipini bul onun generic çalıştığı veri tipini bul
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //onun parametrelerini bul, ki bu tip entity type ine eşit olsun
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            //hepsini gez
            foreach (var entity in entities)
            {
                //
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
