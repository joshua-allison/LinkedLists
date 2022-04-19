using System;

namespace TextClassNamespace
{
    class TextClass
    {
        // the linked list that TextClass uses for it's operations
        private DoubleLinkedList<char> LinkedList { get; set; }



        // constructor initializes 'LinkedList' member
        public TextClass()
        {
            LinkedList = new DoubleLinkedList<char>();
        }

        // add a link ot the head of the LinkedList member
        public void AddHead(char value)
        {
            LinkedList.AddHead(value);
        }

        // add a link ot the tail of the LinkedList member
        public void AddTail (char value)
        {
            LinkedList.AddTail(value);
        }

        // returns the value in the link at the head of the LinkedList member
        public char GetHead()
        {
            return LinkedList.GetHead();
        }

        // returns the value in the link at the tail of the LinkedList member
        public char GetTail()
        {
            return LinkedList.GetTail();
        }

        // removes the link at the head of the LinkedList member, resulting in a new head link if the list is not empty as a result
        public void RemoveHead()
        {
            LinkedList.RemoveHead();
        }

        // removes the link at the tail of the LinkedList member, resulting in a new tail link if the list is not empty as a result
        public void RemoveTail()
        {
            LinkedList.RemoveTail();
        }

        //
        public bool Find(char value)
        {
            throw new NotImplementedException();
        }

        //
        public bool FindRemove(char value)
        {
            throw new NotImplementedException();
        }

        //
        public string DisplayList()
        {
            return LinkedList.ShowList();
        }
        
        //
        public void Append(ref TextClass otherList)
        {
            throw new NotImplementedException();
        }

        //
        public bool FindNext(char value)
        {
            throw new NotImplementedException();
        }

        //
        public void RemoveLast()
        {
            throw new NotImplementedException();
        }

        //
        public void InsertLast(char value)
        {
            throw new NotImplementedException();
        }



    }
}
