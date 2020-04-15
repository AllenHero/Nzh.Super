using System;
using System.Collections.Generic;
using System.Text;

namespace Nzh.Super.Model
{
    public class Tree
    {
        public int id { get; set; }

        public string title { get; set; }

        public string name { get; set; }

        public IEnumerable<Tree> children { get; set; }

        public string alias { get; set; }

        public string icon { get; set; }

        public string href { get; set; }

        public bool spread { get; set; }
    }
}
