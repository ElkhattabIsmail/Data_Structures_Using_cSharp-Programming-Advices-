using System;
using System.Collections.Generic;


namespace BinaryTreeImplementation
{
    public class BinaryTreeNode<T> 
    {
        public T Value { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }

        public BinaryTreeNode(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    public class BinaryTree<T> 
    {
        public BinaryTreeNode<T> Root { get; private set; }

        public BinaryTree()
        {
            Root = null;
        }


        public void Insert(T value)
        {
            var newNode = new BinaryTreeNode<T>(value);
            if (Root == null)
            {
                Root = newNode;
                return;
            }

            Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

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


        // Print the tree visually
        public void PrintTree()
        {
            PrintTree(Root, 0);
        }

        private void PrintTree(BinaryTreeNode<T> root, int space)
        {
            int COUNT = 10;  // Distance between levels
            if (root == null)
                return;

            space += COUNT;
            PrintTree(root.Right, space);

            Console.WriteLine();
            for (int i = COUNT; i < space; i++)
                Console.Write(" ");

            Console.WriteLine(root.Value);

            PrintTree(root.Left, space);
        }


        private void PreOrderTraversal(BinaryTreeNode<T> node)
        {
            /* 
             * => Useful tool for a wide range of applications, from tree copying to expression evaluation. 
             
              PreOrder Traversal visits the current node before its child nodes. 
              The process for PreOrder Traversal is as follows:

                 - Visit the current node.
                 - Recursively perform PreOrder Traversal of the left subtree.
                 - Recursively perform PreOrder Traversal of the right subtree.
            */
            // Current(Root) - Left SubTree - Right SubTree
            if (node != null)
            {
                Console.Write(node.Value + " ");
                PreOrderTraversal(node.Left);
                PreOrderTraversal(node.Right);
            }
        }

        public void PreOrderTraversal()
        {
            PreOrderTraversal(Root);
            Console.WriteLine();
        }

        private void PostOrderTraversal(BinaryTreeNode<T> node)
        {

            /*
             * 
             * Useful in scenarios where you need to visit child nodes before their parents, such as when
                calculating the size or depth of a tree, or when performing certain cleanup or evaluation
                tasks that require child nodes to be processed first.


              PostOrder Traversal visits the current node after its child nodes. 
              The process for PostOrder Traversal is:

                - Recursively perform PostOrder Traversal of the left subtree.
                - Recursively perform PostOrder Traversal of the right subtree.
                - Visit the current node.
           */
            // Left -> Right -> Root
            if (node != null)
            {
                PostOrderTraversal(node.Left);
                PostOrderTraversal(node.Right);
                Console.Write(node.Value + " ");
            }
        }

        public void PostOrderTraversal()
        {
            PostOrderTraversal(Root);
            Console.WriteLine();
        }

        public void InOrderTraversal()
        {
            InOrderTraversal(Root);
            Console.WriteLine();
        }

        private void InOrderTraversal(BinaryTreeNode<T> node)
        {

            /*
             * This method ensures that nodes are visited in ascending order for binary search trees,
             * making it particularly useful for operations like tree sorting and building sorted lists from trees.
             
            
              Left - Current(Root) - Right
             */
            if (node != null)
            {
                InOrderTraversal(node.Left);
                Console.Write(node.Value + " ");
                InOrderTraversal(node.Right);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var binaryTree = new BinaryTree<int>();
            Console.WriteLine("Values to be inserted: 5,3,8,1,4,6,9\n");


            binaryTree.Insert(5);
            binaryTree.Insert(3);
            binaryTree.Insert(8);
            binaryTree.Insert(1);
            binaryTree.Insert(4);
            binaryTree.Insert(6);
            binaryTree.Insert(9);
      
            binaryTree.PrintTree();

         
            Console.WriteLine("\nPreOrder Traversal (Current-Left SubTree - Right SubTree):");
            binaryTree.PreOrderTraversal();

            Console.WriteLine("\nPostorder Traversal (Left SubTree - Right SubTree - Current):");
            binaryTree.PostOrderTraversal();


            Console.WriteLine("\nInorder Traversal: Left-Current-Right");
            binaryTree.InOrderTraversal();


            Console.ReadKey();

        }
    }
}
