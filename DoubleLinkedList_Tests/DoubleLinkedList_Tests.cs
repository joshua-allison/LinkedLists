using System;
using TextClassNamespace;
using Xunit;

namespace DoubleLinkedList_Tests
{
    public class DoubleLinkedList_Tests
    {
        [Fact]
        public void AddHead_GetHead()
        {
            //arrange
            DoubleLinkedList<char> testList = new DoubleLinkedList<char>();
            string correctResult = "TEST", testResult = "";

            //act
            testList.addHead('T');
            testResult += testList.getHead();
            testList.addHead('E');
            testResult += testList.getHead();
            testList.addHead('S');
            testResult += testList.getHead();
            testList.addHead('T');
            testResult += testList.getHead();

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
            testList.addTail('T');
            testResult += testList.getTail();
            testList.addTail('E');
            testResult += testList.getTail();
            testList.addTail('S');
            testResult += testList.getTail();
            testList.addTail('T');
            testResult += testList.getTail();

            //assert
            Assert.Equal(correctResult, testResult);
        }

        [Fact]
        public void showList()
        {
            //arrange
            DoubleLinkedList<char> testList = new DoubleLinkedList<char>();
            string correctResult = "head -> T -> E -> S -> T -> nullptr", testResult = "";
            testList.addTail('T');
            testList.addTail('E');
            testList.addTail('S');
            testList.addTail('T');

            //act
            testResult += testList.showList();

            //assert
            Assert.Equal(correctResult, testResult);
        }

        [Fact]
        public void DoubleEnded()
        {
            //arrange
            DoubleLinkedList<char> testList = new DoubleLinkedList<char>();
            string correctResult = "head -> T -> E -> S -> T -> nullptr", testResult = "";
            testList.addTail('X');
            testList.addTail('T');
            testList.addTail('E');
            testList.addTail('S');
            testList.addTail('T');
            testList.addTail('X');

            //act
            testList.removeTail();
            testList.removeHead();
            testResult += testList.showList();

            //assert
            Assert.Equal(correctResult, testResult);
        }

        [Fact]
        public void Find_ReturnsTrue()
        {
            //arrange
            DoubleLinkedList<char> testList = new DoubleLinkedList<char>();
            bool found;
            testList.addHead('1');
            testList.addHead('2');
            testList.addHead('3');
            testList.addHead('4');
            testList.addHead('5');

            //act
            found = testList.findValue('1') && testList.findValue('2') && testList.findValue('3') && testList.findValue('4') && testList.findValue('5');

            //assert
            Assert.True(found);
        }

        [Fact]
        public void Find_ReturnsFalse()
        {
            //arrange
            DoubleLinkedList<char> testList = new DoubleLinkedList<char>();
            bool found;
            testList.addHead('1');
            testList.addHead('2');
            testList.addHead('3');
            testList.addHead('4');
            testList.addHead('5');

            //act
            found = testList.findValue('6');

            //assert
            Assert.False(found);
        }

        [Fact]
        public void IsEmpty_ReturnsTrue()
        {
            //arrange
            DoubleLinkedList<char> testList = new DoubleLinkedList<char>();

            //act
            bool testResult = testList.isEmpty();

            //assert
            Assert.True(testResult);
        }

        [Fact]
        public void IsEmpty_ReturnsFalse()
        {
            //arrange
            DoubleLinkedList<char> testList = new DoubleLinkedList<char>();
            testList.addTail('T');
            testList.addTail('E');
            testList.addTail('S');
            testList.addTail('T');

            //act
            bool testResult = testList.isEmpty();

            //assert
            Assert.False(testResult);
        }
    }
}
