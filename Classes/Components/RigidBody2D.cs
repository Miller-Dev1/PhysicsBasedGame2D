using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhsyxLite.Classes.Components;
using SFML.Graphics;
using SFML.System;
using Box2DX.Collision;
using Box2DX.Dynamics;
using Box2DX.Common;
using PhsyxLite.Classes.Core;

namespace PhsyxLite.Classes.Components
{
    public class RigidBody2D : Component
    {
        public Body body { get; set; }
    }
}
