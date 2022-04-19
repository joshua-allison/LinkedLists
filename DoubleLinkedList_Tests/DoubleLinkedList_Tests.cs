using System;
using TextClassNamespace;
using Xunit;

namespace DoubleLinkedList_Tests
{
    public class DoubleLinkedList_Tests
    {
        private readonly string CorrectShowList = "head -> T -> E -> S -> T -> nullptr";
        private readonly char testChar = '\\';

        [Fact]
        public void AddHead_GetHead()
        {
            //arrange
            DoubleLinkedList<char> testList = new DoubleLinkedList<char>();
            string correctResult = "TEST", testResult = "";

            //act
            testList.AddHead('T');
            testResult += testList.GetHead();
            testList.AddHead('E');
            testResult += testList.GetHead();
            testList.AddHead('S');
            testResult += testList.GetHead();
            testList.AddHead('T');
            testResult += testList.GetHead();

            //assert
            Assert.Equal(correctResult, testResult);
        }
        [Fact]
        public void AddHead_SetNext()
        {
            //arrange
            DoubleLinkedList<string> testList = new DoubleLinkedList<string>();
            testList.AddHead("TEST");
            testList.AddHead("X");
            string correctResult = "TEST";

            //act
            testList.RemoveHead();
            string testResult = testList.GetHead();

            //assert
            Assert.Equal(correctResult, testResult);
        }

        [Fact]
        public void AddTail_GetTail()
        {
            //arrange
            DoubleLinkedList<char> testList = new DoubleLinkedList<char>();
            string correctResult = "TEST", testResult = "";

            //act
            testList.AddTail('T');
            testResult += testList.GetTail();
            testList.AddTail('E');
            testResult += testList.GetTail();
            testList.AddTail('S');
            testResult += testList.GetTail();
            testList.AddTail('T');
            testResult += testList.GetTail();

            //assert
            Assert.Equal(correctResult, testResult);
        }

        [Fact]
        public void DoubleEnded()
        {
            //arrange
            DoubleLinkedList<char> testList = new DoubleLinkedList<char>();
            testList.AddTail('T');
            testList.AddTail('E');
            testList.AddTail('S');
            testList.AddTail('T');

            //act
            testList.AddTail(testChar);
            testList.AddHead(testChar);

            string testResult = testList.ShowList();
            Assert.NotEqual(CorrectShowList, testResult);

            testList.RemoveTail();
            testList.RemoveHead();
            testResult = testList.ShowList();

            //assert
            Assert.Equal(CorrectShowList, testResult);
        }

        [Fact]
        public void Find_ReturnsFalse()
        {
            //arrange
            DoubleLinkedList<char> testList = new DoubleLinkedList<char>();
            bool found;
            testList.AddHead('1');
            testList.AddHead('2');
            testList.AddHead('3');
            testList.AddHead('4');
            testList.AddHead('5');

            //act
            found = testList.FindValue(testChar);

            //assert
            Assert.False(found);
        }

        [Fact]
        public void Find_ReturnsTrue()
        {
            //arrange
            DoubleLinkedList<char> testList = new DoubleLinkedList<char>();
            bool found;
            testList.AddHead('1');
            testList.AddHead('2');
            testList.AddHead('3');
            testList.AddHead('4');
            testList.AddHead('5');

            //act
            found = testList.FindValue('1') && testList.FindValue('2') && testList.FindValue('3') && testList.FindValue('4') && testList.FindValue('5');

            //assert
            Assert.True(found);
        }

        [Fact]
        public void FindRemove_OnAbsent()
        {
            //arrange
            DoubleLinkedList<char> testList = new DoubleLinkedList<char>();
            testList.AddTail('T');
            testList.AddTail('E');
            testList.AddTail('S');
            testList.AddTail('T');

            //act
            bool found = testList.FindRemove(testChar);

            //assert
            Assert.False(found);
        }

        [Fact]
        public void FindRemove_OnHead()
        {
            //arrange
            DoubleLinkedList<char> testList = new DoubleLinkedList<char>();
            testList.AddTail('T');
            testList.AddTail('E');
            testList.AddTail('S');
            testList.AddTail('T');

            //act
            testList.AddHead(testChar);
            testList.FindRemove(testChar);
            string result = testList.ShowList();

            //assert
            Assert.Equal(CorrectShowList, result);
        }

        [Fact]
        public void FindRemove_OnMiddle()
        {
            //arrange
            DoubleLinkedList<char> testList = new DoubleLinkedList<char>();
            testList.AddTail('T');
            testList.AddTail('E');

            //act
            testList.AddTail(testChar);
            testList.AddTail('S');
            testList.AddTail('T');
            testList.FindRemove(testChar);
            string result = testList.ShowList();

            //assert
            Assert.Equal(CorrectShowList, result);
        }

        [Fact]
        public void FindRemove_OnTail()
        {
            //arrange
            DoubleLinkedList<char> testList = new DoubleLinkedList<char>();
            testList.AddHead('T');
            testList.AddHead('S');

            //act
            testList.AddHead(testChar);
            testList.AddHead('E');
            testList.AddHead('T');
            testList.FindRemove(testChar);
            string result = testList.ShowList();

            //assert
            Assert.Equal(CorrectShowList, result);
        }

        [Fact]
        public void IsEmpty_ReturnsFalse()
        {
            //arrange
            DoubleLinkedList<char> testList = new DoubleLinkedList<char>();
            testList.AddHead('T');
            testList.AddHead('S');
            testList.AddHead('E');
            testList.AddHead('T');

            //act
            bool testResult = testList.IsEmpty();

            //assert
            Assert.False(testResult);
        }

        [Fact]
        public void IsEmpty_ReturnsTrue()
        {
            //arrange
            DoubleLinkedList<char> testList = new DoubleLinkedList<char>();

            //act
            bool testResult = testList.IsEmpty();

            //assert
            Assert.True(testResult);
        }

        [Fact]
        public void showList_ReturnsExpectedString()
        {
            //arrange
            DoubleLinkedList<char> testList = new DoubleLinkedList<char>();
            testList.AddTail('T');
            testList.AddTail('E');
            testList.AddTail('S');
            testList.AddTail('T');

            //act
            string testResult = testList.ShowList();

            //assert
            Assert.Equal(CorrectShowList, testResult);
        }
    }
}
