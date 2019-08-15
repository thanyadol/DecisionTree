using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Default.Model
{


    class Node
    {
        public List<Node> ChildEdges { get; set; }
        
        public Node()
        {
          //  ChildEdges = new List<Node>();
        }

        public Node ChildNode { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }


        public IEnumerable<Node> GetNodeDescendants() // Note that this method is lazy
        {
            if (ChildEdges == null) return null;

            return new[] { this }
                   .Concat(ChildEdges.SelectMany(child => child.GetNodeDescendants()));
        }



    }
}
