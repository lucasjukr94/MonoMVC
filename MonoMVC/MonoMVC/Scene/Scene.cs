using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoMVC.Scene
{
    //It defines which controller is being used currently
    public static class Scene
    {
        public static bool IsLoaded { get; set; }
        public static string CurrentScene { get; set; }
        public static Controller.Controller CurrentController { get; set; }

        public static void ChangeScene(string scene)
        {
            IsLoaded = false;
            CurrentScene = scene;

        }

        //Uses the CurrentScene to attribute a Controller to CurrentController
        public static void LoadScene()
        {
            foreach (Controller.Controller c in Global.Controllers)
            {
                if (CurrentScene == c.GetType().Name)
                {
                    CurrentController = c;
                }
            }
        }
    }
}
