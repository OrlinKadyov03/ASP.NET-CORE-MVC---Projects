using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Controllers;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;
using PokemonReviewApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PokemonReviewApp.Tests.Controller
{
    
    public class OwnerControllerTests
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public OwnerControllerTests()
        {
            _ownerRepository = A.Fake<IOwnerRepository>();
            _countryRepository = A.Fake<ICountryRepository>();  
            _mapper = A.Fake<IMapper>();

        }

        [Fact]

        public void OwnerController_GetOwners_ReturnOk() 
        {
            var owners = A.Fake<ICollection<OwnerDto>>();
            var ownerList = A.Fake<List<OwnerDto>>();

            A.CallTo(() => _mapper.Map<List<OwnerDto>>(owners)).Returns(ownerList);

            var controller = new OwnerController(_ownerRepository,_countryRepository,_mapper);

            var result = controller.GetOwners();

            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

    }
}
