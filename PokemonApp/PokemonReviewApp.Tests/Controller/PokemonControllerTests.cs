using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Controllers;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PokemonReviewApp.Tests.Controller
{
    public class PokemonControllerTests
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        public PokemonControllerTests()
        {
            _pokemonRepository = A .Fake<IPokemonRepository>();
            _reviewRepository = A .Fake<IReviewRepository>();
            _mapper = A .Fake<IMapper>();   
        }

        [Fact]
        public void PokemonController_GetPokemons_ReturnOk() 
        {
            //Arrange
            var pokemons = A.Fake<ICollection<PokemonDto>>();
            var pokemonList = A.Fake<List<PokemonDto>>();
            A.CallTo(() => _mapper.Map<List<PokemonDto>>(pokemons)).Returns(pokemonList);
            var controller = new PokemonController(_pokemonRepository, _reviewRepository, _mapper);


            //Act
            var result = controller.GetPokemons();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]

        public void PokemonController_CreatePokemon_ReturnOk() 
        {
            //Arrange
            int ownerId = 1;
            int catId = 2;
            var pokemonMap = A.Fake<Pokemon>();
            var pokemon = A.Fake<Pokemon>();
            var pokemonCreate = A.Fake<PokemonDto>();
            var pokemons = A.Fake<ICollection<PokemonDto>>();
            var pokemonList = A.Fake<List<PokemonDto>>();
            A.CallTo(() => _pokemonRepository.GetPokemonTrimToUpper(pokemonCreate)).Returns(pokemon);
            A.CallTo(() => _mapper.Map<Pokemon>(pokemonCreate)).Returns(pokemon);
            A.CallTo(() => _pokemonRepository.CreatePokemon(ownerId, catId,pokemonMap)).Returns(true);
            var controller = new PokemonController(_pokemonRepository , _reviewRepository, _mapper);

            //Act

            var result = controller.CreatePokemon(ownerId, catId,pokemonCreate);

            //Assert

            result.Should().NotBeNull();
        }

        [Fact]
        public void PokemonController_GetPokemonRating_ReturnOk() 
        {
            var pokeId = 1;
            var pokemons = A.Fake<ICollection<PokemonDto>>();
            var pokemonCreate = A.Fake<PokemonDto>();
            A.CallTo(() => _pokemonRepository.GetPokemonRating(pokeId)).Returns(pokeId);
            var controller = new PokemonController(_pokemonRepository, _reviewRepository, _mapper);

            var result = controller.GetPokemonRating(pokeId);


            result.Should().NotBeNull();

            
        }
    }
}
