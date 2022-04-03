using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        //aspect'in nerede çalışmasını istiyorsak o ilgili method ov. edilmeli

        //methodun başında
        protected virtual void OnBefore(IInvocation invocation) { }

        //methodun sonunda
        protected virtual void OnAfter(IInvocation invocation) { }

        //hata durumunda
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }

        //başarı durumunda
        protected virtual void OnSuccess(IInvocation invocation) { }


        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }


}
