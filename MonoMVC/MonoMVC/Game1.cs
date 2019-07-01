using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoMVC
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Global.Content = Content;
            Global.GraphicsDevice = GraphicsDevice;
            Global.LoadControllers();//Has to be called before Scene.LoadScene()
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Global.SpriteBatch = spriteBatch;

            //Loads default scene
            Scene.Scene.CurrentScene = Global.DefaultController;
            if (!Scene.Scene.IsLoaded)
            {
                Scene.Scene.LoadScene();
                Scene.Scene.CurrentController.Load();
                Scene.Scene.IsLoaded = true;
            }
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (string.IsNullOrWhiteSpace(Scene.Scene.CurrentScene))
            {
                Scene.Scene.CurrentScene = Global.DefaultController;
            }
            if (!Scene.Scene.IsLoaded)
            {
                Scene.Scene.LoadScene();
                Scene.Scene.CurrentController.Load();
                Scene.Scene.IsLoaded = true;
            }
            else
            {
                Scene.Scene.CurrentController.Update(gameTime);
            }



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            if (Scene.Scene.IsLoaded)
            {
                Scene.Scene.CurrentController.Render();
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
