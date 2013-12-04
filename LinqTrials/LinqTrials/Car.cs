using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqTrials
{
    class Car
    {
        public string name { get; set; }
        public string owner { get; set; }
        public int model { get; set; }
    }

    class CarOwner
    {
        public string owner_name { get; set; }
        public int age { get; set; }
    }
}
