using System;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors {
    public class AspectInterceptorSelector : IInterceptorSelector {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors) {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            // ReSharper disable once AssignNullToNotNullAttribute
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);

            // ReSharper disable once CoVariantArrayConversion
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}