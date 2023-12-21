using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using PokemonReviewApp.Controllers;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PokemonReviewApp.Tests.Controller
{
    public class CountryControllerTests
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public CountryControllerTests()
        {
            _countryRepository = A.Fake<ICountryRepository>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public void CountryController_GetCountries_ReturnOk() 
        {
            var countri = A.Fake<ICollection<CountryDto>>();
            var countries = A.Fake<List<CountryDto>>();

            A.CallTo(() => _mapper.Map<List<CountryDto>>(countri)).Returns(countries);

            var controller = new CountryController(_countryRepository ,_mapper);

            var result = controller.GetCountries();

            result.Should().NotBeNull();
        }
    }
}
