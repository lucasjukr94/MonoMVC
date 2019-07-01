using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoMVC.Controller
{
    public class MasterController : Controller
    {
        private Texture2D texture;
        private Rectangle rectangle;

        public override void Load()
        {
            rectangle = new Rectangle(0, 0, 100, 50);
            texture = new Texture2D(Global.GraphicsDevice, rectangle.Width, rectangle.Height);
            Color[] color = new Color[rectangle.Width*rectangle.Height];
            for (int i = 0; i < color.Length; ++i) color[i] = Color.Black;
            texture.SetData(color);
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Render()
        {
            //Global.GraphicsDevice.Clear(Color.Green);
            Global.SpriteBatch.Draw(texture, new Vector2(rectangle.X, rectangle.Y));
        }
    }
}
