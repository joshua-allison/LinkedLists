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
        // access methods
        public T GetValue() => Value;
        public Link<T> GetNext() => Next;
        public Link<T> GetPrev() => Prev;
        public void SetNext(Link<T> next) => Next = next;
        public void SetPrev(Link<T> prev) => Prev = prev;
    }
}
