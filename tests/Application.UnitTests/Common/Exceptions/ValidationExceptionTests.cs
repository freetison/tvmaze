namespace TvMaze.Application.UnitTests.Common.Exceptions
{
    using FluentValidation.Results;
    using Shouldly;
    using TvMaze.ShareCommon.Exceptions;
    using Xunit;

    /// <summary>
    /// Defines the <see cref="ValidationExceptionTests" />.
    /// </summary>
    public class ValidationExceptionTests
    {
        /// <summary>
        /// The DefaultConstructorCreatesAnEmptyErrorDictionary.
        /// </summary>
        [Fact]
        public void DefaultConstructorCreatesAnEmptyErrorDictionary()
        {
            var actual = new ValidationException().Errors;

            actual.Keys.ShouldBeEquivalentTo(Array.Empty<string>());
        }

        /// <summary>
        /// The SingleValidationFailureCreatesASingleElementErrorDictionary.
        /// </summary>
        [Fact]
        public void SingleValidationFailureCreatesASingleElementErrorDictionary()
        {
            var failures = new List<ValidationFailure>
        {
            new("Age", "must be over 18"),
        };

            var actual = new ValidationException(failures).Errors;

            actual.Keys.ShouldBeEquivalentTo(new string[] { "Age" });
            actual["Age"].ShouldBeEquivalentTo(new string[] { "must be over 18" });
        }

        /// <summary>
        /// The MulitpleValidationFailureForMultiplePropertiesCreatesAMultipleElementErrorDictionaryEachWithMultipleValues.
        /// </summary>
        [Fact]
        public void MulitpleValidationFailureForMultiplePropertiesCreatesAMultipleElementErrorDictionaryEachWithMultipleValues()
        {
            var failures = new List<ValidationFailure>
        {
            new("Age", "must be 18 or older"),
            new("Age", "must be 25 or younger"),
            new("Password", "must contain at least 8 characters"),
            new("Password", "must contain a digit"),
            new("Password", "must contain upper case letter"),
            new("Password", "must contain lower case letter"),
        };

            var actual = new ValidationException(failures).Errors;

            actual.Keys.ShouldBeEquivalentTo(new string[] { "Password", "Age" });

            actual["Age"].ShouldBeEquivalentTo(new string[]
            {
            "must be 25 or younger",
            "must be 18 or older",
            });

            actual["Password"].ShouldBeEquivalentTo(new string[]
            {
            "must contain lower case letter",
            "must contain upper case letter",
            "must contain at least 8 characters",
            "must contain a digit",
            });
        }
    }
}