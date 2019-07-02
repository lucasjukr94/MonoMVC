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
        private string text;

        public override void Load()
        {
            cursor = new Cursor();
        }

        public override void Update(GameTime gameTime)
        {
            cursor.Move();
            text = string.Format("X:{0}, Y:{1}", cursor.Vector2.X, cursor.Vector2.Y);
        }

        public override void Render()
        {
            Global.SpriteBatch.Draw(cursor.Texture2D, cursor.Vector2);
            Global.SpriteBatch.DrawString(Global.SpriteFont, text, Vector2.Zero, Color.Black);
        }
    }
}
