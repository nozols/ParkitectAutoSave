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

        public void OnGUI() {
            if (GameController.Instance.isSavingGame) {
                GUI.Label(new Rect(Screen.width - 110, 10, 100, 100), "Saving game");
            }
        }
        public void Update() {
            if (Input.GetKeyUp(KeyCode.F5)) {
                Debug.Log("Quicksaving game.");
                GameController.Instance.saveGame("Saves/Savegames/QuickSave-" + GameController.Instance.park.parkName + ".txt");
                Debug.Log("Finsihed quicksaving");
            }
        }

        private IEnumerator AutoSave() {
            for (;;) {
                Debug.Log("Autosaving game.");
                GameController.Instance.saveGame("Saves/Savegames/AutoSave-" + GameController.Instance.park.parkName + ".txt");
                Debug.Log("Finished autosaving.");

                yield return new WaitForSeconds(300);
            }
        }
    }
}
