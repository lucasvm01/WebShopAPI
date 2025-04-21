using FluentValidation;
using WebShopAPI.Domain.Interfaces.Infrastructure;

namespace WebShopAPI.Application.Common;

public class ValidatorBase<T> : AbstractValidator<T>
{
    protected ValidatorBase(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }

    protected IUnitOfWork UnitOfWork { get; }
}
