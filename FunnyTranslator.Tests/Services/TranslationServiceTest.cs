using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunnyTranslator.Application.Interfaces;
using FunnyTranslator.Application.Interfaces.Services;
using FunnyTranslator.Application.Services;
using FunnyTranslator.Core.Interfaces;
using log4net;
using NSubstitute;
using NUnit.Framework;

namespace FunnyTranslator.Tests.Services
{
    [TestFixture]
    public class TranslationServiceTest
    {
        private ITranslationService _service;
        private ITranslationStrategy _strategyStub;

        [SetUp]
        public void Init()
        {
            var loggerStub = Substitute.For<ILog>();
            var strategyFactoryStub = Substitute.For<ITranslationStrategyFactory>();

            _strategyStub = Substitute.For<ITranslationStrategy>();
            strategyFactoryStub.CreateForMethod(Arg.Is("leetspeak")).Returns(_strategyStub);
            strategyFactoryStub.CreateForMethod(Arg.Is("NotExistingMethod")).Returns((ITranslationStrategy)null);

            _service = new TranslationService(strategyFactoryStub, loggerStub);
        }

        [Test]
        [TestCase("")]
        [TestCase("   ")]
        [TestCase("         ")]
        [TestCase(null)]
        public async Task TranslateAsync_Fails_InvalidTextToTranslate(string textToTranslate)
        {
            // Arrange

            // Act
            var result = await _service.TranslateAsync(textToTranslate, "leetspeak");

            // Assert
            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Errors, Has.Count.EqualTo(1));
            await _strategyStub.DidNotReceiveWithAnyArgs().Execute(string.Empty);
        }

        [Test]
        [TestCase("NotExistingMethod")]
        public async Task TranslateAsync_Fails_NotSupportedTranslationMethod(string translationMethod)
        {
            // Arrange

            // Act
            var result = await _service.TranslateAsync("valid text", translationMethod);

            // Assert
            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Errors, Has.Count.EqualTo(1));
            await _strategyStub.DidNotReceiveWithAnyArgs().Execute(string.Empty);
        }

    }
}
