using FluentValidation;

using TvMaze.Application.Features.TodoItems.Create.EventHandlers;

namespace TvMaze.Application.Features.TodoItems.Create.Validators
{
    /// <summary>
    /// Defines the <see cref="CreateTodoItemCommandValidator" />.
    /// </summary>
    public sealed class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTodoItemCommandValidator"/> class.
        /// </summary>
        public CreateTodoItemCommandValidator()
        {
            RuleFor(v => v.Title)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}
