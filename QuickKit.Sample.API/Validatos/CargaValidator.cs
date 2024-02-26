using FluentValidation;
using QuickKit.Sample.API.Entities;
using QuickKit.Shared.Validations.Common;

namespace QuickKit.Sample.API.Validatos;

public class CargaValidator : Validator<CargaEntity>
{
    public CargaValidator()
    {
        _ = RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome é obrigatório");
        _ = RuleFor(x => x.Descricao).NotEmpty().WithMessage("Descrição é obrigatória");
    }
}
