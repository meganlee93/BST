using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace BinarySearchTree2
{
    public class DuplicateKeysException : Exception
    {
        public DuplicateKeysException()
            :base("Duplicate keys not allowed!")
        {
            
        }
    }

    public class BinarySearchTree<T>
        where T : IComparable<T>
    {
        Node<T> Root;

        public BinarySearchTree()
        {
            Root = null;
        }

        public void Insert(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if(Root == null)
            {
                Root = newNode;
                return;
            }

            Node<T> curr = Root;
            while (true)
            {
                if (newNode.CompareTo(curr) < 0)
                {
                    if(curr.LeftChild == null)
                    {
                        curr.LeftChild = newNode;
                        curr.LeftChild.Parent = curr;
                        break;
                    }
                    curr = curr.LeftChild;
                }
                else if(newNode.CompareTo(curr) > 0)
                {
                    if(curr.RightChild == null)
                    {
                        curr.RightChild = newNode;
                        curr.RightChild.Parent = curr;
                        break;
                    }
                    curr = curr.RightChild;
                }
                else
                {
                    throw new DuplicateKeysException();
                }
            }
        }

        public void Remove(T value)
        {
            Node<T> curr = Root;
            while(curr != null)
            {
                if(value.CompareTo(curr.Value) == 0)
                {
                    break;
                }
                else if(value.CompareTo(curr.Value) < 0)
                {
                    curr = curr.LeftChild;
                }
                else
                {
                    curr = curr.RightChild;
                }
            }

            //we have found the node to remove
            if(curr.IsLeaf)
            {
                if(curr.IsLeftChild)
                {
                    curr.Parent.LeftChild = null;
                }
                else
                {
                    curr.Parent.RightChild = null;
                }
                return;
            }
            //left case
            if (curr.LeftChild != null && curr.RightChild == null)
            {
                if (curr.IsLeftChild)
                {
                    curr.Parent.LeftChild = curr.LeftChild;
                }
                else
                {
                    curr.Parent.RightChild = curr.LeftChild;
                }
                curr.LeftChild.Parent = curr.Parent;
                return;
            }
            //right case
            if(curr.RightChild != null && curr.LeftChild == null)
            {
                if(!curr.IsLeftChild)
                {
                    curr.Parent.RightChild = curr.RightChild;
                }
                else
                {
                    curr.Parent.LeftChild = curr.RightChild;
                }
                curr.RightChild.Parent = curr.Parent;
                return;
            }
            //handle two child case
            if(curr.RightChild != null && curr.LeftChild != null)
            {
                Node<T> newNode = curr.LeftChild;
                if(newNode.RightChild == null)
                {
                    curr.Value = newNode.Value;
                    newNode.Parent.LeftChild = null;
                    return;
                }
                while(newNode.RightChild != null)
                {
                    newNode = newNode.RightChild;
                }
                
                curr.Value = newNode.Value;
                newNode.Parent.RightChild = null;

            }

        }

        public List<Node<T>> PreOrder()
        {
            List<Node<T>> myList = new List<Node<T>>();
            Stack<Node<T>> myStack = new Stack<Node<T>>();
            myStack.Push(Root);

            if(Root == null)
            {
                return myList;
            }

            if(Root.LeftChild == null && Root.RightChild == null)
            {
                myList.Add(Root);
                return myList;
            }

            while (myStack.Count != 0)
            {
                Node<T> node = myStack.Peek();
                myList.Add(node);
                myStack.Pop();
                if(node.RightChild != null)
                {
                    myStack.Push(node.RightChild);
                }

                if(node.LeftChild != null)
                {
                    myStack.Push(node.LeftChild);
                }
            }

            return myList;
        }
    }
}
