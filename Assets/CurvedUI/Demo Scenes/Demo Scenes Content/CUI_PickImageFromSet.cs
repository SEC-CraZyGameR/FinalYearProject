using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CurvedUI
{
    public class CUI_PickImageFromSet : MonoBehaviour
    {
        public ButtonID buttonId;
        public string textToSpeech = "Button pressed";

        static CUI_PickImageFromSet picked = null;

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(() => PickThis());
        }


        public void PickThis()
        {
            // if (picked != null)
            //     picked.GetComponent<Button>().targetGraphic.color = Color.white;
            //Debug.Log("Clicked this!", this.gameObject);

            VoiceController.Instance.StartSpeak(textToSpeech);

            picked = this;
            // picked.GetComponent<Button>().targetGraphic.color = Color.red;

            StartCoroutine(SendBtnClickResponse());
        }

        private IEnumerator SendBtnClickResponse()
        {
            yield return new WaitForSeconds(.25f);
            if (MenuManager.Instance != null)
            {
                if (buttonId == ButtonID.levelSelection)
                    MenuManager.Instance.ButtonClickResponse((int)buttonId, GetComponent<LevelSelectionItem>().levelInfo);
                else
                {
                    MenuManager.Instance.ButtonClickResponse((int)buttonId);
                }
                //Debug.Log("=============");
            }
        }
    }
}


