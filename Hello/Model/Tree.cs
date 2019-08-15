using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Default.Model
{
    class Tree
    {

        public Tree()
        {
            this.Root = new Node();
        }

        //for serilize
        public List<Node> ChildEdges { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }

        public Node Root;

        /*Given a binary tree, print out all of its root-to-leaf  
         paths, one per line. Uses a recursive helper to do   
         the work.*/
        public virtual void Travers(Node node)
        {
            string[] path = new string[1000];
            TraverseRecursive(node, path, 0);
        }

        /* Recursive helper function -- given a node, and an array  
           containing the path from the root node up to but not   
           including this node, print out all the root-leaf paths.*/
        public virtual void TraverseRecursive(Node node, string[] path, int length)
        {
            if (node == null)
            {
                return;
            }

            /* append this node to the path array */
            path[length] = node.Name;
            length++;

            /* it's a leaf, so print the path that led to here  */
            if (node.ChildEdges == null)
            {
                Print(path, length);
            }
            else
            {

                foreach(Node n in node.ChildEdges)
                {
                    
                    TraverseRecursive(n, path, length);
                }


                /* otherwise try both subtrees */
                //printPathsRecur(node.left, path, pathLen);
                //printPathsRecur(node.right, path, pathLen);
            }
        }

        //prints out an array on a line
        public virtual void Print(string[] path, int len)
        {
            int i;
            for (i = 0; i < len; i++)
            {
                Console.Write(path[i] + " -> ");
            }
            Console.WriteLine("()");
        }



    }
}
