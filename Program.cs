using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using PhsyxLite.Classes;
using PhsyxLite.Classes.Core;
using PhsyxLite.Classes.Components;
using System.Runtime.InteropServices;
using Box2DX.Dynamics;
using Box2DX.Collision;
using Box2DX.Common;

namespace PhsyxLite
{
    class Program
    {

        static void Main(string[] args)
        {

            RenderWindow window = new RenderWindow(new VideoMode(1920, 1080), "PhsyxLite");
            window.Closed += CloseWindowEvent;
            window.KeyPressed += KeyPressedEvent;
            window.KeyReleased += KeyReleasedEvent;

            SFML.Graphics.Color backgroundColor = new SFML.Graphics.Color(24, 28, 31, 255);

            Log.Print("[<green>MAIN<white>] Render Loop Started.");

            Clock gameClock = new();

            // Initialize Phsyics
            Physics.Initialize();

            // Initialize Game
            Game game = new();


            while (window.IsOpen)
            {
                GTime.Update();

                window.DispatchEvents();

                window.Clear(backgroundColor);

                game.Update(); // Run The Games Update Function

                // loop threw all the game objects and render them

                foreach (GameObject gameObject in GameObjManager.gameObjects)
                {
                    RigidBody2D rigidBody2D = gameObject.GetComponent<RigidBody2D>();

                    gameObject.sprite.Position = new Vector2f(Physics.SCALE * rigidBody2D.body.GetPosition().X, Physics.SCALE * rigidBody2D.body.GetPosition().Y);
                    gameObject.sprite.Rotation = rigidBody2D.body.GetAngle() * (180 / (float)System.Math.PI);
                    window.Draw(gameObject.sprite);
                    
                    if (rigidBody2D != null)
                    {
                        gameObject.transform = new Vector2f(rigidBody2D.body.GetPosition().X, rigidBody2D.body.GetPosition().Y);
                    }
                }

                window.Display();

                Physics.Update();

                if (Input.GetKey("F4")) window.Close();
            }
        }

        private static void KeyPressedEvent(object? sender, KeyEventArgs e)
        {
            Input.addKey(e.Code);
        }

        private static void KeyReleasedEvent(object? sender, KeyEventArgs e)
        {
            Input.removeKey(e.Code);
        }

        private static void CloseWindowEvent(object? sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }


        
    }

}


