namespace LinkedListTraversal.Models
{
    public class Node<T>
    {
        public Node(T element)
        {
            this.Data = element;
            this.Next = null;
        }

        public T Data { get; }

        public Node<T> Next { get; set; }

        public void AddToEnd(T element)
        {
            if(this.Next == null)
            {
                this.Next = new Node<T>(element);
            }
            else
            {
                this.Next.AddToEnd(element);
            }
        }

    }
}
