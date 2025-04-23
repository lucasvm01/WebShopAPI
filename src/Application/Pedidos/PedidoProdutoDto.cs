using AutoMapper;
using WebShopAPI.Application.Interfaces;
using WebShopAPI.Application.Produtos;
using WebShopAPI.Domain.Entities.Pedidos;

namespace WebShopAPI.Application.Pedidos;

public class PedidoProdutoDto : IMapFrom<PedidoProduto>
{
    public long PedidoProdutoId { get; set; }

    public long QuantidadeProduto { get; set; }

    public ProdutoDto Produto { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<PedidoProduto, PedidoProdutoDto>()
            .ForMember(d => d.PedidoProdutoId, opt => opt.MapFrom(p => p.Id));
    }
}