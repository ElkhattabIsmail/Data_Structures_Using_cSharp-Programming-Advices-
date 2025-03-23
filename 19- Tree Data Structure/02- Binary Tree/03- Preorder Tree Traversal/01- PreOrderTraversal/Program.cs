using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Reflection;

namespace BinaryTreeImplementation
{
    public class BinaryTreeNode<T>
    {
        public T Value { get; set; } // The value stored in the node
        public BinaryTreeNode<T> Left { get; set; } // Reference to the left child
        public BinaryTreeNode<T> Right { get; set; } // Reference to the right child

        // Constructor initializing the node with a value
        public BinaryTreeNode(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    public class BinaryTree<T>
    {
        public BinaryTreeNode<T> Root { get; private set; } // The root node of the tree

        // Constructor initializing an empty tree
        public BinaryTree()
        {
            Root = null;
        }

        // Method to insert a new value into the tree
        public void Insert(T value)
        {

            /* Level By Level.
             We use Level-order insertion strategy,
             Level-order insertion: in a binary tree is a strategy that fills the tree level by level, 
             from left to right. This approach ensures that every level of the tree is completely 
             filled before any nodes are added to a new level, 
             and each parent node has at most two children before moving on to the next node in the 
             sequence.
            
             */

            var newNode = new BinaryTreeNode<T>(value); // Create a new node
            if (Root == null) // If the tree is empty, set the new node as the root
            {
                Root = newNode;
                return;
            }

            // Use a queue to perform level-order insertion
            Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                // Attempt to insert the new node in the first empty spot in level order
                if (current.Left == null)
                {
                    current.Left = newNode;
                    break;
                }
                else
                {
                    queue.Enqueue(current.Left);
                }

                if (current.Right == null)
                {
                    current.Right = newNode;
                    break;
                }
                else
                {
                    queue.Enqueue(current.Right);
                }
            }
        }

        // Method to visually print the tree structure
        public void PrintTree()
        {
            PrintTree(Root, 0, 7);
        }

        private void PrintTree(BinaryTreeNode<T> root, int space, int count)
        {

            if (root == null) // Eliminate any empty root.
                return;


            // Increase distance between levels
            space += count;

            // Process right child first
            if (root.Right != null)
                PrintTree(root.Right, space, count);


            // Print current node after space
            Console.WriteLine();
            for (int i = count; i < space; i++)
                Console.Write(" ");
            Console.WriteLine(root.Value);

            // check every root if contains a node left
            // Process left child
            if (root.Left != null)
                PrintTree(root.Left, space, count);

        }
      
        public void PrintTreePreOrdered()
        {
            PreOrderTraversal(Root);
        }
        private void PreOrderTraversal(BinaryTreeNode<T> root)
        {

            if (root == null)
                return;

            Console.Write(root.Value + ", ");
            // Process left child first
            if (root.Left != null)
                PreOrderTraversal(root.Left);
            // Process Right child
            if (root.Right != null)
                PreOrderTraversal(root.Right);
        }
        public BinaryTreeNode<T> FindNodeWithhValue(T value)
        {
            return FindNodeWithhValue(value,Root);
        }

        Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
        private void _FillTreeElementsInStack(BinaryTreeNode<T> root )
        {
            if (root == null)
                return;
            else
                stack.Push(root);


            // Process right child first
            if (root.Left != null)
                _FillTreeElementsInStack(root.Left);

            if (root.Right != null)
                _FillTreeElementsInStack(root.Right);

        }
        private BinaryTreeNode<T> FindNodeWithhValue(T value, BinaryTreeNode<T> root)
        {
            _FillTreeElementsInStack(root);

            while (stack.Count > 0)
            {
                if (Equals( stack.Peek().Value , value))
                {
                    return stack.Peek();
                }
                stack.Pop();
            }
            return null;
        }
    }


    class Program
    {
        static void Main()
        {
            var binaryTree = new BinaryTree<int>();
            Console.WriteLine("Values to be inserted: 1 -> 7\n");

            binaryTree.Insert(40);
            binaryTree.Insert(30);
            binaryTree.Insert(50);
            binaryTree.Insert(25);
            binaryTree.Insert(35);
            binaryTree.Insert(45);
            binaryTree.Insert(60);

            binaryTree.Insert(15);
            binaryTree.Insert(28);


            var node = binaryTree.FindNodeWithhValue(60);



            node.Left = new BinaryTreeNode<int>(55);
            node.Right = new BinaryTreeNode<int>(70);

            //binaryTree.Insert(55);
            //binaryTree.Insert(70);

            binaryTree.PrintTree();
            binaryTree.PrintTreePreOrdered();

            Console.ReadKey();

        }
    }
}