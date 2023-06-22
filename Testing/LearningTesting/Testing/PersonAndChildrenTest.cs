using System;
using LearningTesting;

namespace Testing
{
    [TestFixture]
    internal class PersonAndChildrenTest
    {
        [SetUp] 
        public void SetUp()
        {
            Person p1 = new Person();
        }

        [Test]
        [TestCase(1,"John","Kennedi",18)]
        [TestCase(2,"Mark","Tershtegen",20)]
        [TestCase(3,"Alex","Stepanov",21)]
        public void PersonConstructorTest_WhenPersonCreated_CreateNewInstanseOfPerson(int id, string name,string lastName, int age)
        {
            Person p1 = new Person(id, name, lastName, age);
            
            Assert.IsNotNull(p1);

            Assert.That(p1.Id, Is.EqualTo(id));
            Assert.That(p1.Name, Is.EqualTo(name));
            Assert.That(p1.Age, Is.EqualTo(age));
        }

        [Test]
        public void ExceptionsTest_WhenCreatedInvalidInstance_ThrowsException()
        {
            IList<int> list = new List<int>();
            Person p1 = new Person();

            Assert.That(() => p1 = new Person(1, "John1", "Levandovski", 39), Throws.InvalidOperationException);

            Assert.That(() => p1.Name = "Alex2", Throws.Exception.InstanceOf<InvalidOperationException>());

            Assert.That(() => p1.Id = -1, Throws.ArgumentException);
        }

        [Test]
        // Проверка типов, экземпляров, наследников
        public void InstanceTest_CheckingInstances()
        {
            Person p1 = new Person();
            Children child = new Children(2, "Cristiano", "Ronaldo", 36, 3);

            // Is.InstanceOf<Person>() Проверяет, является ли объект p1 экземпляром класса Person или его производного класса. 
            Assert.That(p1, Is.InstanceOf<Person>());

            // Is.TypeOf<Person>() Проверяет, является ли объект p1 именно экземпляром класса Person, а не его производного класса.
            Assert.That(p1, Is.TypeOf<Person>());

            // Проверяем, является ли объект child экземпляром класса Person или его наследником
            Assert.That(child, Is.InstanceOf<Person>());
        }

    }
}
