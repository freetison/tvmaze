namespace TvMaze.ShareCommon.Validators
{
    using FluentValidation;
    using TvMaze.ShareCommon.Models.Settings;

    public class AppSettingsValidator : AbstractValidator<AppSettings>
    {
        public AppSettingsValidator()
        {
            RuleFor(x => x.ConnectionStrings).NotNull().WithMessage("ConnectionStrings section is required.");
            RuleFor(x => x.ExternalApi).NotNull().WithMessage("ExternalApi section is required.");
            RuleFor(x => x.Options).NotNull().WithMessage("Options section is required.");
            RuleFor(x => x.RabbitMq).NotNull().WithMessage("RabbitMq section is required.");

            // Validar las subclases
            RuleFor(x => x.ConnectionStrings).SetValidator(new ConnectionStringsValidator());
            RuleFor(x => x.ExternalApi).SetValidator(new ExternalApiValidator());
            RuleFor(x => x.Options).SetValidator(new OptionsValidator());
            RuleFor(x => x.RabbitMq).SetValidator(new RabbitMqValidator());
        }
    }
}