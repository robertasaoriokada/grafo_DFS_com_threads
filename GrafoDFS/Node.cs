using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafoDFS
{
    public class Node
    {
        public Node() { }
        public Node(string title, int id) {
            Id = id;
            LetterTitle = title;
        }

        public int Id { get; set; }
        public string LetterTitle { get; set;}

    }
}
