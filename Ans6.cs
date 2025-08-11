using System;

class Node { public int Data; public Node Next; }

class Queue {
    private Node front = null, rear = null;

    public void Insert(int data) {
        var newNode = new Node { Data = data };
        if (rear == null) front = rear = newNode;
        else { rear.Next = newNode; rear = newNode; }
        Console.WriteLine($"Inserted: {data}");
    }

    public void Delete() {
        if (front == null) { Console.WriteLine("Queue Empty"); return; }
        Console.WriteLine($"Deleted: {front.Data}");
        front = front.Next;
        if (front == null) rear = null;
    }

    public void DisplayFront() {
        Console.WriteLine(front != null ? $"Front: {front.Data}" : "Queue Empty");
    }

    public void DisplayAll() {
        if (front == null) { Console.WriteLine("Queue Empty"); return; }
        Console.Write("Queue: ");
        for (var cur = front; cur != null; cur = cur.Next)
            Console.Write(cur.Data + (cur.Next != null ? " -> " : ""));
        Console.WriteLine();
    }
}

class Program {
    static void Main() {
        var q = new Queue();
        while (true) {
            Console.WriteLine("\nQueue Menu:");
            Console.WriteLine("1. Insert");
            Console.WriteLine("2. Delete");
            Console.WriteLine("3. Display Front");
            Console.WriteLine("4. Display All");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");
            var input = Console.ReadLine();
            if (!int.TryParse(input, out int choice)) { Console.WriteLine("Invalid input"); continue; }

            switch (choice) {
                case 1:
                    Console.Write("Enter data: ");
                    var dIn = Console.ReadLine();
                    if (int.TryParse(dIn, out int data)) q.Insert(data);
                    else Console.WriteLine("Invalid number");
                    break;
                case 2: q.Delete(); break;
                case 3: q.DisplayFront(); break;
                case 4: q.DisplayAll(); break;
                case 5: return;
                default: Console.WriteLine("Invalid Choice"); break;
            }
        }
    }
}
