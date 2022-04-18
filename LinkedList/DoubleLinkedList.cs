using System;
using System.Collections.Generic;
using System.Text;

namespace TextClassNamespace
{
    // From Jim Bailey: "Single Linked Lists", "Double Linked Lists", "Circular Linked Lists"
    //      Changes: templated, modified from C++/psuedocode to C#
    class DoubleLinkedList <T>
    {
        // a pointer to the start of the list
        private Link<T> head { get; set; }
        private Link<T> tail { get; set; }

        // the only class variable is the head and it starts out as nullptr
        public DoubleLinkedList()
        {
            head = null;
            tail = null;
        }

        // add a new link containing value at the head of the list
        public void addHead(T value)
        {
            // create a new link containing the value
            Link<T> temp = new Link<T>(value);

            // if the list was empty
            if (isEmpty())
                // set tail to point to singleton link
                tail = temp;
            else
                // update its next field to contain whatever head contained
                temp.setNext(head);

            // update head to point to the new link
            head = temp;
        }

        // add a new link containing value at the tail of the list
        public void addTail(T value)
        {
            // if the list is empty, initialize both head and tail
            if (tail == null)
                head = tail = new Link<T>(value);

            // otherwise, just add a new link at the tail
            else
            {
                // create the new link with nullptr for next and tail for prev
                Link<T> temp = new Link<T>(value, null, tail);

                // set last link and tail to point to the new link
                tail.setNext(temp);
                tail = temp;
            }
        }

        // return the value contained in the first link of the list
        public T getHead()
        {
            // if list is empty, throw an exception
            if (head == null)
                throw new NullReferenceException();

            // return the value from inside head
            return head.getValue();
        }

        // return the value contained in the last link of the list
        public T getTail()
        {
            // if list is empty, throw an exception
            if (head == null)
                throw new NullReferenceException();

            // return the value from inside head
            return tail.getValue();
        }

        // remove the first link in the list
        public void removeHead()
        {
            // if list is empty, throw an exception
            if (head == null)
                throw new NullReferenceException();

            // update head to point at the next link in the list
            head = head.getNext();

            // if now empty, set tail properly
            if (isEmpty())
                tail = null;
            // otherwise, update prev on new first link
            else
                head.setPrev(null);

        }

        // return true if the list is empty
        public bool isEmpty() => head == null;

        // Iterative version for a linear search
        public bool findValue(T value)
        {
            // variable to track status of find
            bool found = false;

            // start at the head
            Link<T> currentLink = head;

            // continue until the end
            while (currentLink != null && !found){
                // found it, go home happy (modified for templated links)
                if (currentLink.getValue().Equals(value))
                    found = true;

                // not found, continue with next link
                else
                    currentLink = currentLink.getNext();
            }
            // end of list or found, return
            return found;
        }

        // find and remove a value if present
        public bool findRemove(T value)
        {
            // special case empty list
            if (isEmpty())
                return false;

            // next check head for value
            if (head.getValue().Equals(value))
            {
                removeHead();
                return true;
            }

            // variable to track status of find
            bool found = false;

            // now walk down list, start by pointing at the head
            Link<T> currentLink = head;
             // until done with list or value is found
            while (currentLink.getNext() != null && !found)
            {
                // create a reference to the next link
                Link<T> nextLink = currentLink.getNext();

                // if nextLink is the one wanted
                if (nextLink.getValue().Equals(value))
                {
                    // update list to look past it
                    currentLink.setNext(nextLink.getNext());

                    // added code to deal with deleting tail
                    if (nextLink == tail)
                        tail = currentLink;

                    // set status as found
                    found = true;
                }
                // not there, move on down the line
                else
                    currentLink = currentLink.getNext();
            }
            // found or at end, return result
            return found;
        }
        public string showList()
        {
            string buffer;
            if (isEmpty())
                buffer = "Empty List";
            else
            {
                buffer = "head -> ";
                Link<T> ptr = head;
                while (ptr != null)
                {
                    buffer += ptr.getValue().ToString();
                    ptr = ptr.getNext();
                    buffer += " -> ";
                }
                buffer += "nullptr";
            }
            return buffer;
        }
    }
}
