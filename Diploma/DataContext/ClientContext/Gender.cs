using System;
using System.Collections.Generic;
using System.Text;

namespace Diploma.DataContext
{
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Case> Cases { get; set; }
    }
}
