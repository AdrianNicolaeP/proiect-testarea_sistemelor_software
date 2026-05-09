using System;
using TS_facultate.Services;
using Xunit;

namespace TS_proiect.Tests
{
    public class SalaryServiceTests
    {
        private readonly SalaryService _service;

        public SalaryServiceTests()
        {
            _service = new SalaryService();
        }

        public void CalculeazaNet_BrutZero_AruncaExceptie()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                _service.CalculeazaNet(0, "RO"));

            Assert.Equal("Salariul brut trebuie să fie pozitiv", ex.Message);
        }

        [Fact]
        public void CalculeazaNet_Romania_ReturneazaValoareCorecta()
        {
            double brut = 5000;

            var cas = brut * 0.25;
            var cass = brut * 0.10;
            var impozit = (brut - cas - cass) * 0.10;

            var expected = brut - cas - cass - impozit;

            var result = _service.CalculeazaNet(brut, "RO");

            Assert.Equal(expected, result, 2);
        }

        [Fact]
        public void CalculeazaNet_Germania_Sub3000_Returneaza70LaSuta()
        {
            double brut = 2999;
            double expected = brut * 0.7;

            var result = _service.CalculeazaNet(brut, "DE");

            Assert.Equal(expected, result, 2);
        }

        [Fact]
        public void CalculeazaNet_Germania_3000_Returneaza60LaSuta()
        {
            double brut = 3000;
            double expected = brut * 0.6;

            var result = _service.CalculeazaNet(brut, "DE");

            Assert.Equal(expected, result, 2);
        }

        [Fact]
        public void CalculeazaNet_SUA_ReturneazaValoareCorecta()
        {
            double brut = 5000;
            double expected = brut - 500 - (brut * 0.2);

            var result = _service.CalculeazaNet(brut, "US");

            Assert.Equal(expected, result, 2);
        }

        [Fact]
        public void CalculeazaNet_TaraInvalida_AruncaExceptie()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                _service.CalculeazaNet(5000, "FR"));

            Assert.Equal("Țară invalidă", ex.Message);
        }

        [Theory]
        [InlineData("RO")]
        [InlineData("DE")]
        [InlineData("US")]
        public void CalculeazaNet_TariValide_NuAruncaExceptie(string tara)
        {
            var exception = Record.Exception(() =>
                _service.CalculeazaNet(5000, tara));

            Assert.Null(exception);
        }

        [Fact]
        public void CalculeazaNet_TaraGoala_AruncaExceptie()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                _service.CalculeazaNet(5000, ""));

            Assert.Equal("Țara este obligatorie", ex.Message);
        }

        [Fact]
        public void CalculeazaNet_TaraNull_AruncaExceptie()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                _service.CalculeazaNet(5000, null));

            Assert.Equal("Țara este obligatorie", ex.Message);
        }


    }
}
