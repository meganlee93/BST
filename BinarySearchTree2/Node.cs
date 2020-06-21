using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BinarySearchTree2
{
    public class Node<T> : IComparable<Node<T>>
        where T : IComparable<T>
    {
        public T Value { get; set; }
        public Node<T> Parent { get; set; }
        public Node<T> LeftChild { get; set; }
        public Node<T> RightChild { get; set; }
        
        public bool IsLeaf
        {
            get
            {
                return LeftChild == null && RightChild == null;
            }
        }
        public bool IsLeftChild
        {
            get
            {
                return Parent.LeftChild == this;
            }
        }
        public Node(T value)
        {
            Value = value;
        }

        public int CompareTo(Node<T> other)     
        {
            return Value.CompareTo(other.Value);
        }
    }
}
