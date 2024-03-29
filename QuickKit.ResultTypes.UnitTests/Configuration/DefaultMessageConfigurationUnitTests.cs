﻿using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using QuickKit.ResultTypes.Configuration;
using QuickKit.ResultTypes.Exceptions;
using QuickKit.Shared.Exceptions;
using QuickKit.Shared.Exceptions.Base;

namespace QuickKit.ResultTypes.UnitTests.Configuration
{
    public class InvalidExceptionForTest : KitException, IException
    {
        public InvalidExceptionForTest(string? message) : base(message)
        {
        }

        public static string? DefaultMessage { get; set; } = "invalidMessage";
    }
    public class DefaultMessageConfigurationUnitTests
    {
        [Fact]
        public void CustomDefaultMessageFor_EntityNotFound_ShouldComplete()
        {
            // Arrange
            var expected = "test";

            // Act
            DefaultMessageExceptionConfiguration.CustomDefaultMessageFor<EntityNotFoundException>(Arg.Any<IServiceCollection>(), expected);
            var actual = new EntityNotFoundException(Arg.Any<string>());

            // Assert
            Assert.Equal(expected, actual.Message);
        }

        [Fact]
        public void CustomDefaultMessageFor_NotFound_ShouldComplete()
        {
            // Arrange
            var expected = "test";

            // Act
            DefaultMessageExceptionConfiguration.CustomDefaultMessageFor<NotFoundException>(Arg.Any<IServiceCollection>(), expected);
            var actual = new NotFoundException(Arg.Any<string>());

            // Assert
            Assert.Equal(expected, actual.Message);
        }

        [Fact]
        public void CustomDefaultMessageFor_InvalidArgumentResultException_ShouldComplete()
        {
            // Arrange
            var expected = "test";

            // Act
            DefaultMessageExceptionConfiguration.CustomDefaultMessageFor<InvalidArgumentResultException>(Arg.Any<IServiceCollection>(), expected);
            var actual = new InvalidArgumentResultException(Arg.Any<string>());

            // Assert
            Assert.Equal(expected, actual.Message);
        }

        [Fact]
        public void CustomDefaultMessageFor_SnapshotNullException_ShouldComplete()
        {
            // Arrange
            var expected = "test";

            // Act
            DefaultMessageExceptionConfiguration.CustomDefaultMessageFor<SnapshotNullException>(Arg.Any<IServiceCollection>(), expected);
            var actual = new SnapshotNullException(Arg.Any<string>());

            // Assert
            Assert.Equal(expected, actual.Message);
        }

        [Fact]
        public void CustomDefaultMessageFor_ValidationFailureException_ShouldComplete()
        {
            // Arrange
            var expected = "test";

            // Act
            DefaultMessageExceptionConfiguration.CustomDefaultMessageFor<ValidationFailureException>(Arg.Any<IServiceCollection>(), expected);
            var actual = new ValidationFailureException(Arg.Any<ValidationResult>(),
                                                        Arg.Any<string>());

            // Assert
            Assert.Equal(expected, actual.Message);
        }

        [Fact]
        public void CustomDefaultMessage_WhenExceptionNotRegistred_ShouldFail()
        {
            // Arrange
            var expected = InvalidExceptionForTest.DefaultMessage;

            // Act
            var actual = new InvalidExceptionForTest(Arg.Any<string>()).Message;

            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                DefaultMessageExceptionConfiguration.CustomDefaultMessageFor<InvalidExceptionForTest>(Arg.Any<IServiceCollection>(),
                                                                                             Arg.Any<string>());
            });

        }
    }
}
