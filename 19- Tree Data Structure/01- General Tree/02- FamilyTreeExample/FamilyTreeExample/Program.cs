using System;
using System.Collections.Generic;

public class TreeNode<T>
{
    public T Data { get; set; }
    public List<TreeNode<T>> Children { get; set; }

    public TreeNode(T data)
    {
        Data = data;
        Children = new List<TreeNode<T>>();
    }
}

public class Person
{
    public string Name { get; set; }

    public Person(string name)
    {
        Name = name;
    }
}

public class FamilyTreeExample
{
    public static void PrintFamilyTree(TreeNode<Person> node, string indent = " ")
    {
        Console.WriteLine(indent + node.Data.Name);

        foreach (var child in node.Children)
        {
            PrintFamilyTree(child, indent + "   ");
        }
    }

    public static void Main()
    {
        TreeNode<Person> root = new TreeNode<Person>(new Person("John"));

        TreeNode<Person> child1 = new TreeNode<Person>(new Person("Alice"));
        TreeNode<Person> child2 = new TreeNode<Person>(new Person("Bob"));
        TreeNode<Person> child3 = new TreeNode<Person>(new Person("Carol"));
        TreeNode<Person> child4 = new TreeNode<Person>(new Person("Semon"));
        root.Children.Add(child1);
        root.Children.Add(child2);
        root.Children.Add(child3);
        root.Children.Add(child4);

        TreeNode<Person> grandchild1 = new TreeNode<Person>(new Person("David"));
        TreeNode<Person> grandchild2 = new TreeNode<Person>(new Person("Emily"));
        child1.Children.Add(grandchild1); 
        child1.Children.Add(grandchild2); 

        TreeNode<Person> grandchild3 = new TreeNode<Person>(new Person("Jasmin"));
        TreeNode<Person> grandchild4 = new TreeNode<Person>(new Person("Tom"));
        child2.Children.Add(grandchild3);
        child2.Children.Add(grandchild4);

        TreeNode<Person> grandchild5 = new TreeNode<Person>(new Person("Roy"));
        child3.Children.Add(grandchild5);

        TreeNode<Person> GrandGrandChild1 = new TreeNode<Person>(new Person("Zaina"));
        grandchild3.Children.Add(GrandGrandChild1);

        TreeNode<Person> grandchild6 = new TreeNode<Person>(new Person("ZainaChild"));
        GrandGrandChild1.Children.Add(grandchild6);
        TreeNode<Person> grandchild7 = new TreeNode<Person>(new Person("ZainaChild2"));
        GrandGrandChild1.Children.Add(grandchild7);


        PrintFamilyTree(root);
        Console.ReadKey();

    }
}