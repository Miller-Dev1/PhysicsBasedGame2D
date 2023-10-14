using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.System;
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;

namespace PhsyxLite.Classes.Core
{
    public static class GTime
    {
        public static Clock clock = new();
        public static float deltaTime = Time.Zero.AsSeconds();

        public static void Update()
        {
            deltaTime = clock.Restart().AsSeconds();
        }
    }
}
