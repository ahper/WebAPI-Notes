using AutoMapper;

namespace Notes.Application.Common.Mappings
{
    public interface IMapWith<T>
    {
        /// <summary>
        /// Метод Mapping
        /// будет создавать конфигурацию из исходного типа T.
        /// </summary>
        void Mapping(Profile profile) => 
            profile.CreateMap(typeof(T), GetType());
    }
}
