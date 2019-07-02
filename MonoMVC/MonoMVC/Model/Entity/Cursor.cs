using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoMVC.Model.Entity
{
    public class Cursor : Entity
    {
        public Cursor()
        {
            Rectangle = new Rectangle(0, 0, 20, 20);
            Texture2D = RectangleTexture2D;
            RenderPriority = 999;
        }

        public void Move()
        {
            Rectangle = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, Rectangle.Width, Rectangle.Height);
        }
    }
}
