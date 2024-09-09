namespace TvMaze.ShareCommon.Validators
{
    using FluentValidation;
    using TvMaze.ShareCommon.Models.Settings;

    public class OptionsValidator : AbstractValidator<Options>
    {
        public OptionsValidator()
        {
            RuleFor(x => x.ApiKey).NotEmpty().WithMessage("ApiKey is required.");
            RuleFor(x => x.RequestLimitPerMinutes)
                .GreaterThan(0).WithMessage("RequestLimitPerMinutes must be greater than 0.");
        }
    }
}