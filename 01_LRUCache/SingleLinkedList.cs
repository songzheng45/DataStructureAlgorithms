using System;

// An implementation of single linked list  
class SingleLinkedList<T>
{
    private int _length;
    private SingleLinkedListNode<T> _head;
    private SingleLinkedListNode<T> _last;

    #region Constructors

    public SingleLinkedList(T[] array)
    {
    }

    #endregion

    #region Properties

    public int Length => _length;

    #endregion

    #region Insert

    // Insert an element into last position of unsorted list
    public void Insert(T elem)
    {
        var newNode = new SingleLinkedListNode<T>(elem);

        if (_length == 0)
        {
            _head = _last = newNode;
        }
        else
        {
            _last.Next = newNode;
        }

        _length++;
    }

    public void Insert(int index, T elem)
    {

    }

    #endregion

    #region Delete

    // Delete element which is at specified index
    public void Delete(int index, T elem)
    {
        if (index > _length - 1)
        {
            throw new IndexOutOfRangeException("Index must be within the bounds of the List. ");
        }
    }

    // Delete an element
    public void Delete(T elem)
    {
        
    }

    #endregion

    #region Find

    #endregion
}