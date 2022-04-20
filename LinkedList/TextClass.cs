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
        /**     BEGIN BASIC SPECIFICATION     **/

        // the linked list that TextClass uses for it's operations (changed from private to public for advanced specification)
        public DoubleLinkedList<char> LinkedList { get; set; }

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
        /**     END BASIC SPECIFICATION     **/


        /**     BEGIN ADVANCED SPECIFICATION     **/

        // append the contents of otherList to the tail of this list
        public void Append(ref TextClass otherList)
        {
            Link<char> otherListTail = otherList.LinkedList.GetTailLink();
            do
            {
                if (otherList.LinkedList.GetCurrentLink() == null)
                    otherList.LinkedList.IncrementCurrent();
                Link<char> currentLink = otherList.LinkedList.GetCurrentLink();
                LinkedList.AddTail(currentLink.GetValue());
                otherList.LinkedList.IncrementCurrent();
            } while (otherList.LinkedList.GetCurrentLink().GetNext() != null);
            LinkedList.AddTail(otherList.LinkedList.GetTailValue());
        }

        // find the next instance of the passed in value
        public bool FindNext(char value)
        {
            Link<char> startingLink = LinkedList.GetCurrentLink();
            do
            {
                LinkedList.IncrementCurrent();
                if (LinkedList.GetCurrentLink().GetValue() == value)
                    return true;
            } while (LinkedList.GetCurrentLink() != startingLink);
            return false;
        }

        // removes the link that was saved by the last call to findNext
        public void RemoveLast()
        {
            if (LinkedList.GetCurrentLink() != null)
            {
                LinkedList.GetCurrentLink().GetPrev().SetNext(LinkedList.GetCurrentLink().GetNext());
                LinkedList.GetCurrentLink().GetNext().SetPrev(LinkedList.GetCurrentLink().GetPrev());
                LinkedList.ResetCurrent();
            }
        }

        // insert value before the link that was saved by the most recent call to findNext
        public void InsertLast(char value)
        {
            if (LinkedList.GetCurrentLink() == LinkedList.GetHeadLink())
            {
                LinkedList.AddHead(value);
            }
            else
            {
                Link<char> insert = new Link<char>(value);
                insert.SetNext(LinkedList.GetCurrentLink());
                insert.SetPrev(LinkedList.GetCurrentLink().GetPrev());
                LinkedList.GetCurrentLink().GetPrev().SetNext(insert);
                LinkedList.GetCurrentLink().SetPrev(insert);
            }
        }
        /**     END ADVANCED SPECIFICATION     **/



    }
}
