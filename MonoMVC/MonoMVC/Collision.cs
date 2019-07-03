using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MonoMVC.Model.Entity;

namespace MonoMVC
{
    public static class Collision
    {
        public static void CheckAllCollision(List<Entity> entities)
        {
            //TODO: Needs optimization, it's verifying every collision now
            foreach (Entity a in entities)
            {
                foreach (Entity b in entities.Where(x => a.Rectangle.Intersects(x.Rectangle)))
                {
                    a.Rectangle = new Rectangle(a.Rectangle.X + a.SpeedX, a.Rectangle.Y + a.SpeedY,
                            a.Rectangle.Width, a.Rectangle.Height);
                    b.Rectangle = new Rectangle(b.Rectangle.X - a.SpeedX, b.Rectangle.Y - a.SpeedY,
                        b.Rectangle.Width, b.Rectangle.Height);
                }
            }
        }
    }
}
