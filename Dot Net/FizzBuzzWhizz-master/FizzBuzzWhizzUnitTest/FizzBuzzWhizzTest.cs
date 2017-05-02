using System;
using FizzBuzzWhizz;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzzWhizzUnitTest
{
    [TestClass]
    public class FizzBuzzWhizzTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FizzOutOfRange_1()
        {
            FizzBuzzWhizzMaker maker = new FizzBuzzWhizzMaker(-1, 3, 5);
            Assert.IsNull(maker, "Failure - given fizz out of range should maker null");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FizzOutOfRange_2()
        {
            FizzBuzzWhizzMaker maker = new FizzBuzzWhizzMaker(0, 3, 5);
            Assert.IsNull(maker, "Failure - given fizz out of range should maker null");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FizzOutOfRange_3()
        {
            FizzBuzzWhizzMaker maker = new FizzBuzzWhizzMaker(10, 3, 5);
            Assert.IsNull(maker, "Failure - given fizz out of range should maker null");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BuzzOutOfRange_1()
        {
            FizzBuzzWhizzMaker maker = new FizzBuzzWhizzMaker(1, -1, 5);
            Assert.IsNull(maker, "Failure - given buzz out of range should maker null");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BuzzOutOfRange_2()
        {
            FizzBuzzWhizzMaker maker = new FizzBuzzWhizzMaker(1, 0, 5);
            Assert.IsNull(maker, "Failure - given buzz out of range should maker null");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BuzzOutOfRange_3()
        {
            FizzBuzzWhizzMaker maker = new FizzBuzzWhizzMaker(1, 10, 5);
            Assert.IsNull(maker, "Failure - given buzz out of range should maker null");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhizzOutOfRange_1()
        {
            FizzBuzzWhizzMaker maker = new FizzBuzzWhizzMaker(1, 3, -1);
            Assert.IsNull(maker, "Failure - given whizz out of range should maker null");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhizzOutOfRange_2()
        {
            FizzBuzzWhizzMaker maker = new FizzBuzzWhizzMaker(1, 3, 0);
            Assert.IsNull(maker, "Failure - given whizz out of range should maker null");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhizzOutOfRange_3()
        {
            FizzBuzzWhizzMaker maker = new FizzBuzzWhizzMaker(1, 3, 10);
            Assert.IsNull(maker, "Failure - given whizz out of range should maker null");
        }

        [TestMethod]
        public void FizzBuzzSame()
        {
            try
            {
                FizzBuzzWhizzMaker maker = new FizzBuzzWhizzMaker(1, 1, 3);
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.ParamName, "buzz");
            }
        }

        [TestMethod]
        public void BuzzFizzSame()
        {
            try
            {
                // 命名参数 Named Arguments
                FizzBuzzWhizzMaker maker = new FizzBuzzWhizzMaker(buzz: 1, fizz: 1, whizz: 3);
            }
            catch (ArgumentException e)
            {
                //StringAssert.Contains(e.ParamName, "fizz");
                StringAssert.Contains(e.ParamName, "buzz");
            }
        }

        [TestMethod]
        public void FizzWhizzSame()
        {
            try
            {
                FizzBuzzWhizzMaker maker = new FizzBuzzWhizzMaker(1, 3, 1);
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.ParamName, "whizz");
            }
        }

        [TestMethod]
        public void BuzzWhizzSame()
        {
            try
            {
                FizzBuzzWhizzMaker maker = new FizzBuzzWhizzMaker(1, 3, 3);
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.ParamName, "whizz");
            }
        }

        [TestMethod]
        public void FizzBuzzWhizzSame()
        {
            try
            {
                FizzBuzzWhizzMaker maker = new FizzBuzzWhizzMaker(1, 1, 1);
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.ParamName, "buzz");
            }
        }

        [TestMethod]
        public void GivenXShouldSayX()
        {
            FizzBuzzWhizzMaker maker = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("1", maker.Translate(1), "Failure - given 1 should say 1 when (3, 5, 7)");
        }

        [TestMethod]
        public void GivenXShouldSayFizz()
        {
            FizzBuzzWhizzMaker maker01 = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("Fizz", maker01.Translate(3), "Failure - given 3 should say Fizz when (3, 5, 7)");

            FizzBuzzWhizzMaker maker02 = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("Fizz", maker02.Translate(6), "Failure - given 6 should say Fizz when (3, 5, 7");

            FizzBuzzWhizzMaker maker03 = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("Fizz", maker03.Translate(9), "Failure - given 9 should say Fizz when (3, 5, 7");

            FizzBuzzWhizzMaker maker04 = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("Fizz", maker04.Translate(12), "Failure - given 12 should say Fizz when (3, 5, 7");

            FizzBuzzWhizzMaker maker05 = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("Fizz", maker05.Translate(13), "Failure - given 13 should say Fizz when (3, 5, 7");

            FizzBuzzWhizzMaker maker06 = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("Fizz", maker06.Translate(23), "Failure - given 23 should say Fizz when (3, 5, 7");

            FizzBuzzWhizzMaker maker07 = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("Fizz", maker07.Translate(31), "Failure - given 31 should say Fizz when (3, 5, 7");
        }

        [TestMethod]
        public void GivenXShouldSayBuzz()
        {
            FizzBuzzWhizzMaker maker01 = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("Buzz", maker01.Translate(5), "Failure - given 5 should say Buzz when (3, 5, 7)");

            FizzBuzzWhizzMaker maker02 = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("Buzz", maker02.Translate(10), "Failure - given 10 should say Buzz when (3, 5, 7)");
        }

        [TestMethod]
        public void GivenXShouldSayWhizz()
        {
            FizzBuzzWhizzMaker maker = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("Whizz", maker.Translate(7), "Failure - given 7 should say Whizz when (3, 5, 7)");
        }

        [TestMethod]
        public void GivenXShouldSayFizzBuzzWhizz()
        {
            FizzBuzzWhizzMaker maker01 = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("FizzBuzzWhizz", maker01.Translate(105), "Failure - given 105 should say FizzBuzzWhizz when (3, 5, 7)");

            FizzBuzzWhizzMaker maker02 = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("FizzBuzzWhizz", maker02.Translate(210), "Failure - given 210 should say FizzBuzzWhizz when (3, 5, 7)");
        }

        [TestMethod]
        public void GivenXShouldSayFizzBuzz()
        {
            FizzBuzzWhizzMaker maker01 = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("FizzBuzz", maker01.Translate(15), "Failure - given 15 should say FizzBuzz when (3, 5, 7)");

            FizzBuzzWhizzMaker maker02 = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("FizzBuzz", maker02.Translate(45), "Failure - given 45 should say FizzBuzz when (3, 5, 7)");

            FizzBuzzWhizzMaker maker03 = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("FizzBuzz", maker03.Translate(60), "Failure - given 60 should say FizzBuzz when (3, 5, 7)");

            FizzBuzzWhizzMaker maker04 = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("FizzBuzz", maker04.Translate(75), "Failure - given 75 should say FizzBuzz when (3, 5, 7)");

            FizzBuzzWhizzMaker maker05 = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("FizzBuzz", maker05.Translate(90), "Failure - given 90 should say FizzBuzz when (3, 5, 7)");

            FizzBuzzWhizzMaker maker06 = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("FizzBuzz", maker06.Translate(120), "Failure - given 120 should say FizzBuzz when (3, 5, 7)");

            FizzBuzzWhizzMaker maker07 = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("FizzBuzz", maker07.Translate(150), "Failure - given 150 should say FizzBuzz when (3, 5, 7)");

            FizzBuzzWhizzMaker maker08 = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("FizzBuzz", maker08.Translate(165), "Failure - given 165 should say FizzBuzz when (3, 5, 7)");

            FizzBuzzWhizzMaker maker09 = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("FizzBuzz", maker09.Translate(180), "Failure - given 180 should say FizzBuzz when (3, 5, 7)");

            FizzBuzzWhizzMaker maker10 = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("FizzBuzz", maker10.Translate(195), "Failure - given 195 should say FizzBuzz when (3, 5, 7)");
        }

        [TestMethod]
        public void GivenXShouldSayFizzWhizz()
        {
            FizzBuzzWhizzMaker maker01 = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("FizzWhizz", maker01.Translate(21), "Failure - given 21 should say FizzWhizz when (3, 5, 7)");

            FizzBuzzWhizzMaker maker02 = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("FizzWhizz", maker02.Translate(42), "Failure - given 42 should say FizzWhizz when (3, 5, 7)");

            FizzBuzzWhizzMaker maker03 = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("FizzWhizz", maker03.Translate(84), "Failure - given 84 should say FizzWhizz when (3, 5, 7)");

            FizzBuzzWhizzMaker maker04 = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("FizzWhizz", maker04.Translate(126), "Failure - given 126 should say FizzWhizz when (3, 5, 7)");

            FizzBuzzWhizzMaker maker05 = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("FizzWhizz", maker05.Translate(147), "Failure - given 147 should say FizzWhizz when (3, 5, 7)");

            FizzBuzzWhizzMaker maker06 = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("FizzWhizz", maker06.Translate(168), "Failure - given 168 should say FizzWhizz when (3, 5, 7)");

            FizzBuzzWhizzMaker maker07 = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("FizzWhizz", maker07.Translate(189), "Failure - given 189 should say FizzWhizz when (3, 5, 7)");
        }

        [TestMethod]
        public void GivenXShouldSayBuzzWhizz()
        {
            FizzBuzzWhizzMaker maker01 = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("BuzzWhizz", maker01.Translate(70), "Failure - given 70 should say BuzzWhizz when (3, 5, 7)");

            FizzBuzzWhizzMaker maker02 = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("BuzzWhizz", maker02.Translate(140), "Failure - given 140 should say BuzzWhizz when (3, 5, 7)");

            FizzBuzzWhizzMaker maker03 = new FizzBuzzWhizzMaker(3, 5, 7);
            Assert.AreEqual("BuzzWhizz", maker03.Translate(175), "Failure - given 175 should say BuzzWhizz when (3, 5, 7)");
        }
    }
}