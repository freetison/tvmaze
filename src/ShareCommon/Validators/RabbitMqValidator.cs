namespace TvMaze.ShareCommon.Validators
{
    using FluentValidation;
    using TvMaze.ShareCommon.Models.Settings;

    public class RabbitMqValidator : AbstractValidator<RabbitMqSettings>
    {
        public RabbitMqValidator()
        {
            RuleFor(x => x.RabbitMqHostName).NotEmpty().WithMessage("RabbitMqHostName is required.");
            RuleFor(x => x.RabbitMqPort).GreaterThan(0).WithMessage("RabbitMqPort must be greater than 0.");
            RuleFor(x => x.RabbitMqConcurrency).GreaterThan(0).WithMessage("RabbitMqConcurrency must be greater than 0.");
            RuleFor(x => x.RabbitMqUserName).NotEmpty().WithMessage("RabbitMqUserName is required.");
            RuleFor(x => x.RabbitMqPassword).NotEmpty().WithMessage("RabbitMqPassword is required.");
            RuleFor(x => x.RabbitMqQueueName).NotEmpty().WithMessage("RabbitMqQueueName is required.");
        }
    }
}