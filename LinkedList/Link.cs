namespace TextClassNamespace
{
    // From Jim Bailey: "Single Linked Lists", "Double Linked Lists", "Circular Linked Lists"
    //      Changes: templated, modified from C++/psuedocode to C#
    public class Link<T>
    {
        //data stored in the link
        private T Value { get; set; }
        //reference to next link in the list
        private Link<T> Next { get; set; }
        //reference to prev link in the list
        private Link<T> Prev { get; set; }



        //constructor sets value and next
        public Link(T value, Link<T> next = null, Link<T> prev = null)
        {
            Value = value;
            Next = next;
            Prev = prev;
        }

        // accesses the value stored in the link
        public T GetValue() => Value;

        // accesses the adjacent link in the direction of the tail
        public Link<T> GetNext() => Next;

        // accesses the adjacent link in the direction of the head
        public Link<T> GetPrev() => Prev;

        // mutates the pointer of the adjacent link in the direction of the tail to the link provided
        public void SetNext(Link<T> next) => Next = next;

        // mutates the pointer of the adjacent link in the direction of the head to the link provided
        public void SetPrev(Link<T> prev) => Prev = prev;
    }
}
