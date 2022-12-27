using System;
using System.Collections.Generic;
using System.Text;

namespace Diploma.DataContext
{
    public class Org
    {
        public int ID { get; set; }
        public string Name { get; set; } 
        public List<Case> Cases { get; set; }
    }
}