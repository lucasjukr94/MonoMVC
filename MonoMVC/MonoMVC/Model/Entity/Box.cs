using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MonoMVC.Model.Entity
{
    public class Box : Entity
    {
        public Box()
        {
            Rectangle = new Rectangle(150, 150, 150, 150);
            Texture2D = RectangleTexture2D;
            RenderPriority = 0;
        }
    }
}
