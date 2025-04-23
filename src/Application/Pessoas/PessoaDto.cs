using AutoMapper;
using WebShopAPI.Application.Interfaces;
using WebShopAPI.Domain.Entities.Pessoas;

namespace WebShopAPI.Application.Pessoas;

public class PessoaDto : IMapFrom<Pessoa>
{
    public long PessoaId { get; set; }

    public string Nome { get; set; }

    public string CPF { get; set; }

    public string Email { get; set; }

    public TipoPessoa TipoPessoa { get; set; }

    public bool IsAtivo { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Pessoa, PessoaDto>()
            .ForMember(d => d.PessoaId, opt => opt.MapFrom(p => p.Id))
            .ForMember(d => d.Nome, opt => opt.MapFrom(p => p.Nome))
            .ForMember(d => d.CPF, opt => opt.MapFrom(p => p.CPF))
            .ForMember(d => d.Email, opt => opt.MapFrom(p => p.Email))
            .ForMember(d => d.TipoPessoa, opt => opt.MapFrom(p => p.TipoPessoa))
            .ForMember(d => d.IsAtivo, opt => opt.MapFrom(p => p.IsAtivo));
    }
}
