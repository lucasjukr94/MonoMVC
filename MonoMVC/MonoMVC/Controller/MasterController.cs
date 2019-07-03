using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoMVC.Model.Entity;

namespace MonoMVC.Controller
{
    public class MasterController : Controller
    {
        private Cursor cursor;
        private Box box;
        private string text;

        private List<Entity> entities; 

        public override void Load()
        {
            cursor = new Cursor();
            box = new Box();

            entities = new List<Entity>();
            entities.Add(cursor);
            entities.Add(box);
        }

        public override void Update(GameTime gameTime)
        {
            cursor.Move();
            Collision.CheckAllCollision(entities);
            text = string.Format("X:{0}, Y:{1}, SpeedX:{2}, SpeedY:{3}", cursor.Vector2.X, cursor.Vector2.Y,
                cursor.SpeedX, cursor.SpeedY);
            box.Move();
        }

        public override void Render()
        {
            foreach (Entity e in entities.OrderBy(x => x.RenderPriority))
            {
                Global.SpriteBatch.Draw(e.Texture2D, e.Vector2);
            }
            Global.SpriteBatch.DrawString(Global.SpriteFont, text, Vector2.Zero, Color.Black);
        }
    }
}
