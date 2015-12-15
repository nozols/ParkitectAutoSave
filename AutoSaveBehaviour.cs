using UnityEngine;
using System.Collections;
using Parkitect.UI;
using System;

namespace AutoSave
{
    class AutoSaveBehaviour : MonoBehaviour
    {
        public void Start()
        {
            StartCoroutine("AutoSave");
        }

        public void OnGUI()
        {
            if (GameController.Instance.isSavingGame)
            {
                GUI.Label(new Rect(Screen.width - 110, 10, 100, 100), "Saving game");
            }
        }
        public void Update()
        {
            if (Input.GetKeyUp(KeyCode.F5))
            {
                CustomSaveGame("QuickSave");
            }
            
        }

        private IEnumerator AutoSave()
        {
            for (;;)
            {
                CustomSaveGame("AutoSave");

                yield return new WaitForSeconds(300);
            }
        }

        
        private void CustomSaveGame(string aoq) {
            GameController.Instance.saveGame("Saves/Savegames/" + aoq + "-" + GameController.Instance.park.parkName + ".txt", false);
        }
    }
}
