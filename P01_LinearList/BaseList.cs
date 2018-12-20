using System;

namespace P01_LinearList
{
    public abstract class BaseList<T>
    {
        // length of list
        public abstract int Length {get;}

        // clear list
        public abstract void Clear();

        // get an element base on index
        public abstract T GetElem(int index);

        // search the element which matches specified element and return its index
        public abstract int LocateElem(T elem);

        // insert a new element at specified index
        public abstract void Insert(int index, T newElem);

        // delete an element base on its index
        public abstract T Delete(int index);
    }
}