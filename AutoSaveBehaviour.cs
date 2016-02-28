using UnityEngine;
using System.Collections;

namespace AutoSave
{
    public class AutoSaveBehaviour : MonoBehaviour
    {
        public void Start()
        {
            StartCoroutine("AutoSave");
        }

        public void OnDisable() {
            StopCoroutine("AutoSave");
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

                yield return new WaitForSeconds(Main._timeInterval);
            }
        }
        
        private void CustomSaveGame(string aoq) {
            GameController.Instance.saveGame(GameController.savegamesPath + aoq + "-" + GameController.Instance.park.parkName + ".txt", false);
        }
    }
}
