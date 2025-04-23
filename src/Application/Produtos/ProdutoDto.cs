using AutoMapper;
using WebShopAPI.Application.Interfaces;
using WebShopAPI.Domain.Entities.Produtos;

namespace WebShopAPI.Application.Produtos;

public class ProdutoDto : IMapFrom<Produto>
{
    public long ProdutoId { get; set; }

    public string Descricao { get; set; }

    public bool IsAtivo { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Produto, ProdutoDto>()
            .ForMember(d => d.ProdutoId, opt => opt.MapFrom(p => p.Id))
            .ForMember(d => d.Descricao, opt => opt.MapFrom(p => p.Descricao))
            .ForMember(d => d.IsAtivo, opt => opt.MapFrom(p => p.IsAtivo));
    }
}