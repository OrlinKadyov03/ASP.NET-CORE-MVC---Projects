using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using RaceRunApp.Controllers;
using RaceRunApp.Interfaces;
using RaceRunApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceRunApp.Tests.Controller
{
    public class ClubControllerTests
    {
        private ClubController _clubController;
        private IClubRepository _clubRepository;
        private IPhotoService _photoService;
        private HttpContextAccessor _httpContextAccessor;
        public ClubControllerTests()
        {
            _clubRepository = A.Fake<IClubRepository>();
            _photoService = A.Fake<IPhotoService>();
            _httpContextAccessor = A.Fake<HttpContextAccessor>();

            _clubController = new ClubController(_clubRepository,_photoService,_httpContextAccessor);
        }

        [Fact]

        public void ClubController_Index_ReturnSuccess() 
        {
            var clubs = A.Fake<IEnumerable<Club>>();
            A.CallTo(() => _clubRepository.GetAll()).Returns(clubs);

            var result  = _clubController.Index();
            
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void ClubController_Detail_ReturnSuccess() 
        {
            var id = 1;
            var club = A.Fake<Club>();
            A.CallTo(() => _clubRepository.GetIdByAsync(id)).Returns(club);

            var result = _clubController.Detail(id);

            result.Should().BeOfType<Task<IActionResult>>();
        }
    }
}
