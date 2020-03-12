using System;
using System.Collections;
using System.Collections.Generic;

namespace lection2
{
    class Program
    {
        static void Main(string[] args)
        {

            // list
            var list = new List<int>(100);

            // add items
            for (var i = 0; i < 102; i++)
            {
                list.Add(i);
            }

            var cap = list.Capacity;


            // stack
            // FILO
            var stack = new Stack<int>(100);

            // add items
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);


            // get item
            var firstOut = stack.Peek();
            var outAndDelete = stack.Pop();
            var outAgainAndDelete = stack.Pop();

            // stack
            // FIFO
            var queue = new Queue<int>(100);

            // add items
            queue.Enqueue(123);
            queue.Enqueue(234);
            queue.Enqueue(345);


            // get item
            var en = queue.GetEnumerator().MoveNext();
            var justLook = queue.Peek();
            var first = queue.Dequeue();
            var second = queue.Dequeue();
            var third = queue.Dequeue();


            //Dictionary


            //HashSet

            var hashSet = new HashSet<string>();

            // add items
            hashSet.Add("test1");
            hashSet.Add("test2");

            var a = hashSet.Add("test3");
            var b = hashSet.Add("test1");

            var contains = hashSet.Contains("test2");



            // counter

            var counter = new Counter();

            foreach (var c in counter)
            {
                Console.WriteLine("counter");
                Console.WriteLine(c);
            }

            Console.Read();


        }

        class Counter : IEnumerator, IEnumerable
        {
            private int i = -1;

            public bool MoveNext()
            {
                i++;
                return i < 10;
            }

            public void Reset()
            {
                i = -1;
            }

            public object Current => i;

            public IEnumerator GetEnumerator() => this;
        }

        public class Generic<T> where T : unmanaged
        {
            public T Field;
        }
    }
}
