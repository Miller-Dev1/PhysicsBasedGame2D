using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhsyxLite.Classes.Core
{
    public class Input
    {
        static List<Keyboard.Key> pressedKeys = new List<Keyboard.Key>();

        public static bool GetKey(string key)
        {
            return pressedKeys.Contains((Keyboard.Key)Enum.Parse(typeof(Keyboard.Key), key));
        }

        public static void addKey(Keyboard.Key key)
        {
            if (!pressedKeys.Contains(key)) pressedKeys.Add(key);
        }

        public static void removeKey(Keyboard.Key key)
        {
            if (pressedKeys.Contains(key)) pressedKeys.Remove(key);
        }
    }

}
