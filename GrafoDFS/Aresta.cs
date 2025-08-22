using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafoDFS
{
    public class Aresta
    {
        public Aresta() { }

        public Aresta(Node node1, Node node2)
        {
            Node1 = node1;
            Node2 = node2;
        }

        public Node Node1 { get; set; }
        public Node Node2 { get; set; }

       
     
    }
}
