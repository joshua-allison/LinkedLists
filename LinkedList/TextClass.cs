using System;

namespace TextClassNamespace
{
    /*  The TextClass is enhanced Double Linked List.
     *  The text class uses a Linked List of type char to maniupulate a data structure of characters and perform string-like operations.
     *  All of the basic test functions in Driver.cs can be achieved using only a Linked List. 
     *  However, the advanced features, like append, require some programming beyond the scope of a Linked Lists fundamental abilities.
     */

    class TextClass
    {
        // BEGIN: BASIC SPECIFICATION

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
            return LinkedList.GetHeadValue();
        }

        // returns the value in the link at the tail of the LinkedList member
        public char GetTail()
        {
            return LinkedList.GetTailValue();
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

        // return true if the passed in char is found within the LinkedList member
        public bool Find(char value)
        {
            return LinkedList.FindValue(value);
        }

        // return true if the passed in char is found within the LinkedList member, also remove it from the list
        public bool FindRemove(char value)
        {
            return LinkedList.FindRemove(value);
        }

        // display the chars within the LinkedList member, from head to tail
        public string DisplayList()
        {
            return LinkedList.ShowList();
        }
        // END: BASIC SPECIFICATION


        // BEGIN: ADVANCED SPECIFICATION

        // append the contents of otherList to the tail of this list
        public void Append(ref TextClass otherList)
        {
            bool isOtherListEmpty = false;
            //while head of otherlist != null
            while(isOtherListEmpty == false)
            {
                try
                {
                    // get the value of the head of otherList, and add that value as a tail to this list
                    LinkedList.AddTail(otherList.GetHead());
                    // then remove the head of the other list so that it is not re-copied
                    otherList.RemoveHead();
                    
                }
                catch
                {
                    isOtherListEmpty = true;
                }
            }
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
        // END: ADVANCED SPECIFICATION



    }
}
