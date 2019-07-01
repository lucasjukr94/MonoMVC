using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoMVC.Controller
{
    public class MenuController : Controller
    {
        public override void Load()
        {

        }

        public override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Scene.Scene.ChangeScene("HomeController");
            }
        }

        public override void Render()
        {
            Global.GraphicsDevice.Clear(Color.White);

        }
    }
}
