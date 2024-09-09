namespace TvMaze.ShareCommon.Validators
{
    using FluentValidation;
    using TvMaze.ShareCommon.Models.Settings;

    public class ConnectionStringsValidator : AbstractValidator<ConnectionStrings>
    {
        public ConnectionStringsValidator()
        {
            RuleFor(x => x.Redis).NotEmpty().WithMessage("Redis connection string is required.");
            RuleFor(x => x.SqlServer).NotEmpty().WithMessage("SqlServer connection string is required.");
        }
    }
}