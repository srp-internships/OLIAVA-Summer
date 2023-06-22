using HigherMathematics;

namespace Testing
{
    [TestFixture]
    public class HigherMathTest
    {
        [Test]
        [TestCase(1, 1, 2)]
        [TestCase(1, 2, 3)]
        [TestCase(1, 3, 4)]
        public void Sum_WhenCalled_ReturnsSumOfTwoArguments(int a, int b, int expectedResult)
        {
            int result = HigherMath.Sum(a, b);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
       // [Ignore("I just ignored it!")]
        [TestCase(2,5,32)]
        [TestCase(2,3,8)]
        [TestCase(10,2,100)]
        public void Degree_WhenCalled_ReturnsNumberRaisedToPower(int n,int degree, int expectedResult)
        {
            int result = HigherMath.Degree(n, degree);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(4,24)]
        [TestCase(5,120)]
        [TestCase(6,720)]
        public void Fact_WhenCalled_ReturnsFactorialOfGivenNumber(int n, int expectedResult)
        {
            int result = HigherMath.Fact(n);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}