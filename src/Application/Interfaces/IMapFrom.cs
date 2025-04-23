using AutoMapper;

namespace WebShopAPI.Application.Interfaces;

public interface IMapFrom<T>
{
    void Mapping(Profile profile);
}