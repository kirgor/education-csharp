using System;

namespace Lecture3
{
    internal class Program
    {
        private class Student : IAbleToGoAway
        {
            public void GoAway()
            {
                Console.WriteLine("Saaaaaaaaaaaaaaaaaaaaaaa");
            }
        }

        public class Fly : IAbleToGoAway
        {
            public void GoAway()
            {
            }
        }

        public class World : IAbleToGoAway
        {
            public void GoAway()
            {
            }
        }

        public class Examination : IAbleToGoAway
        {
            public void GoAway()
            {
            }

            public int GetFff()
            {
                return 100;
            }
        }

        public interface IAbleToGoAway
        {
            void GoAway();
        }

        public interface ISuperClass : IComparable
        {
            void Super();
        }

        public class SuperBinaryTree<TValue> : BinaryTree<TValue> where TValue : ISuperClass
        {
        }

        public class PoorBinaryTree
        {
            public object Value { get; set; }
        }

        public class BinaryTree<TValue> where TValue : IComparable
        {
            public BinaryTree(TValue value = default(TValue), BinaryTree<TValue> left = null, BinaryTree<TValue> right = null)
            {
                Value = value;
                Left = left;
                Right = right;
            }

            public TValue Value { get; set; }

            public BinaryTree<TValue> Left { get; set; }

            public BinaryTree<TValue> Right { get; set; }

            public int CompareChildren()
            {
                if (Left == null && Right != null)
                {
                    return 1;
                }
                else if (Left != null && Right == null)
                {
                    return -1;
                }
                else if (Left == null && Right == null)
                {
                    return 0;
                }
                else
                {
                    return Left.Value.CompareTo(Right.Value);
                }
            }
        }

        private static void Main(string[] args)
        {
            var root = new BinaryTree<int>(100);
            root.Left = new BinaryTree<int>(1000);
            root.Left.Right = new BinaryTree<int>();
            root.Right = new BinaryTree<int>();
            root.Right.Left = new BinaryTree<int>(400);
        }
    }
}