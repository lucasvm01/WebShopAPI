﻿using WebShopAPI.Domain.Models.Produtos;
using WebShopAPI.Domain.Validations;

namespace WebShopAPI.Domain.Entities.Produtos;

public partial class Produto
{
    private static List<ValidacaoDominio> PodeCadastrarProduto(ProdutoModel model)
    {
        List<ValidacaoDominio> falhas = new();

        if (string.IsNullOrWhiteSpace(model.Descricao))
        {
            falhas.Add(new ValidacaoDominio(model.Descricao, "Campo está vazio"));
        }

        if (model.QuantidadeTotal < 0)
        {
            falhas.Add(new ValidacaoDominio(model.QuantidadeTotal.ToString(), "Quantidade deve ser maior que zero"));
        }

        return falhas;
    }

    private static List<ValidacaoDominio> PodeCorrigirDescricaoProduto(string descricao)
    {
        List<ValidacaoDominio> falhas = new();

        if(string.IsNullOrWhiteSpace(descricao))
        {
            falhas.Add(new ValidacaoDominio(descricao, "Campo está vazio"));
        }

        return falhas;
    }

    private static List<ValidacaoDominio> PodeAlterarQuantidadeProduto(long quantidade)
    {
        List<ValidacaoDominio> falhas = new();

        if (quantidade < 0)
        {
            falhas.Add(new ValidacaoDominio(quantidade.ToString(), "Quantidade deve ser maior que zero"));
        }

        return falhas;
    }

    private static List<ValidacaoDominio> PodeDiminuirQuantidadeProduto(long quantidadeAtual, long quantidadeDimiuir)
    {
        List<ValidacaoDominio> falhas = new();

        if (quantidadeAtual - quantidadeDimiuir < 0)
        {
            falhas.Add(new ValidacaoDominio(quantidadeAtual.ToString(), "Não há quantidade necessária do produto"));
        }

        return falhas;
    }
}