namespace Practice
{
    public class DoublyLinkedNode
    {
        public DoublyLinkedNode Previous;

        public DoublyLinkedNode Next;

        public int Data;

        public DoublyLinkedNode(){}

        public DoublyLinkedNode(int data)
        {
            this.Data = data;
        }
    }
}