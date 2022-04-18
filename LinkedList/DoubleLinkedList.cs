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
        public void removeTail()
        {

            // if list is empty, throw an exception
            if (tail == null)
                throw new NullReferenceException();

            // update tail
            tail = tail.getPrev();

            // if list is now empty, update head
            if (tail == null)
                head = null;

            // otherwise, update next on new last
            else
                tail.setNext(null);
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

            // walk down the list, looking for the value
            // start at the head
            Link<T> ptr = head;

            // continue until we run out of links
            while (ptr != null)
            {
                // see if this link is what we want
                if (ptr.getValue().Equals(value))
                {
                    // special case head use existing code
                    if (ptr == head)
                    {
                        removeHead();
                        return true;
                    }

                    // special case tail use existing code
                    if (ptr == tail)
                    {
                        removeTail();
                        return true;
                    }

                    // typical link, set prev and next to point around it
                    ptr.getPrev().setNext(ptr.getNext());
                    ptr.getNext().setPrev(ptr.getPrev());

                    // and return
                    return true;
                }

                // not there, keep looking
                else
                {
                    ptr = ptr.getNext();
                }
            }

            // done with list without finding it
            return false;
        }

        // returns a printable version of the linked list and the values that are stored in it
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
