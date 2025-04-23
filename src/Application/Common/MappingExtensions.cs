using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WebShopAPI.Application.Interfaces;

namespace WebShopAPI.Application.Common;
public static class MappingExtensions
{
    public static void AddMappings(this IServiceCollection services, Assembly assembly)
    {
        services.AddAutoMapper(cfg =>
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { cfg });
            }
        }, assembly);
    }
}