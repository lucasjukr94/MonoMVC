using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/* Essentials:
 * 
 * Scene.cs
 * Global.cs
 * Controller.cs
 * 
 * Define Global.DefaultController
 * 
 * At least 1 Controller
 * Obs: Master Controller is not a must
 */
namespace MonoMVC
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private SpriteFont font;
        
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
            font = Content.Load<SpriteFont>("File");

            Global.SpriteBatch = spriteBatch;
            Global.SpriteFont = font;

            //Loads default master scene if there is one
            Scene.Scene.CurrentSceneMaster = Global.DefaultControllerMaster;
            if (!string.IsNullOrEmpty(Scene.Scene.CurrentSceneMaster))
            {
                if (!Scene.Scene.IsLoadedMaster)
                {
                    Scene.Scene.LoadSceneMaster();
                    Scene.Scene.CurrentControllerMaster.Load();
                    Scene.Scene.IsLoadedMaster = true;
                }
            }
            
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

            //updating master scene
            if (!string.IsNullOrEmpty(Scene.Scene.CurrentSceneMaster))
            {
                if (!Scene.Scene.IsLoadedMaster)
                {
                    Scene.Scene.LoadSceneMaster();
                    Scene.Scene.CurrentControllerMaster.Load();
                    Scene.Scene.IsLoadedMaster = true;
                }
                else
                {
                    Scene.Scene.CurrentControllerMaster.Update(gameTime);
                }
            }

            //updating scene
            if (string.IsNullOrEmpty(Scene.Scene.CurrentScene))
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
            //Loading scene controller
            if (Scene.Scene.IsLoaded)
            {
                Scene.Scene.CurrentController.Render();
            }

            //Loading master scene controller
            if (Scene.Scene.IsLoadedMaster)
            {
                Scene.Scene.CurrentControllerMaster.Render();
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
