using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PhsyxLite.Classes.Core
{
    public class Component
    {
        public GameObject gameObject { get; set; }
        public string tag { get; set; }
        public Vector2 transform { get; set; }
    }
}
