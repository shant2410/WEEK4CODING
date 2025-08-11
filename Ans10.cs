using System;

class Node {
    public int Data;
    public Node Next;
}

class Stack {
    Node top = null;

    public void Push(int data) {
        Node newNode = new Node { Data = data, Next = top };
        top = newNode;
        Console.WriteLine($"Pushed: {data}");
    }

    public void Pop() {
        if (top == null) {
            Console.WriteLine("Stack Empty");
            return;
        }
        Console.WriteLine($"Popped: {top.Data}");
        top = top.Next;
    }

    public void DisplayTop() {
        Console.WriteLine(top != null ? $"Top: {top.Data}" : "Stack Empty");
    }
}

class Program {
    static void Main() {
        Stack s = new Stack();
        while (true) {
            Console.WriteLine("\nStack Menu:");
            Console.WriteLine("1. Push");
            Console.WriteLine("2. Pop");
            Console.WriteLine("3. Display Top");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice) {
                case 1:
                    Console.Write("Enter data: ");
                    int data = Convert.ToInt32(Console.ReadLine());
                    s.Push(data);
                    break;
                case 2:
                    s.Pop();
                    break;
                case 3:
                    s.DisplayTop();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
}
