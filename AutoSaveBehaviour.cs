using UnityEngine;
using System.Collections;

namespace AutoSave
{
    class AutoSaveBehaviour : MonoBehaviour
    {
        public void Awake() {
            DontDestroyOnLoad(this);
        }

        public void Start() {
            StartCoroutine("AutoSave");
        }

        public void onGUI() {
            GUI.Label(new Rect(Screen.width - 210, 10, 100, 100), "Autosaving game");
            if (GameController.Instance.isSavingGame) {
                GUI.Label(new Rect(Screen.width - 110, 10, 100, 100), "Autosaving game");
            }
        }

        private IEnumerator AutoSave() {
            for (;;) {
                Debug.Log("Autosaving game.");
                GameController.Instance.saveGame("Saves/Savegames/AutoSave-" + GameController.Instance.park.parkName + ".txt");
                Debug.Log("Finished autosaving.");

                yield return new WaitForSeconds(20);
            }
        }
    }
}
