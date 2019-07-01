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

        //Master-------------------------------------------------------------------------
        public static bool IsLoadedMaster { get; set; }
        public static string CurrentSceneMaster { get; set; }
        public static Controller.Controller CurrentControllerMaster { get; set; }

        public static void ChangeSceneMaster(string scene)
        {
            IsLoadedMaster = false;
            CurrentSceneMaster = scene;

        }

        //Uses the CurrentSceneMaster to attribute a Controller to CurrentControllerMaster
        public static void LoadSceneMaster()
        {
            if (string.IsNullOrEmpty(CurrentSceneMaster))
            {
                CurrentControllerMaster = null;
            }
            else
            {
                foreach (Controller.Controller c in Global.Controllers)
                {
                    if (CurrentSceneMaster == c.GetType().Name)
                    {
                        CurrentControllerMaster = c;
                    }
                }
            }
        }
    }
}
