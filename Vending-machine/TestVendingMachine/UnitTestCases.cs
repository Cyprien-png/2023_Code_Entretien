using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Vending_machine;

namespace TestVendingMachine
{
    [TestClass]
    public class UnitTestCases
    {
        [TestMethod]
        public void test1()
        {
            Machine vendingMachine = new Machine();
            vendingMachine.AddArticle(new Article("Smarlies", "A01", 10, (float)1.60));
            vendingMachine.AddArticle(new Article("Carampar", "A02", 5, (float)0.60));
            vendingMachine.AddArticle(new Article("Avril", "A03", 2, (float)2.10));
            vendingMachine.AddArticle(new Article("KokoKola", "A04", 1, (float)2.95));

            vendingMachine.insert((float)3.40);
            string message = vendingMachine.choose("A01");
            

            Assert.AreEqual(1.80, vendingMachine.getChange(), 0.01);
            Assert.AreEqual("Vending Smarlies", message);
        }

        [TestMethod]
        public void test2()
        {
            Machine vendingMachine = new Machine();
            vendingMachine.AddArticle(new Article("Smarlies", "A01", 10, (float)1.60));
            vendingMachine.AddArticle(new Article("Carampar", "A02", 5, (float)0.60));
            vendingMachine.AddArticle(new Article("Avril", "A03", 2, (float)2.10));
            vendingMachine.AddArticle(new Article("KokoKola", "A04", 1, (float)2.95));

            vendingMachine.insert((float)2.10);
            string message = vendingMachine.choose("A03");


            Assert.AreEqual(0, vendingMachine.getChange(), 0.01);
            Assert.AreEqual(2.10, vendingMachine.getBalance(), 0.01);
            Assert.AreEqual("Vending Avril", message);
        }

        [TestMethod]
        public void test3()
        {
            Machine vendingMachine = new Machine();
            vendingMachine.AddArticle(new Article("Smarlies", "A01", 10, (float)1.60));
            vendingMachine.AddArticle(new Article("Carampar", "A02", 5, (float)0.60));
            vendingMachine.AddArticle(new Article("Avril", "A03", 2, (float)2.10));
            vendingMachine.AddArticle(new Article("KokoKola", "A04", 1, (float)2.95));

            string message = vendingMachine.choose("A01");


            Assert.AreEqual("Not enough money!", message);
        }

        [TestMethod]
        public void test4()
        {
            Machine vendingMachine = new Machine();
            vendingMachine.AddArticle(new Article("Smarlies", "A01", 10, (float)1.60));
            vendingMachine.AddArticle(new Article("Carampar", "A02", 5, (float)0.60));
            vendingMachine.AddArticle(new Article("Avril", "A03", 2, (float)2.10));
            vendingMachine.AddArticle(new Article("KokoKola", "A04", 1, (float)2.95));

            vendingMachine.insert((float)1.00);
            string firstMessage = vendingMachine.choose("A01");
            float firstChange = vendingMachine.getChange();
            string secondMessage = vendingMachine.choose("A02");
            float secondChange = vendingMachine.getChange();


            Assert.AreEqual("Not enough money!", firstMessage);
            Assert.AreEqual(1, firstChange, 0.01);
            Assert.AreEqual("Vending Carampar", secondMessage);
            Assert.AreEqual(0.40, secondChange, 0.01);
        }

        [TestMethod]
        public void test5()
        {
            Machine vendingMachine = new Machine();
            vendingMachine.AddArticle(new Article("Smarlies", "A01", 10, (float)1.60));
            vendingMachine.AddArticle(new Article("Carampar", "A02", 5, (float)0.60));
            vendingMachine.AddArticle(new Article("Avril", "A03", 2, (float)2.10));
            vendingMachine.AddArticle(new Article("KokoKola", "A04", 1, (float)2.95));

            vendingMachine.insert((float)1.00);
            string message = vendingMachine.choose("A05");


            Assert.AreEqual("Invalid selection!", message);
        }

        [TestMethod]
        public void test6()
        {
            Machine vendingMachine = new Machine();
            vendingMachine.AddArticle(new Article("Smarlies", "A01", 10, (float)1.60));
            vendingMachine.AddArticle(new Article("Carampar", "A02", 5, (float)0.60));
            vendingMachine.AddArticle(new Article("Avril", "A03", 2, (float)2.10));
            vendingMachine.AddArticle(new Article("KokoKola", "A04", 1, (float)2.95));

            vendingMachine.insert((float)6.00);
            string firstMessage = vendingMachine.choose("A04");
            string secondMessage = vendingMachine.choose("A04");


            Assert.AreEqual("Vending KokoKola", firstMessage);
            Assert.AreEqual("Item KokoKola: Out of stock!", secondMessage);
            Assert.AreEqual(3.05, vendingMachine.getChange(), 0.01);
        }

        [TestMethod]
        public void test7()
        {
            Machine vendingMachine = new Machine();
            vendingMachine.AddArticle(new Article("Smarlies", "A01", 10, (float)1.60));
            vendingMachine.AddArticle(new Article("Carampar", "A02", 5, (float)0.60));
            vendingMachine.AddArticle(new Article("Avril", "A03", 2, (float)2.10));
            vendingMachine.AddArticle(new Article("KokoKola", "A04", 1, (float)2.95));

            vendingMachine.insert((float)6.00);
            string firstMessage = vendingMachine.choose("A04");
            vendingMachine.insert((float)6.00);
            string secondMessage = vendingMachine.choose("A04");
            string thirdMessage = vendingMachine.choose("A01");
            string fourthMessage = vendingMachine.choose("A02");
            string fifthMessage = vendingMachine.choose("A02");


            Assert.AreEqual("Vending KokoKola", firstMessage);
            Assert.AreEqual("Item KokoKola: Out of stock!", secondMessage);
            Assert.AreEqual("Vending Smarlies", thirdMessage);
            Assert.AreEqual("Vending Carampar", fourthMessage);
            Assert.AreEqual("Vending Carampar", fifthMessage);
            Assert.AreEqual(6.25, vendingMachine.getChange(), 0.01);
            Assert.AreEqual(5.75, vendingMachine.getBalance(), 0.01);
        }
    }
}