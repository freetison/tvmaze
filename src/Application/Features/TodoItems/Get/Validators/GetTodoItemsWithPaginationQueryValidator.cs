using FluentValidation;

using TvMaze.Application.Features.TodoItems.Get.EventHandlers;

namespace TvMaze.Application.Features.TodoItems.Get.Validators
{
    /// <summary>
    /// Defines the <see cref="GetTodoItemsWithPaginationQueryValidator" />.
    /// </summary>
    public sealed class GetTodoItemsWithPaginationQueryValidator : AbstractValidator<GetTodoItemsWithPaginationQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetTodoItemsWithPaginationQueryValidator"/> class.
        /// </summary>
        public GetTodoItemsWithPaginationQueryValidator()
        {
            RuleFor(x => x.ListId)
                .GreaterThanOrEqualTo(0).WithMessage("ListId is required.");

            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}
