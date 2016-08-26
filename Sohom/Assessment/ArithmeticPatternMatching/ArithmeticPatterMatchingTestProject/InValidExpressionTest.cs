using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArithmeticPatternMatching;
namespace ArithmeticPatterMatchingTestProject
{
    [TestClass]
    public class InValidExpressionTest
    {
        [TestMethod]
        public void InValidExpressionTestMethod()
        {
            String s1 = "--2+4/2";
            Double? expectedresult = null;
            Double actualresult = ArithmeticPatternMatchingTest.parsethisstring(s1);
            Assert.AreEqual(expectedresult, actualresult);
            String s2 = "2+4/2-+";
            expectedresult = null;
            actualresult = ArithmeticPatternMatchingTest.parsethisstring(s2);
            Assert.AreEqual(expectedresult, actualresult);
            String s3 = "2+-4/2";
            expectedresult = null;
            actualresult = ArithmeticPatternMatchingTest.parsethisstring(s3);
            Assert.AreEqual(expectedresult, actualresult);
            String s4 = "Test";
            expectedresult = null;
            actualresult = ArithmeticPatternMatchingTest.parsethisstring(s4);
            Assert.AreEqual(expectedresult, actualresult);
            String s5 = "a+2";
            expectedresult = null;
            actualresult = ArithmeticPatternMatchingTest.parsethisstring(s5);
            Assert.AreEqual(expectedresult, actualresult);
            String s6 = "2+3-*4";
            expectedresult = null;
            actualresult = ArithmeticPatternMatchingTest.parsethisstring(s6);
            Assert.AreEqual(expectedresult, actualresult);
        }
    }
}
