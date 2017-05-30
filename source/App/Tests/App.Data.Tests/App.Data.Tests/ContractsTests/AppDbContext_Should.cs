using System.Linq;
using NUnit.Framework;
using System.Reflection;

namespace App.Data.Tests.ContractsTests
{
    [TestFixture]
    public class AppDbContext_Should
    {
        [Test]
        public void HaveSetsFor_AllDbModels()
        {
            var modelAssemblyName = "App.Data.Medels";

            // Arrange
            var expected = Assembly.Load(modelAssemblyName)
                .GetTypes()
                .Where(x => x.IsClass && !x.IsAbstract );

            // Act
            var result = typeof(AppDbContext)
                .GetProperties()
                .Select(x => x.PropertyType)
                .Where(x => x.Name.Contains("Set"))
                .Select(x => x.GetGenericArguments().SingleOrDefault());

            // Assert
            CollectionAssert.AreEquivalent(expected, result);
        }
    }
}
