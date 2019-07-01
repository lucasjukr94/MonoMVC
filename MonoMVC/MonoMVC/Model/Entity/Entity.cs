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

        public Vector2 Vector2
        {
            get { return new Vector2(Rectangle.X, Rectangle.Y); }
        }
    }
}
