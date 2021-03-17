using FluentValidation;
using reisefradragApi.Models;

namespace reisefradragApi.Validation
{
    public class ReisefradragValidator : AbstractValidator<ReisefradragRequest>
    {
        public ReisefradragValidator()
        {
            RuleFor(x => x.UtgifterBomFergeEtc)
                .NotEmpty()
                .WithMessage($"{nameof(ReisefradragRequest.UtgifterBomFergeEtc)}, kan ikke være tom.");

            RuleFor(x => x.UtgifterBomFergeEtc)
                .GreaterThan(0)
                .WithMessage($"{nameof(ReisefradragRequest.UtgifterBomFergeEtc)}, kan ikke være mindre enn 0.");

            RuleForEach(x => x.Arbeidsreiser)
                .SetValidator(new ArbeidsreiseValidator());

            RuleForEach(x => x.Besoeksreiser)
                .SetValidator(new BesoeksreiseValidator());
        }
    }

    public class ArbeidsreiseValidator : AbstractValidator<ReisefradragRequest.Arbeidsreise>
    {
        public ArbeidsreiseValidator()
        {
            RuleFor(x => x.Antall)
                .NotEmpty()
                .WithMessage(
                    $"Arbeidsreise: {nameof(ReisefradragRequest.Arbeidsreise.Antall)}, kan ikke være tom.")
                .GreaterThanOrEqualTo(1)
                .WithMessage(
                    $"Arbeidsreise: {nameof(ReisefradragRequest.Arbeidsreise.Antall)}, kan ikke være mindre enn 1.");

            RuleFor(x => x.Km)
                .NotEmpty()
                .WithMessage(
                    $"Arbeidsreise: {nameof(ReisefradragRequest.Arbeidsreise.Km)}, kan ikke være tom.")
                .GreaterThanOrEqualTo(1)
                .WithMessage(
                    $"Arbeidsreise: {nameof(ReisefradragRequest.Arbeidsreise.Km)}, kan ikke være mindre enn 1.");
        }
    }

    public class BesoeksreiseValidator : AbstractValidator<ReisefradragRequest.Besoeksreise>
    {
        public BesoeksreiseValidator()
        {
            RuleFor(x => x.Antall)
                .NotEmpty()
                .WithMessage(
                    $"Arbeidsreise: {nameof(ReisefradragRequest.Besoeksreise.Antall)}, kan ikke være tom.")
                .GreaterThanOrEqualTo(1)
                .WithMessage(
                    $"Besøksreise: {nameof(ReisefradragRequest.Besoeksreise.Antall)}, kan ikke være mindre enn 1.");

            RuleFor(x => x.Km)
                .NotEmpty()
                .WithMessage(
                    $"Arbeidsreise: {nameof(ReisefradragRequest.Besoeksreise.Km)}, kan ikke være tom.")
                .GreaterThanOrEqualTo(1)
                .WithMessage(
                    $"Besøksreise: {nameof(ReisefradragRequest.Besoeksreise.Km)}, kan ikke være mindre enn 1.");
        }
    }
}