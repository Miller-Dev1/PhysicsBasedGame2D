using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SFML.Graphics;
using SFML.System;

namespace PhsyxLite.Classes.Core
{
    public static class Utils
    {
        public static Sprite CreateSprite2D(string path, bool isSpritesheet, float xScale, float yScale)
        {
            string workingDirectory = Directory.GetCurrentDirectory();

            int indexOfBin = workingDirectory.IndexOf("\\bin");

            workingDirectory = workingDirectory.Substring(0, indexOfBin);

            Texture texture = new(workingDirectory + "\\Assets\\" + path)
            {
                Smooth = false,
            };

            Sprite sprite = new(texture)
            {
                Scale = new Vector2f(xScale / (Physics.SCALE / 2f), yScale / (Physics.SCALE / 2f)),
                Origin = new Vector2f(xScale / (Physics.SCALE / 2f), yScale / (Physics.SCALE / 2f))
            };

            if (isSpritesheet)
            {
                //sprite.TextureRect = new IntRect(25, 0, (int)xScale, (int)yScale);
                sprite.TextureRect = new IntRect(25, 0, 32, 32);
            }

            return sprite;
        }
    }
}
