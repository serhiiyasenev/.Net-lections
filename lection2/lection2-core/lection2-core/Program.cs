using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            var testClassString = new MyClass<string>(5)
            {
                // six 
                "123", "234", "345", "456", "567", "xxx"
            };

            Console.WriteLine("Enumerable.Range Enumerable.Range Enumerable.Range");

            Console.WriteLine(
                Enumerable.Range(0, 101)
                .Where(el => el % 2 == 0)
                .Select(s => s.ToString())
                .Aggregate((a,b) => a + ", " + b));


            Console.WriteLine("Enumerable.Range Enumerable.Range Enumerable.Range");


            var vectors = new[]
            {
                (10, 20),
                (100, 30),
                (-10, 400),
                (20, 50)
            };


            var sum = vectors.Aggregate((x,y) => (x.Item1 + y.Item1, x.Item2 + y.Item2));

            Console.WriteLine(sum);

            Console.ReadKey();

            string element = testClassString[2];

            
            var testClassInt = new MyClass<int>(5) { 1, 2, 3, 4, 5 };
            bool removed = testClassInt.Remove(4);

            var testClassIntWithOut4 = testClassInt.ToList();

            var pairedNumbers = testClassIntWithOut4.Filter(i => i % 2 == 0);

            Console.WriteLine("List is created!");

            foreach (var item in pairedNumbers)
            {
                Console.WriteLine(item);
            }

            var testClassString2 = new MyClass<string>(5);

            testClassString2.OnAdd += new EventHandler(OnAdd);
            testClassString2.Add("1");

            var button = new Button();
            var window = new Window(button);

            window.OnClick += () => Console.WriteLine("Clicked");
            button.OnClick += () => Console.WriteLine("Button was clicked");

            button.Clicked();

          void OnAdd(object sender, EventArgs e)
          {
            Console.WriteLine("Element added...");
          }

          for (var i = 1; i < 10; i++)
          {
              for (var j = 1; j < 10; j++)
              {
                  var result = i*j;
                  var space = result.ToString().Length < 2 ? "  " : " ";
                  Console.Write(result + space);
              }
              Console.WriteLine();
          }

          IEnumerable<object> list = new List<object>{"1", 2, 3, 4, '5'};
          var list2 = list.Select(x => ReferenceEquals(x, "1"));

          foreach (var item in list2)
          {
              Console.WriteLine(item);
          }

          Console.ReadKey();

        }
    }


    class MyClass<T> : IEnumerable<T>, IEnumerator<T>
    {
        private T[] _array;
        private int _i = -1;
        private int _arrayIndex = -1;

        public event EventHandler OnAdd;

        public MyClass(int capacity)
        {
            _array = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                if (index <= _arrayIndex)
                {
                    return _array[index];
                }

                return default(T);
            }
            set
            {
                if (index <= _arrayIndex)
                {
                    _array[index] = value;  
                }

            }

        }

        public void Add (T obj)
        {
            _arrayIndex++;

            if (_arrayIndex >= _array.Length)
            {
                Array.Resize(ref _array, _array.Length * 2);  
            }

            _array[_arrayIndex] = obj;

            OnAdd?.Invoke(this, null);

        }

        public bool Remove(T item)
        {
            var start = Array.IndexOf(_array, item);

            if (start != -1)
            {
                for (var i = start; i <= _arrayIndex - 1; i++)
                {
                    _array[i] = _array[i+1];
                }
                 _arrayIndex--;
                Array.Resize(ref _array, _arrayIndex + 1);
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool MoveNext()
        {
            _i++;
            return _i < _array.Length;
        }

        public void Reset()
        {
            _i = -1;
        }

        object IEnumerator.Current => Current;

        public T Current => _array[_i];

        public IEnumerator<T> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Dispose()
        {
            //_array = null;
        }
    }


    public class Button
    {
        public event Action OnClick;

        public void Clicked() => OnClick?.Invoke();

    }

    public class Window
    {
        private Button _button = null;

        public event Action OnClick
        {
            add { _button.OnClick += value;}
            remove { _button.OnClick -= value;}
        }

        public Window(Button b)
        {
            _button = b;
        }
    }

    public static class CollectionExtension
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> collection, Predicate<T> predicate)
        {
            Console.WriteLine("Filter started!");
            foreach (var element in collection)
            {
                if (predicate(element))
                {
                    Console.WriteLine($"Retuning element `{element}`");
                    yield return element;
                }
            }
        }
    }


}