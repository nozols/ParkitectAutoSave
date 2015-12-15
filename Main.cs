using UnityEngine;

namespace AutoSave
{
    public class Main : IMod
    {
        private GameObject __go;

        public string Description
        {
            get
            {
                return "Enables autosave";
            }
        }

        public string Name
        {
            get
            {
                return "AutoSave";
            }
        }

        public void onDisabled()
        {
            UnityEngine.Object.Destroy(__go);
        }

        public void onEnabled()
        {
            __go = new GameObject();
            __go.AddComponent<AutoSaveBehaviour>();
        }
    }
}
