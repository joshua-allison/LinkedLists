using System;
using System.Collections.Generic;
using System.Text;

namespace TextClassNamespace
{
    // From Jim Bailey: "Single Linked Lists", "Double Linked Lists", "Circular Linked Lists"
    //      Changes: templated, modified from C++/psuedocode to C#
    public class DoubleLinkedList <T>
    {
        // a pointer to the first link of the list
        private Link<T> Head { get; set; }

        // a pointer to the last link of the list
        private Link<T> Tail { get; set; }



        // constructor initializes head and tail to null
        public DoubleLinkedList()
        {
            Head = null;
            Tail = null;
        }

        // add a new link containing value at the Head of the list
        public void AddHead(T value)
        {
            // if the list is empty, initialize both head and tail
            if (IsEmpty())
                Head = Tail = new Link<T>(value);
            
            // otherwise, just add a new link at the head
            else
            {
                // create new link with nullptr for prev and head for next
                Link<T> temp = new Link<T>(value, Head, null);

                // set first link and head to point to the new link
                Head.SetPrev(temp);
                Head = temp;
            }
        }

        // add a new link containing value at the Tail of the list
        public void AddTail(T value)
        {
            // if the list is empty, initialize both Head and Tail
            if (Tail == null)
                Head = Tail = new Link<T>(value);

            // otherwise, just add a new link at the Tail
            else
            {
                // create the new link with nullptr for next and Tail for prev
                Link<T> temp = new Link<T>(value, null, Tail);

                // set last link and Tail to point to the new link
                Tail.SetNext(temp);
                Tail = temp;
            }
        }

        // return the value contained in the first link of the list
        public T GetHead()
        {
            // if list is empty, throw an exception
            if (Head == null)
                throw new InvalidOperationException();

            // return the value from inside Head
            return Head.GetValue();
        }

        // return the value contained in the last link of the list
        public T GetTail()
        {
            // if list is empty, throw an exception
            if (Head == null)
                throw new InvalidOperationException();

            // return the value from inside Head
            return Tail.GetValue();
        }



        ///*  The GetHeadLink and GetTailLink accessors were added to make the append function of TextClass possible. */

        //// return the reference of the first link of the list
        //public Link<T> GetHeadLink()
        //{
        //    // if list is empty, throw an exception
        //    if (Head == null)
        //        throw new InvalidOperationException();

        //    // return the Head link
        //    return Head;
        //}

        //// return the reference of the last link of the list
        //public Link<T> GetTailLink()
        //{
        //    // if list is empty, throw an exception
        //    if (Head == null)
        //        throw new InvalidOperationException();

        //    // return the value from inside Head
        //    return Tail;
        //}
        
        
        // remove the first link in the list
        public void RemoveHead()
        {
            // if list is empty, throw an exception
            if (Head == null)
                throw new InvalidOperationException();

            // update Head to point at the next link in the list
            Head = Head.GetNext();

            // if now empty, set Tail properly
            if (IsEmpty())
                Tail = null;
            // otherwise, update prev on new first link
            else
                Head.SetPrev(null);
        }

        // remove the last link in the list
        public void RemoveTail()
        {

            // if list is empty, throw an exception
            if (Tail == null)
                throw new InvalidOperationException();

            // update Tail
            Tail = Tail.GetPrev();

            // if list is now empty, update Head
            if (Tail == null)
                Head = null;

            // otherwise, update next on new last
            else
                Tail.SetNext(null);
        }

        // return true if the list is empty
        public bool IsEmpty() => Head == null;

        // Iterative version for a linear search
        public bool FindValue(T value)
        {
            // variable to track status of find
            bool found = false;

            // start at the Head
            Link<T> currentLink = Head;

            // continue until the end
            while (currentLink != null && !found){
                // found it, go home happy (modified for templated links)
                if (currentLink.GetValue().Equals(value))
                    found = true;

                // not found, continue with next link
                else
                    currentLink = currentLink.GetNext();
            }
            // end of list or found, return
            return found;
        }

        // find and remove a value if present
        public bool FindRemove(T value)
        {
            // special case empty list
            if (IsEmpty())
                return false;

            // walk down the list, looking for the value
            // start at the Head
            Link<T> ptr = Head;

            // continue until we run out of links
            while (ptr != null)
            {
                // see if this link is what we want
                if (ptr.GetValue().Equals(value))
                {
                    // special case Head use existing code
                    if (ptr == Head)
                    {
                        RemoveHead();
                        return true;
                    }

                    // special case Tail use existing code
                    if (ptr == Tail)
                    {
                        RemoveTail();
                        return true;
                    }

                    // typical link, set prev and next to point around it
                    ptr.GetPrev().SetNext(ptr.GetNext());
                    ptr.GetNext().SetPrev(ptr.GetPrev());

                    // and return
                    return true;
                }

                // not there, keep looking
                else
                {
                    ptr = ptr.GetNext();
                }
            }

            // done with list without finding it
            return false;
        }

        // returns a printable version of the linked list and the values that are stored in it
        public string ShowList()
        {
            // modified for expected output of TextClass.cs tests
            string buffer = "";
            if (IsEmpty())
                buffer = "Empty List";
            else
            {
                Link<T> ptr = Head;
                while (ptr != null)
                {
                    buffer += ptr.GetValue().ToString() + " ";
                    ptr = ptr.GetNext();
                }
            }
            return buffer;
        }
    }
}
