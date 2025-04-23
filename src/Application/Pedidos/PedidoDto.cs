using AutoMapper;
using WebShopAPI.Application.Interfaces;
using WebShopAPI.Application.Pessoas;
using WebShopAPI.Domain.Entities.Pedidos;

namespace WebShopAPI.Application.Pedidos;

public class PedidoDto : IMapFrom<Pedido>
{
    public long PedidoId { get; set; }

    public DateTime DataAbertura { get; set; }

    public DateTime? DataFechamento { get; set; }

    public PessoaDto Pessoa { get; set; }

    public List<PedidoProdutoDto> PedidoProdutos { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Pedido, PedidoDto>()
            .ForMember(d => d.PedidoId, opt => opt.MapFrom(p => p.Id))
            .ForMember(d => d.PedidoProdutos, opt => opt.MapFrom(p => p.PedidoProdutos));
    }
}