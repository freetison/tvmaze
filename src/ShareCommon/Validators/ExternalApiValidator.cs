namespace TvMaze.ShareCommon.Validators
{
    using FluentValidation;
    using TvMaze.ShareCommon.Models.Settings;

    public class ExternalApiValidator : AbstractValidator<ExternalApi>
    {
        public ExternalApiValidator()
        {
            RuleFor(x => x.BaseUrl).NotEmpty().WithMessage("Base URL for ExternalApi is required.");
        }
    }
}