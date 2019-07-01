using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoMVC.Controller;

namespace MonoMVC
{
    //Every global variables used between the game and controller are defined here
    public static class Global
    {
        public static string DefaultController
        {
            get { return @"HomeController"; }
        }

        public static ContentManager Content { get; set; }
        public static SpriteBatch SpriteBatch { get; set; }
        public static GraphicsDevice GraphicsDevice { get; set; }

        public static List<Controller.Controller> Controllers { get; set; }

        public static void LoadControllers()
        {
            Controllers = new List<Controller.Controller>();

            Controllers.Add(new HomeController());
            Controllers.Add(new MenuController());
        }

    }
}
