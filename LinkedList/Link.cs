using System;
using System.Collections.Generic;
using System.Text;

namespace TextClassNamespace
{

    // From Jim Bailey: "Single Linked Lists", "Double Linked Lists", "Circular Linked Lists"
    class Link <T>
    {
        //data stored in the link
        private T value;
        //reference to next link in the list
        private Link<T> next;
        //reference to prev link in the list
        private Link<T> prev;

        //constructor sets value and next
        public Link(T value, Link<T> next = null, Link<T> prev = null)
        {
            this.value = value;
            this.next = next;
            this.prev = prev;
        }
        // access methods
        public T getValue() => value;
        public Link<T> getNext() => next;
        public Link<T> getPrev() => prev;
        public void setNext(Link<T> next) => this.next = next;
        public void setPrev(Link<T> prev) => this.prev = prev;
    }
}
