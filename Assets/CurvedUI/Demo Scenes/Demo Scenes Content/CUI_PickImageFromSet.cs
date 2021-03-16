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
        public string textToSpeech;

        static CUI_PickImageFromSet picked = null;

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(() => PickThis());
        }

        private void OnEnable()
        {
            if (string.IsNullOrEmpty(textToSpeech))
            {
                textToSpeech = "Button Clicked";
            }
        }

        public void PickThis()
        {
            // if (picked != null)
            //     picked.GetComponent<Button>().targetGraphic.color = Color.white;
            //Debug.Log("Clicked this!", this.gameObject);

            //VoiceController.Instance.StartSpeak(textToSpeech);
            SoundManager.Instance.PlayBtnSound();
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
                {
                    LevelInfo levelInfo = GetComponent<LevelSelectionItem>().levelInfo;
                    if (levelInfo.isUnlocked)
                    {
                        Appdelegate.SharedManager().selectedLevelIfo = levelInfo;
                        MenuManager.Instance.ButtonClickResponse((int)buttonId, levelInfo);
                    }
                    else
                    {
                        VoiceController.Instance.StartSpeak("Please, clear previous level to unlock this level");
                    }
                }
                else
                {
                    MenuManager.Instance.ButtonClickResponse((int)buttonId);
                }
                //Debug.Log("=============");
            }
        }
    }
}


