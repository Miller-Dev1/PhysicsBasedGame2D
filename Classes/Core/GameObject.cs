using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
using PhsyxLite.Classes.Components;
using PhsyxLite.Classes.Core;
using Box2DX.Dynamics;

namespace PhsyxLite.Classes.Core
{
    public class GameObject
    {
        public List<Component> components = new List<Component>();
        public string name { get; set; }
        public string tag { get; set; }
        public bool isStatic { get; set; }
        public Vector2f transform { get; set; }

        public Sprite sprite;

        public GameObject(float startPosX, float startPosY, float xScale, float yScale, string objectName, string spritePath = "", bool isSpritesheet = false, bool isStatic = true, string tag = "Untagged")
        {
            name = objectName;
            this.tag = tag;
            this.isStatic = isStatic;
            transform = new Vector2f(startPosX, startPosY);

            Body body = Physics.CreateBody(isStatic, startPosX, startPosY, xScale, yScale);

            Component physicsBody = AddComponent<RigidBody2D>();
            ((RigidBody2D)physicsBody).body = body;


            if (spritePath != "")
            {
                sprite = Utils.CreateSprite2D(spritePath, isSpritesheet, xScale, yScale);
            }

            GameObjManager.addGameObject(this);
        }

        public void Destroy()
        {
            GameObjManager.removeGameObject(this);
        }

        public Component AddComponent<T>() where T : Component, new()
        {
            if (!HasComponent<T>())
            {
                T component = new T();
                components.Add(component); ;
                component.gameObject = this;
                return component;
            } else 
                return GetComponent<T>();
        }

        public T GetComponent<T>()
        {
            foreach (object component in components)
            {
                if (component.GetType() == typeof(T))
                {
                    return (T)component;
                }
            }

            return default(T);
        }

        public bool HasComponent<T>() where T : Component
        {
            return components.Any(c => c.GetType() == typeof(T));
        }

    }
}
