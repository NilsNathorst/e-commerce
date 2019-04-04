using FakeItEasy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class ProductServiceTests
    {
        private ICartRepository productRepository;
        private ProductService productService;

        [SetUp]
        public void SetUp()
        {
            this.productRepository = A.Fake<ICartRepository>();
            this.productService = new ProductService(this.productRepository);
        }

        [Test]
        public void Get_ReturnsResultFromRepository()
        {
            // Arrange
            var productItem = new Product
            {
                Id = 13,
                product_name = "Rocinante saves the solar system!",
                product_description = "Following the proto...",
                product_price = 13,
                product_quantity = 13,
                product_image = null
            };

            var productItems = new List<Product>
            {
                productItem
            };

            A.CallTo(() => this.productRepository.Get()).Returns(productItems);

            // Act
            var result = this.productService.Get().Single();

            // Assert
            Assert.That(result, Is.EqualTo(productItem));
        }
    }
}
