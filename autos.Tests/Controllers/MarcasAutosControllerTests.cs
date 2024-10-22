using autos.Controllers;
using autos.Data;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using Microsoft.EntityFrameworkCore;

namespace autos.Tests.Controllers
{
    public  class MarcasAutosControllerTests
    {
        private ApplicationDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "autos")
            .Options;

            var context = new ApplicationDbContext(options);
            context.Database.EnsureCreated();

            return context;
        }
        [Fact]
        public async Task GetMarcasAutos_ReturnsCorrectData()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var controller = new MarcasAutosController(context);

            // Act
            var result = await controller.GetMarcasAutos();

            // Assert
            Assert.Equal(3, result.Value.Count());
            Assert.Contains(result.Value, m => m.Nombre == "Toyota");
            Assert.Contains(result.Value, m => m.Nombre == "Ford");
            Assert.Contains(result.Value, m => m.Nombre == "Chevrolet");
        }
    }
}
