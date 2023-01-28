using AutoMapper;
using System.Reflection;

namespace Notes.Application.Common.Mappings
{
    /// <summary>
    /// Класс AssemblyMappingProfile 
    /// организует конфигурацию маппинга
    /// </summary>
    public class AssemblyMappingProfile : Profile
    {
        public AssemblyMappingProfile(Assembly assembly) =>
            ApplyMappingsFromAssembly(assembly);

        /// <summary>
        /// Метод ApplyMappingsFromAssembly
        /// сканирует сборку и ищет любые типы
        /// которые реализуют интерфейс IMapWith<>
        /// </summary>
        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(type => type.GetInterfaces()
                .Any(i => i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
            .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
