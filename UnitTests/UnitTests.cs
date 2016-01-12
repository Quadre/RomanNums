using NUnit.Framework;
using RomanNums;
using System;

namespace UnitTests
{
    [TestFixture]
    public class UnitTests
    {
        private IRoman roman =  new Roman();

        [TestCase(false, "")]
        [TestCase(true, "viii")]
        [TestCase(true, "ix")]        
        [TestCase(true, "lXXV")]  
        [TestCase(true, "XCII")]
        [TestCase(true, "MCMLXXXiv")]        
        public void PositiveConverter(bool d, string str)
        {
            Assert.AreEqual(d, roman.IsCompliant(str));
        }
       
        [TestCase(8, "viii")]
        [TestCase(9, "ix")]
        [TestCase(18, "xviii")]
        [TestCase(46, "xlvi")]
        [TestCase(75, "lXXV")]  
        [TestCase(92, "XCII")]
        [TestCase(99, "IC")]
        [TestCase(441, "CDXLI")]
        [TestCase(695, "DCXCV")]
        [TestCase(749, "DCCIL")]
        [TestCase(1984, "MCMLXXXiv")]
        [TestCase(1944, "MCMXLIV")]
        public void Positive(int d, string str)
        {
            Assert.AreEqual(d, roman.Convert(str));
        }


        [TestCase("")]
        [TestCase("-1")]
        [TestCase("12v")]
        [TestCase("vii V")]        
        public void Negative(string str)
        {            
            Assert.Throws <FormatException>(() => roman.Convert(str));
        }

        [TestCase]        
        public void Max()
        {           
            string maxM = new string('M', 99999999);            
            Assert.Throws<OverflowException>(()=> roman.Convert(maxM));
        }        
    }
}
