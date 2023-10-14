using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhsyxLite.Classes.Components;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using Box2DX.Collision;
using Box2DX.Common;
using PhsyxLite.Classes.Core;
using Box2DX.Dynamics;

namespace PhsyxLite.Classes
{
    public class Game
    {
        GameObject player;
        RigidBody2D rigidBody2D;

        Sprite playerSprite;

        public Game()
        {
            Start();
        }


        void Start()
        {
            player = new GameObject(1800, 200, 20, 20, "player", "Textures/flappybird_spritesheet.png", true, false, "player");
            rigidBody2D = player.GetComponent<RigidBody2D>();


            for (int y = 1000; y <= 1100; y+= 50)
            {
                for (int x = -150; x <= 5000; x += 50)
                {
                    GameObject newBarrier = new GameObject(x, y, 16, 15, "ground", "Textures/Glowing_Square.png", false, true, "ground");
                }
            }

            // Lets do the wall on the right
            for (int y = 0; y <= 950; y += 50)
            {
                GameObject newBarrier = new GameObject(1900, y, 16, 15, "ground", "Textures/Glowing_Square.png", false, true, "ground");
            }

            // Lets do the wall on the left
            for (int y = 0; y <= 950; y += 50)
            {
                GameObject newBarrier = new GameObject(0, y, 16, 15, "ground", "Textures/Glowing_Square.png", false, true, "ground");
            }
        }

        public void Update()
        {
            //Log.Print(Mouse.GetPosition());
            Log.Print($"X: {rigidBody2D.body.GetLinearVelocity().X} Y: {rigidBody2D.body.GetLinearVelocity().Y}");

            if (Input.GetKey("D"))
            {
                rigidBody2D.body.SetLinearVelocity(new Vec2(5f, 0.0f));
            }

            if (Input.GetKey("A"))
            {
                rigidBody2D.body.SetLinearVelocity(new Vec2(-5f, 0.0f));
            }

        }
    }
}
