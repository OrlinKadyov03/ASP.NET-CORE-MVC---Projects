using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using RaceRunApp.Controllers;
using RaceRunApp.Data;
using RaceRunApp.Data.Enum;
using RaceRunApp.Models;
using RaceRunApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceRunApp.Tests.Repository
{
    public class ClubRepositoryTests
    {

        public async Task<ApplicationDbContext> GetDbContext() 
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new ApplicationDbContext(options);
            databaseContext.Database.EnsureCreated();
            if (await databaseContext.Clubs.CountAsync()<0)
            {
                for (int i = 0; i < 10; i++)
                {
                    databaseContext.Clubs.Add(
                    new Club()
                 {
                   Title = "Running Club 3",
                   Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                   Description = "This is the description of the first club",
                   ClubCategory = ClubCategory.City,
                   Address = new Address()
                   {
                       Street = "123 Main St",
                       City = "Michigan",
                       State = "NC"
                   }
                  });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }

        [Fact]
        public async void ClubRepository_Add_ReturnsBool() 
        {
            // Arange
            var club = new Club()
            {
                Title = "Running Club 3",
                Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                Description = "This is the description of the first club",
                ClubCategory = ClubCategory.City,
                Address = new Address()
                {
                    Street = "123 Main St",
                    City = "Michigan",
                    State = "NC"
                }
            };
            var dbContext = await GetDbContext();
            var clubRepository = new ClubRepository(dbContext);

            // Act
            var result = clubRepository.Add(club);

            // Assert 

            result.Should().BeTrue();
        }

        [Fact]
        public async void ClubRepository_GetIdByAsync_ReturnsClub() 
        {
            //Arrange
            var id = 1;
            var dbContext = await GetDbContext();
            var clubRepository = new ClubRepository(dbContext);

            //Act
            var result = clubRepository.GetIdByAsync(id);
            //Assert

            result.Should().NotBeNull();
            result.Should().BeOfType<Task<Club>>();
        }
    }
}
