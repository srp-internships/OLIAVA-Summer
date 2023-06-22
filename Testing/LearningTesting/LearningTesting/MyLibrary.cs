using System;
using System.IO;

namespace Library
{
    /// <summary>
    /// Предостовляет различные алгоритмы и методы для работы с массивами
    /// </summary>
    public static class MyArray
    {
        /// <summary>
        /// Принимает одномерные массивы и возвращает их объеденяя в одном одномерном массиве
        /// (Заполняет в исходном порядке данных массивов)
        /// </summary>
        /// <param name="arrays"></param>
        /// <returns></returns>
        public static int[] MergeSeveralIntoOne(params int[][] arrays)
        {
            Console.WriteLine(arrays[0].Length);
            int longLenght = 0, index = 0;
            for (int i = 0; i < arrays.Length; i++)
                longLenght += arrays[i].Length;
            int[] array = new int[longLenght];
            for (int i = 0; i < arrays.Length; i++)
                for (int j = 0; j < arrays[i].Length; j++, index++)
                    array[index] = arrays[i][j];
            return array;
        }

        /// <summary>
        /// Принимает одномерные массивы и возвращает их объеденяя в одном одномерном массиве
        /// (Заполняет в обратном порядке)
        /// </summary>
        /// <param name="arrays"></param>
        /// <returns></returns>
        public static int[] MergeSeveralIntoOneInReverseOrder(params int[][] arrays)
        {
            int index = -1;
            for (int i = 0; i < arrays.Length; i++)
                index += arrays[i].Length;
            int[] array = new int[index + 1];
            for (int i = 0; i < arrays.Length; i++)
                for (int j = 0; j < arrays[i].Length; j++, index--)
                    array[index] = arrays[i][j];
            return array;
        }

        /// <summary>
        /// Удаляет элемент массива с заданным индексом
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        public static int[] RemoveByIndex(int[] array, int index)
        {
            int[] newArray = new int[array.Length - 1];

            for (int i = 0; i < index; i++)
                newArray[i] = array[i];

            for (int i = index + 1; i < array.Length; i++)
                newArray[i - 1] = array[i];

             return newArray;
        }

        /// <summary>
        /// Удаляет в массиве элементы с заданного индекса до заданного индекса
        /// </summary>
        /// <param name="array"></param>
        /// <param name="startIndex"></param>
        /// <param name="lastIndex"></param>
        public static int[] Remove(ref int[] array, int startIndex, int lastIndex)
        {
            int[] tempArr = new int[array.Length - (lastIndex - startIndex + 1)];
            int j = 0;
            for (; j < startIndex; j++)
                tempArr[j] = array[j];

            for (int i = lastIndex + 1; i < array.Length; i++, j++)
                tempArr[j] = array[i];

            return tempArr;
        }

        /// <summary>
        /// Удаляет в массиве все элементы после заданного индекса
        /// </summary>
        /// <param name="array"></param>
        /// <param name="startIndex"></param>
        public static int[] Remove(ref int[] array, int startIndex)
        {
            int[] tempArr = new int[array.Length - (array.Length - startIndex - 1)];
            for (int i = 0; i < tempArr.Length; i++)
                tempArr[i] = array[i];
            return tempArr;
        }

        public static void RandomFill(int[] array, int min = 0, int max = 101)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < array.Length; i++)
                array[i] = rnd.Next(min, max);
        }

        /// <summary>
        /// Выводит массив на консоль.
        /// </summary>
        /// <param name="array"></param>
        public static void ShowInConsole(int[] array)
        {
            for (int i = 0; i < array.Length; i++) // Output result in console
                Console.WriteLine($"[{i}] = {array[i]}");
        }
    }

    /// <summary>
    /// Предостовляет различные алгоритмы и методы для работы со строками
    /// </summary>
    public static class MyString
    {
        /// <summary>
        /// Проверяет является ли текст пустым или содержит недопустимые символы (для создания файлов)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool ContainsInvalidSymbolsOrEmpty(string text)
        {
            char s = '"';
            string sym = "\\/:|*?<>" + s;
            if (!string.IsNullOrWhiteSpace(text))
            {
                for (byte i = 0; i < 9; i++)
                    if (text.Contains(sym[i].ToString()))
                        return true;
            }
            return (text.Length >= 250 || string.IsNullOrWhiteSpace(text));
        }
    }

    /// <summary>
    /// Предостовляет различные алгоритмыи и методы для работы с файлами (чтение - запись) и другие...
    /// </summary>
    public static class MyFile
    {
        /// <summary>
        /// Создает или открывает текстовый файл и записывает в него массив строк (написанный ранее текст в файле не удаляет)
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <param name="texts"></param>
        public static void WriteLineAllTextOfArray(string path, string fileName, string[] texts)
        {
            path += fileName + ".txt";
            using (StreamWriter stream = new StreamWriter(path, true))
                for (int i = 0; i < texts.Length; i++)
                    stream.WriteLine(texts[i]);
        }
    }

    /// <summary>
    /// Предостовляет различные алгоритмы и методы для работы с переменным
    /// </summary>
    public static class Variable
    {
        /// <summary>
        /// Меняет содержимое 2 переменных с новым способ добавленным в C#
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void NewSwap(ref int a, ref int b) => (a, b) = (b, a);

        /// <summary>
        /// Меняет содержимое двух переменных друг на друга с использованием третьей переменной
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Swap(ref int a, ref int b)
        {
            int temp = a; //копия переменной (а)
            a = b;
            b = temp;
        }

        /// <summary>
        /// Меняет содержимое двух переменных друг на друга арифметическим путем (без третьей переменной)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void ArithmeticSwap(ref int a, ref int b)
        {
            a += b;
            b = a - b;
            a -= b;
        }
    }
}
