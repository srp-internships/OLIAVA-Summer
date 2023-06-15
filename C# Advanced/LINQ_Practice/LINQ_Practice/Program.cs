using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int[] nums = {1, 2, 3, 4, 5, 6, 7, 8, 9, -1, -2, -3, -4, -5, 1, 1, 2, 3, 3, 4, 5};
        string[] names = {"Daniel", "Alex", "Newton", "Tomas", "Milina", "Nastya", "Dasha", "Grigorij", "pavel"};
        int[] ages = {21, 20, 30, 45, 67, 43, 87, 12, 32, 7, 6, 14};

        #region Select
        
        // Select() преобразует элементы, а еще можно выбрать какие нибудь поля или свойства элемента
        int[] lengths = names.Select(x => x.Length).ToArray(); // создаем массив который содержит длину строк

        // Можно еще приветсти к определенному типу 
        double[] doubleNums = nums.Select(x => (double) x).ToArray();

        // Еще можно изменить каждый тип (например какую нибудь арифметическую операцию сделать)
        int[] degreeOfNums = nums.Select(x => x * 2).ToArray();

        // Where() Возвращает элементы пройденные отбор по заданному условию
        // Создаем массив в котором будут трехзначные-нечетные-положительные числа 
        int[] positiveOddNums = Enumerable.Range(-1000, 1000).Where(x => x % 2 != 0 && x > 99 && x < 1000).ToArray();  
        
        #endregion
        
        // All() возвращяет true/false если ВСЕ элементы в коллекции соответстуют заданому запросу
        bool isAllNumsPositive = nums.All(x => x > 0); // Проверяем все ли числа положительные
        
        // Any() возвращяет true/false если заданному условию соответсвует хотя бы один элемент 
        bool isAnyNegative = nums.Any(x => x < 0); // Проверяем содержит ли число хотя бы одно отрицательное число

        // Append() добавляет 1 элемент в конец коллекции (Это как метод Add из List но только для любой коллекции)
        int[] digits = Enumerable.Range(0, 9).Append(9).ToArray(); // Создаем коллекцию цифр от 0 до 8 и добавляем 9

        // Prepend() Добавляет элемент в начало
        nums = nums.Prepend(0).ToArray();
        
        // Concat() объеденяет (склеивает) 2 коллекции
        int[] joinedArray = nums.Concat(digits).ToArray();
        
        // Average() Возвращяет ср-арифметическое
        double averageOfDigits = digits.Average();

        // Max() возвращяет максимальный элемент из коллекции
        int maxItemInArray = nums.Max();

        // В Max() мы еще можем писать лямбда выражения
        int strWithMaxLength = names.Max(x => x.Length);
        
        // Min() это противоположный метод, матода Max(). Который возвращяет минимальный элемент
        int strWithMinLength = names.Min(x => x.Length);
        
        // Сast<> делает cast (приведение/преобразование) для всех элементов в коллекции
       // double[] integers = digits.Select(d=>d.ToString()).Cast<double>().ToArray(); // Приводим все типы к double

        // Chunk() Возвращяет разбитую коллекцию на указанный размер
        int[][] jaggedArrayChunk = Enumerable.Range(0,101).Chunk(10).ToArray(); // Вернет массив массивов 10 на 10 в первом 0-9, во втором 10-19 и.т.д

        // Contains() проверяет содержится ли заданый элемент в коллкции (возвращяет true/false) 
        bool isName = names.Contains("Alex");
        
        // Distinct() удаляет копии элементов в коллекции 
        int[] nn = nums.Distinct().ToArray();

        // OfType<> Возвращяет коллекцию выбирая в нем указанные типы (если в коллекции разные типы)
        int[] onlyNumbers = new object[] {"2", 10, 3.14, true, 21, 100}.OfType<int>().ToArray(); // Возвращяет только int-ы

        // Order() Сортирует элементы по возрастанию
        int[] sortedAscending = nums.Order().ToArray();

        // OrderDescending()  Сортирует элементы по убыванию
        int[] sortedDescending = nums.OrderDescending().ToArray();
        
        // Reverse() Переворачивает коллекцию (делает ее зеркальной)
        int[] reversedCollection = sortedAscending.Reverse().ToArray(); // По сути мы массив по возрастанию сделали по убыванию
        

        // SequenceEqual() Проверяет одинакова ли последовательность коллекций (то есть парлельно одинаковы) возвращяет true/false
        // 1-1
        // 2-2
        // 3-3 и.т.д
        // Длина коллекций должна быть одинаковой
        bool isSequenceEqual = sortedAscending.SequenceEqual(sortedDescending);
        
        
        
        // Single()  Проверяет, содержится ли в коллекции только один элемент по заданному условию. Принцип работы приведен ниже: 
        // Если элемент один, то он возвращяется, т.е сам элемент - потому что он единственный
        // Если 0 или больше одного, то бросается исключение InvalidOperationException
        // (обычно используется в тестировании, так-как в коде ошибка не нужна), а на практике ему замена это метод First() 
        int single = new int[] {1, 2, 3, 4, 5, 6,}.Single(x => x == 1); // А еще его можно использовать без аргументов
        
        
        
        // SingleOrDefault Тоже самое что и Single но только если элементов 0 он возвращяет значение по умолчанию для типа
        int singleOrDefault = new int[] { }.SingleOrDefault(); // вернет 0 (так-как 0 для int это значение по умолчанию)
        
        // Skip() пропускает первые N элементов
        int[] skippedCollection = Enumerable.Range(-5, 11).Skip(5).ToArray(); // тут мы пропустили отрицательные числа
        
        // SkipLast() Пропускает последние N элементов (то же самое что и Skip() но работает с конца)
        
        
        // SkipWhile() Пропускает элементы пока условие выполняется, если условие нарушится то он сразу остановится
        string[] namess = { "Anna", "Bob", "Alice", "Charlie" };
        string[] resultt = names.SkipWhile(x => x.StartsWith("A")).ToArray();  // Результат: ["Bob", "Alice", "Charlie"]
        
        
        
        // Take() выбирает первые N элементов
        int[] takeFirstNegativeNums = Enumerable.Range(-5, 20).Take(5).ToArray(); // Здесь мы берем только первые 5 элементов
        
        // TakeLast() берет последние N элементов (то же самое что и TakeLast() но работает с конца)
        
        // TakeWhile() Берет элементы пока условие выполняется
        
        
        
        // ThenBy() этот метод используется после сортировки, как дополнителный приоритет сортировке
        //В ниже приведенном примере мы создаем несколько объектов Person и сортируем их по именам,
        // Так-как у объектов может быть несколько свойств сортировки тоже могуть быть разные (по разным критериям, приоритетам)
        // Сначала мы отсортировали наших людей по именам, а затем второй приоритет сортировки это возраст.
        // То что второй приоритет это возраст мы указали в ThenBy(x => x.age) для этого и нужен метод ThenBy()
        new[] {new Person("Alex", 21, true), new Person("Abbos", 23, true), new Person("Nodir", 43, false)}
            .OrderBy(x => x.name).ThenBy(x => x.age);
        
        
        
        
        // GroupBy() используется для группировки элементов коллекции по определенному критерию и возвращает новую коллекцию, содержащую группы элементов.
        // То есть в коллекции будет коллекция, это как многомерный массив, в каждом подмассиве будет определенная группа
        // В нижеприведенном примере, мы сгруппировали фрукты по первым буквам
        // К примеру в первой группе будут фрукты на букву 'A' (так-как у нас первый фрукт aplle начинается с буквы 'A')
        List<string> fruits = new List<string> { "apple", "banana", "cherry", "date", "elderberry"};
        IGrouping<char, string>[] groups = fruits.GroupBy(f => f[0]).ToArray();
        string[][] groupedFruits = new string[groups.Length][];
        for (int i = 0; i < groups.Length; i++)
        {
            groupedFruits[i] = groups[i].ToArray();
        }
        
        
        
        // Union() используется для объединения двух коллекций в одну, удаляя дубликаты элементов. 
        int[] numbers1 = { 1, 2, 3 };
        int[] numbers2 = { 3, 4, 5 };
        int[] unionNums = numbers1.Union(numbers2).ToArray(); // Результат: 1 2 3 4 5
        

        #region MethodBy

        // Любой метод с окончанем By (OrderBy, GroupBy,ExceptBy,DistinctBy)
        // Делают тоже самое что и их методы-близнецы, но только по селектору
        // Ниже будут приведены примеры:
        
        // Ради примера создадим массив экземпляров класса Person

        Person[] persons =
        {
            new Person("Alex", 21, true),
            new Person("Mutabar", 21, true),
            new Person("Jack", 89, false),
            new Person("Granny", 99, false)
        };

        // DistinctBy()
        // Ниже мы производим операцию Distinct() но по возрасту (ключу)
        Person[] p1 = persons.DistinctBy(x => x.age).ToArray(); // И соответственно тут не будут люди с одинаковыми возрастами
        
        #endregion
        
    }

    static void Show<T>(T[] array)
    {
        foreach (var item in array)
        {
            Console.WriteLine(item);
        }
    }
}

public class Person
{
    public int age;
    public string name;
    public bool isAlive;

    public Person(string name, int age, bool isAlive)
    {
        this.name = name;
        this.age = age;
        this.isAlive = isAlive;
    }
}