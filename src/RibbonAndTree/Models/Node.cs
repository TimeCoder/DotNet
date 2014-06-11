using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RibbonAndTree.Models
{
    public class Node
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public IEnumerable<Node> Owner { get; set; } 
        
        public string Name { get; set; }

        public bool HasData
        {
            get { return Data != null && Data.Any(); }
        }

        public IEnumerable<DataItem> Data { get; set; } 
    }
}
