using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunnyTranslator.Application.Interfaces;
using FunnyTranslator.Application.Interfaces.Services;
using FunnyTranslator.Application.Services;
using NSubstitute;
using NUnit.Framework;

namespace FunnyTranslator.Tests.Services
{
    [TestFixture]
    public class TranslationServiceTest
    {
        private ITranslationService _service;

        [SetUp]
        public void Init()
        {
            _service = new TranslationService();
        }

        [Test]
        [TestCase("")]
        [TestCase("   ")]
        [TestCase("         ")]
        [TestCase(null)]
        public async Task TranslateAsync_Fails_InvalidTextToTranslate(string textToTranslate)
        {
            // Arrange
            var strategyStub = Substitute.For<ITranslationStrategy>();

            // Act
            var result = await _service.TranslateAsync(textToTranslate, strategyStub);

            // Assert
            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Errors, Has.Count.EqualTo(1));
            await strategyStub.DidNotReceiveWithAnyArgs().Execute(string.Empty);
        }

    }
}
