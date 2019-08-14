using Default.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Default
{


    class App
    {
        static void Main(string[] args)
        {
            Tree t = InitailizeTree();

            List<Node> temp = RecursiveEdgeToNode(t.ChildEdges);

            //t.ChildEdges = temp;
            t.Root.ChildEdges = temp;

            t.Travers(t.Root);

            //var n = temp.FirstOrDefault().GetNodeDescendants();

            Console.WriteLine();
            RecursiveDepthFirstSearch(new Node() {  ChildEdges = temp }, "R") ;

            //QueueTraverse(new Node() { ChildEdges = temp });

           // string json = JsonConvert.SerializeObject(t);

            // Console.WriteLine(json);
            //Console.ReadLine();
        }

        /*public static void QueueTraverse(Node root)
        {
            if (root == null)   // Return when the tree is empty.
                return;

            Queue<Node> nodeQueue = new Queue<Node>();
            nodeQueue.Enqueue(root);

            Node currentNode = root;

            while (nodeQueue.Count != 0)
            {
                currentNode = nodeQueue.Peek();
                nodeQueue.Dequeue();

                if (currentNode.ChildEdges == null)   // Print strings only when the current node is a leaf node.
                {
                   // Console.Write(currentNode.Name + "()");
                }

                else
                {

                    for (int i = 0; i < currentNode.ChildEdges.Count(); i++)
                    { 
                    Console.Write(currentNode.Name + "->" );
                    nodeQueue.Enqueue(currentNode.ChildEdges[i]); }
                }

            }

            Console.WriteLine("");

        }*/



        private static Tree InitailizeTree()
        {
           string json = File.ReadAllText(@"..\..\\assert\d3.json");
           return JsonConvert.DeserializeObject<Tree>(json);      
        }

        private static Node RecursiveDepthFirstSearch(Node rootNode, string stringToFind)
        {
            if (rootNode.Name == stringToFind) return rootNode;

            if (rootNode.ChildEdges == null) { return null; } 

            foreach (var child in rootNode.ChildEdges)
            {
                Console.Write(child.Name + " -> ");
                var n = RecursiveDepthFirstSearch(child, stringToFind);
                if (n != null)
                {
                 
                    return n;
                }
            }
            return null;
        }



        private static Node RecursiveEdgeToNode(Node n)
        {
            
            Node temp = n;
            if (n.ChildEdges == null)
            {
                if (n.ChildNode.Type == "terminal")
                {
                    return n;
                }

                temp.ChildEdges = n.ChildNode.ChildEdges;
                RecursiveEdgeToNode(temp.ChildNode);
            }


            if (n.ChildNode == null)
            {
                RecursiveEdgeToNode(temp.ChildEdges);
            }

            return temp;


        }

        private static List<Node> RecursiveEdgeToNode(List<Node> n)
        {
            var temp = n;
            var result = new List<Node>();
            foreach(Node tt in n)
            {
                result.Add(RecursiveEdgeToNode(tt));
            }

            return result;


        }

    }
}