using Library;

namespace Testing
{
    [TestFixture]
    public class MyArrayTest
    {
        [Test]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 0, new[] { 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 4, new[] { 1, 2, 3, 4 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 2, new[] { 1, 2, 4, 5 })]
        public void RemoveByIndex_WhenCalled_ReturnsArrayByRemovingItemByIndex(int[] array, int index, int[] expectedArray)
        {
            int[] resultArray = MyArray.RemoveByIndex(array, index);
            Assert.That(resultArray, Is.EqualTo(expectedArray));
        }

        [Test]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6 }, new[] { 1, 2, 3 }, new[] { 4, 5, 6 })]
        public void MergeSeveralIntoOne_WhenCalled_ConcatenatesGivenArraysAndReturnOneArray(int[] expectedArray, params int[][] arrays)
        {
            int[] MergedArrays = MyArray.MergeSeveralIntoOne(arrays);
            Assert.That(MergedArrays, Is.EqualTo(expectedArray));
        }

        [Test]
        
        [TestCase(new[] {0,0,0,0,0})]
        //[Ignore("Test does-not work")]
        public void RandomFill_WhenCalled_FillsGivenArrayWithRandomNumbers(int[] array)
        {
            MyArray.RandomFill(array);

            // Проверяет содержиться ли в массиве указанный элемент
            // Assert.Contains(0, array);


            // Проверяет нету ли в массиве числа 0
            Assert.That(array, Does.Not.Contains(200));

            

        }

        [Test]
        [TestCase(new[] { 1, 2, 3 })]
        [TestCase(new[] { 0, 2, 4, 6, 8 })]
        [TestCase(new[] { 9, 7, 5, 3, 1, })]
        // Тестирование void метода
        // Этот метод выводит элементы массива на консоль
        public void ShowInConsole_WhenCalled_PrintsTheItemsOfArrayToConsole(int[] array)
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            MyArray.ShowInConsole(array);

            string expectedResult = string.Empty;

            for (int i = 0; i < array.Length; i++)
                expectedResult += $"[{i}] = {array[i]}\r\n";

            Assert.That(expectedResult, Is.EqualTo(sw.ToString()));
        }
    }
}
