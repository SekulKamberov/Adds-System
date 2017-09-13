namespace AddsSystem.Client.Mappings
{
    using AutoMapper.Configuration;

    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration config);
    }
}