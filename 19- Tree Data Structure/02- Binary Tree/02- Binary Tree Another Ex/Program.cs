using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03__Binary_Tree_Another_Ex
{
    class Program
    {
        public class BinaryTree<T>
        {
            public BinaryTreeNode<T> Root { get; private set; } = default;
            public void Insert(T value)
            {
                if (Root is null)
                {
                    Root = new BinaryTreeNode<T>(value);
                    return;
                }

                Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
                queue.Enqueue(Root);

                while (IsNotEmptyQueue(queue))
                {
                    var current = queue.Dequeue();
                    if (current.Left == null)
                    {
                        InsertNode(current, value);
                        break;
                    }
                    else
                        queue.Enqueue(current.Left);

                    if (current.Right == null)
                    {
                        InsertNode(current, value, true);
                        break;
                    }
                    else
                        queue.Enqueue(current.Right);
                }
            }
            public void PrintTree()
            {
                if (Root != null)
                {
                    Print(Root);
                }
            }
            private static void Print(BinaryTreeNode<T> tree, int space = 0)
            {
                int count = 7;
                space += count;

                if (tree.Right != null)
                    Print(tree.Right, space);

                Console.WriteLine();
                Console.Write("".PadLeft(space));

                Console.WriteLine(tree.Value);
                if (tree.Left != null)
                    Print(tree.Left, space);
            }
            private static bool IsNotEmptyQueue(Queue<BinaryTreeNode<T>> queue) => queue.Count > 0;
            private static void InsertNode(BinaryTreeNode<T> node, T value, bool isRight = false)
            {
                if (isRight)
                    node.Right = new BinaryTreeNode<T>(value);
                else
                    node.Left = new BinaryTreeNode<T>(value);
            }
        }
        public class BinaryTreeNode<T>
        {
            public BinaryTreeNode(T value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
            public T Value { get; set; } = default;
            public BinaryTreeNode<T> Left { get; set; }
            public BinaryTreeNode<T> Right { get; set; }
        }
        static void Main(string[] args)
        {
            var binaryTree = new BinaryTree<int>();
            Console.WriteLine("Values to be inserted: 1 -> 7\n");

            binaryTree.Insert(1);
            binaryTree.Insert(2);
            binaryTree.Insert(3);
            binaryTree.Insert(4);
            binaryTree.Insert(5);
            binaryTree.Insert(6);
            binaryTree.Insert(7);

            binaryTree.PrintTree();

            Console.ReadKey();
        }
    }
}
