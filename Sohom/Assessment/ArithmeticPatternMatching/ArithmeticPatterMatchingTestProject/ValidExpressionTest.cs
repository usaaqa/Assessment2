using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArithmeticPatternMatching;
namespace ArithmeticPatterMatchingTestProject
{
    [TestClass]
    public class ValidExpressionTest
    {
        [TestMethod]
        public void ValidExpressionTestMethod()
        {

            String s1 = "2+4/sqrt(4)-4";
            Double expectedresult = 0;
            Double actualresult = ArithmeticPatternMatchingTest.parsethisstring(s1);
            Assert.AreEqual(expectedresult, actualresult);
            String s2 = "sqrt(4)+3^3-2";
            expectedresult = 27;
            actualresult = ArithmeticPatternMatchingTest.parsethisstring(s2);
            Assert.AreEqual(expectedresult, actualresult);
            String s3 = "1+2+3";
            expectedresult = 6;
            actualresult = ArithmeticPatternMatchingTest.parsethisstring(s3);
            Assert.AreEqual(expectedresult, actualresult);
            String s4 = "2-2+3";
            expectedresult = 3;
            actualresult = ArithmeticPatternMatchingTest.parsethisstring(s4);
            Assert.AreEqual(expectedresult, actualresult);
            String s5 = "2^2+3*6";
            expectedresult = 22;
            actualresult = ArithmeticPatternMatchingTest.parsethisstring(s5);
            Assert.AreEqual(expectedresult, actualresult);

        }
    }
}
