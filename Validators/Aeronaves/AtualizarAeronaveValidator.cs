using CiaAerea.Contexts;
using CiaAerea.ViewModels;
using FluentValidation;

public class AtualizarAeronaveValidator : AbstractValidator<AtualizarAeronaveViewModel>
{
    private readonly CiaAereaContexts _contexts;

    public AtualizarAeronaveValidator(CiaAereaContexts contexts) {
        _contexts = contexts;

        RuleFor(a => a.Fabricante)
            .NotEmpty().WithMessage("É necessário informar o nome do fabricante.")
            .MaximumLength(50).WithMessage("O nome do fabricante deve ter no máximo 50 caracteres");

        RuleFor(a => a.Modelo)
            .NotEmpty().WithMessage("É necessário informar o modelo da aeronave.")
            .MaximumLength(50).WithMessage("O modelo deve ter no máximo 50 caracteres");

        RuleFor(a => a.Codigo)
            .NotEmpty().WithMessage("É necessário informar o código da aeronave.")
            .MaximumLength(10).WithMessage("O código da aeronave deve ter no máximo 10 caracteres");

        RuleFor(a => a)
            .Must(aeronave => _contexts.Aeronaves.Count(a => a.Codigo == aeronave.Codigo && a.Id != aeronave.Id) == 0).WithMessage("Já existe uma aeronave com este código.");
    }
    
}