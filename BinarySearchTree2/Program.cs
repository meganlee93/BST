using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BinarySearchTree2
{
    class Program
    {
        /*
        class IAmNotComparable
        { 
            
        }

        class Animal
        {
            public Animal()
            {

            }
            public void Speak()
            {
                Console.WriteLine("Hello");
            }
        }

        interface IAnimal
        {
            void Speak();
        }

        class Cat : IAnimal, IComparable<Cat>
        {
            public double GrowlVolume;

            public Cat(double growlVolume)
            {
                GrowlVolume = growlVolume;
            }
            public int CompareTo([AllowNull] Cat other)
            {
                return GrowlVolume.CompareTo(other.GrowlVolume);
            }

            public void Speak()
            {
                Console.WriteLine("meow");
            }
        }

        public static void Meow<T>(T item) where T : struct
        {

        }

        */

        public class Food : IComparable<Food>
        {
            public int TastyLevel { get; set; }
            public string FoodName { get; set; }
            public Food(int tastyLevel)
            {
                TastyLevel = tastyLevel;
            }

            public int CompareTo(Food other)
            {
                return TastyLevel.CompareTo(other.TastyLevel) | FoodName.CompareTo(other.FoodName);
            }
        }
        static void Main(string[] args)
        {
            /*
            int five = 5;
            Cat cat = new Cat(five);
           // Meow(cat);
            BinarySearchTree<Cat> MEOW = new BinarySearchTree<Cat>();
            */
            /*
            BinarySearchTree<int> BST = new BinarySearchTree<int>();
            BST.Insert(4);
            BST.Insert(2);
            BST.Insert(10);
            BST.Insert(5);
            BST.Insert(15);
            //BST.Insert(7);

            BST.Remove(10);*/

            //Depth First Traversal
            BinarySearchTree<string> BST = new BinarySearchTree<string>();

            BST.Insert("F");
            BST.Insert("B");
            BST.Insert("A");
            BST.Insert("D");
            BST.Insert("C");
            BST.Insert("E");
            BST.Insert("G");
            BST.Insert("I");
            BST.Insert("H");

            List<Node<string>> myList = BST.PreOrder();
            for(int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine(myList[i].Value);
            }


        }
    }
}
