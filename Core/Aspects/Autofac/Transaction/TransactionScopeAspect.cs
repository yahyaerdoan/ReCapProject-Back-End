using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation) //invocation Benim metodum
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed(); //Manger sınıfındaki TransactionalOperation metodudur.
                    transactionScope.Complete(); //İşlem başarılı oşursa işlemi tamamla bitir.
                }
                catch (System.Exception e)
                {
                    transactionScope.Dispose(); //Hata oluşursa işlemi geri al.
                    throw;
                }
            }
        }
    }
}
