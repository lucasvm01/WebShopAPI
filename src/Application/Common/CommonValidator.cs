using FluentValidation;
using FluentValidation.Validators;
using WebShopAPI.Domain.Entities;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Common;

public static class CommonValidator
{
    public static IRuleBuilderOptions<T, long> MustExist<T, TEntity>(this IRuleBuilder<T, long> ruleBuilder, IUnitOfWork unitOfWork) where TEntity : BaseEntity<long>
    {
        return ruleBuilder.MustExist<T, TEntity, long>(unitOfWork);
    }

    public static IRuleBuilderOptions<T, TKey> MustExist<T, TEntity, TKey>(this IRuleBuilder<T, TKey> ruleBuilder, IUnitOfWork unitOfWork) where TEntity : BaseEntity<TKey>
    {
        if (unitOfWork == null)
        {
            throw new ArgumentNullException(nameof(unitOfWork));
        }

        return ruleBuilder.SetAsyncValidator(new MustExistValidator<T, TEntity, TKey>(unitOfWork));
    }
}

public class MustExistValidator<T, TEntity, TKey> : AsyncPropertyValidator<T, TKey> where TEntity : BaseEntity<TKey>
{
    private readonly IUnitOfWork _unitOfWork;

    private string _message;

    public MustExistValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _message = "Registro não encontrado.";
    }

    public override string Name => "MustExistValidator";

    public override async Task<bool> IsValidAsync(
        ValidationContext<T> context,
        TKey value,
        CancellationToken cancellation)
    {
        switch (value)
        {
            case long and <= 0:
            case int and <= 0:
                _message = "Identificador inválido.";
                return false;
        }

        var repository = _unitOfWork.GetRepository<TEntity>();

        return await repository.ExistsAsync(m => m.Id.Equals(value), cancellation);
    }

    protected override string GetDefaultMessageTemplate(string errorCode) => _message;
}