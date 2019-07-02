using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    CheckCollision(a, b);
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
