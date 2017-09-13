namespace AddsSystem.Client.Mappings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using AutoMapper;
    using AddsSystem.Models.EntityModels;
    using AddsSystem.Models.ViewModels;

    public class AutoMapperConfig : Profile
    {

        public AutoMapperConfig()
        {
            CreateMap<UserPost, AddsViewModel>();
            CreateMap<UserPost, ProfileInfoVM>();
            CreateMap<UserPost, ContentIdVM>();
            CreateMap<UserPost, EditByIdVM>();
            CreateMap<UserPost, AllProfilesVM>();
        }

        //public static void RegisterMappings(params Assembly[] assemblies)
        //{
        //    var types = new List<Type>();
        //    foreach (var assembly in assemblies)
        //    {
        //        types.AddRange(assembly.GetExportedTypes());
        //    }

        //    LoadStandardMappings(types);
        //    LoadCustomMappings(types);
        //}

        //private static void LoadStandardMappings(IEnumerable<Type> types)
        //{
        //    var maps = types.SelectMany(t => t.GetInterfaces(), (t, i) => new { t, i })
        //        .Where(
        //            type =>
        //                type.i.IsGenericType && type.i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
        //                !type.t.IsAbstract
        //                && !type.t.IsInterface)
        //        .Select(type => new { Source = type.i.GetGenericArguments()[0], Destination = type.t });

        //    foreach (var map in maps)
        //    {
        //        Mapper.CreateMap(map.Source, map.Destination);
        //        Mapper.CreateMap(map.Destination, map.Source);
        //    }
        //}

        //private static void LoadCustomMappings(IEnumerable<Type> types)
        //{
        //    var maps =
        //        types.SelectMany(t => t.GetInterfaces(), (t, i) => new { t, i })
        //            .Where(
        //                type =>
        //                    typeof(IHaveCustomMappings).IsAssignableFrom(type.t) && !type.t.IsAbstract &&
        //                    !type.t.IsInterface)
        //            .Select(type => (IHaveCustomMappings)Activator.CreateInstance(type.t));

        //    foreach (var map in maps)
        //    {
        //        map.CreateMappings(Mapper.Configuration);
        //    }
        //}
    }
}