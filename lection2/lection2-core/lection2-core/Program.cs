using System;
using System.Collections;
using System.Collections.Generic;

namespace lection2_core
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
            var testClassInt = new MyClass<int>(5) { 1, 2, 3, 4, 5 };
        }
    }


    class MyClass<T> : IEnumerable<T>, IEnumerator<T>
    {
        private T[] _array;
        private int _i = -1;
        private int _arrayIndex = -1;

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
            _array = null;
        }
    }
}
