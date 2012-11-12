using System;
using System.Linq;
using DataObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataObjectsTests
{
    [TestClass]
    public class DataObjectsTests
    {
        private IProductRepository _productRepository;
        public DataObjectsTests()
        {
            _productRepository = new ProductRepository();
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void getall_products_returns_10()
        {
            // Arrange

            // Act
            var list = _productRepository.GetAll();
            var actual = list.Count();
            var expected = 10;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void getbyid_returns_product_5()
        {
            // Arrange
            int productId = 5;

            // Act
            var product = _productRepository.GetById(productId);
            var actual = product.Name;
            var expected = "Product 5";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MyTestMethod()
        {
            // Arrange
            for (int i = 0; i < 10; i++)
            {
                int categoryId = (i % 3) + 1;

                Console.WriteLine("{0} - {1}", (i+1), categoryId);
            }
            
        }
    }
}
