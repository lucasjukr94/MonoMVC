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
                foreach (Entity b in entities.Where(x => x != a))
                {
                    if (CheckCollision(a, b))
                    {
                        a.Rectangle = new Rectangle(a.Rectangle.X + a.SpeedX * (-1), a.Rectangle.Y + a.SpeedY * (-1),
                            a.Rectangle.Width, a.Rectangle.Height);
                        b.Rectangle = new Rectangle(b.Rectangle.X + b.SpeedX * (-1), b.Rectangle.Y + b.SpeedY * (-1),
                            b.Rectangle.Width, b.Rectangle.Height);
                    }
                }
            }
        }

        public static bool CheckCollision(Entity a, Entity b)
        {
            if (a.Rectangle.Intersects(b.Rectangle))
            {
                return true;
            }

            return false;
        }
    }
}
