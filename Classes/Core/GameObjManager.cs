using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhsyxLite.Classes.Core
{
    class GameObjManager
    {
        public static List<GameObject> gameObjects = new List<GameObject>();

        public static void addGameObject(GameObject gameObject)
        {
            if (!gameObjects.Contains(gameObject)) gameObjects.Add(gameObject);
        }

        public static void removeGameObject(GameObject gameObject)
        {
            if (gameObjects.Contains(gameObject)) gameObjects.Remove(gameObject);
        }
    }
}
