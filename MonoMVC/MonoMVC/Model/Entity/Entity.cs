using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoMVC.Model.Entity
{
    public abstract class Entity
    {
        public int RenderPriority { get; set; }

        public Texture2D Texture2D { get; set; }
        public Rectangle Rectangle { get; set; }

        public int SpeedX { get; set; }
        public int SpeedY { get; set; }

        public Vector2 Vector2
        {
            get { return new Vector2(Rectangle.X, Rectangle.Y); }
        }

        public Texture2D RectangleTexture2D
        {
            get
            {
                Texture2D texture = new Texture2D(Global.GraphicsDevice, Rectangle.Width, Rectangle.Height);
                Color[] color = new Color[Rectangle.Width * Rectangle.Height];
                for (int i = 0; i < color.Length; ++i) color[i] = Color.Black;
                texture.SetData(color);

                return texture;
            }
        }
    }
}
