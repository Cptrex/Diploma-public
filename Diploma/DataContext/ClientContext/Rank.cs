using System;
using System.Collections.Generic;
using System.Text;

namespace Diploma.DataContext
{
    public class Rank
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Profile> Profiles { get; set; }
    }
}
