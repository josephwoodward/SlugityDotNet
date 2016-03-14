﻿using SeoUrlSanitizer.Configuration;
using Shouldly;
using Xunit;

namespace SeoUrlSanitizer.Tests
{
    public class FormatterTests
    {
        [Fact]
        private void ShouldBeLowerCase()
        {
            var configuration = new SlugConfiguration
            {
                TextCase = TextCase.LowerCase
            };

            var sanitizer = new SlugCreator(configuration);

            string before = "THIS SHOULD BE LOWERCASE";
            string after = "this should be lowercase";
            
            string result = sanitizer.Sanitize(before);
            result.ShouldBe(after);
        }

        [Fact]
        private void ShouldBeUpperCase()
        {
            var configuration = new SlugConfiguration
            {
                TextCase = TextCase.UpperCase
            };

            var sanitizer = new SlugCreator(configuration);

            string before = "this should be lowercase";
            string after = "THIS SHOULD BE LOWERCASE";

            string result = sanitizer.Sanitize(before);
            result.ShouldBe(after);
        }

        [Fact]
        private void ShouldBeSeparatedByHyphens()
        {
            var configuration = new SlugConfiguration
            {
                TextCase = TextCase.LowerCase,
                StringSeparator = '-'
            };

            var sanitizer = new SlugCreator(configuration);

            string before = "this should be lowercase";
            string after = "this-should-be-lowercase";

            string result = sanitizer.Sanitize(before);
            result.ShouldBe(after);
        }

        [Fact]
        private void ShouldBeMaxLength()
        {
            var configuration = new SlugConfiguration
            {
                TextCase = TextCase.LowerCase,
                StringSeparator = '-',
                MaxLength = 23
            };

            var sanitizer = new SlugCreator(configuration);

            string before = "This should be replaced";
            string after = "this-should-be-replaced";

            string result = sanitizer.Sanitize(before);
            result.ShouldBe(after);
        }

        [Fact]
        private void ShouldRemoveStopWords()
        {
            var configuration = new SlugConfiguration
            {
                TextCase = TextCase.LowerCase,
                StringSeparator = ' '
            };

            var sanitizer = new SlugCreator(configuration);

            string before = "This then that should remain";
            string after = "this should remain";

            string result = sanitizer.Sanitize(before);
            result.ShouldBe(after);
        }


    }
}