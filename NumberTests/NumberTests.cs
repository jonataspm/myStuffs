namespace NumberTests
{
    public class NumberTests
    {
        [Test]
        public void Test1()
        {
            var roman = new Romain();

            Assert.That("X", Is.EqualTo(roman.GetRoman(10)));
            Assert.That("I", Is.EqualTo(roman.GetRoman(1)));
            Assert.That("III", Is.EqualTo(roman.GetRoman(3)));
            Assert.That("LXIV", Is.EqualTo(roman.GetRoman(64)));
            Assert.AreEqual("CCLIX", (roman.GetRoman(259)));
        }
    }
}