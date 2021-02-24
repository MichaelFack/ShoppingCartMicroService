using System;
using Xunit;
using ShoppingCartMicroService.Controllers;
using ShoppingCartMicroService.Models;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;

namespace ShoppingCartMicroService.Tests
{
    [Collection("Controller integration tests - New Db")]
    public class ShoppingCartControllerNewCartIntegrationTest
    {
        static Mock<ILogger<ShoppingCartController>> loggerMock = new Mock<ILogger<ShoppingCartController>>();
        public ShoppingCartController subject = new ShoppingCartController(loggerMock.Object); /* Once DB is integrated, it should be mocked or a test DB should be used */
        [Fact]
        public void Basket_isInitiallyEmpty()
        {
            /* Arrange */

            /* Act */
            var res = subject.Basket();

            /* Assert */
            Assert.Empty(res);
        }

        [Fact]
        public void Add_something_doesntThrow()
        {
            /* Arrange */
            Item item = new Item();
            item.Name = "something";

            /* Act */
            subject.AddItem(item);

            /* Assert */
            Assert.True(true);
        }

        [Fact]
        public void Add_something_then_Basket_returnsMapFromSomethingToOne()
        {
            /* Arrange */
            Item item = new Item("something");
            var expected = new Dictionary<Item, int>();
            expected.Add(item, 1);

            /* Act */
            subject.AddItem(item);
            var res = subject.Basket();

            /* Assert */
            Assert.Equal(expected, res);
        }
    }

    [Collection("Controller integration tests - Db with items")]
    public class ShoppingCartControllerCartWithItemsIntegrationTest
    {
        static Mock<ILogger<ShoppingCartController>> loggerMock = new Mock<ILogger<ShoppingCartController>>();
        public ShoppingCartController subject = new ShoppingCartController(loggerMock.Object); /* Once DB is integrated, it should be mocked or a test DB should be used */

        private Item item = new Item("Now");
        private Item item1 = new Item("Something");
        private Item item2 = new Item("Completely different");

        public ShoppingCartControllerCartWithItemsIntegrationTest()
        {
            subject.AddItem(item); /* I don't like repeating code in every test. The class name informs of the constructor doing some work w.r.t. putting things into the cart.*/
            subject.AddItem(item1);
            subject.AddItem(item2);

            var expectedInitialState = new Dictionary<Item, int>();
            expectedInitialState.Add(item, 1);
            expectedInitialState.Add(item1, 1);
            expectedInitialState.Add(item2, 1);
            Assert.Equal(expectedInitialState, subject.Basket());
        }

        [Fact]
        public void Basket_isNotEmpty()
        {
            /* Arrange */

            /* Act */
            var res = subject.Basket();

            /* Assert */
            Assert.NotEmpty(res);
        }

        [Fact]
        public void Remove_item_succeeds_then_Basket_doesntContainItemAnymore()
        {
            /* Arrange */
            var expected = new Dictionary<Item, int>();
            expected.Add(item1, 1);
            expected.Add(item2, 1);

            /* Act */
            var success = subject.RemoveItem(item);
            var res = subject.Basket();

            /* Assert */
            Assert.True(success);
            Assert.Equal(expected, res);
        }

    }
}
