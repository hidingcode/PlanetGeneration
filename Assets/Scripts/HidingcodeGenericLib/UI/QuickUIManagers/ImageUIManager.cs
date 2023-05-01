using System;
using UnityEngine;
using UnityEngine.UI;

namespace HidingcodeGenericLib.UI.QuickUIManagers
{
    public class ImageUIManager : MonoBehaviour
    {
        public static ImageUIManager instanceImageUIManager;
        //singleton pattern
        private void Awake()
        {
            if (instanceImageUIManager == null)
            {
                instanceImageUIManager = this;
            }

            if (instanceImageUIManager != this)
            {
                Destroy(gameObject);
            }

        }


        [SerializeField] ImageUIData[] ImageUIList;

        [Serializable]
        struct ImageUIData
        {
            public string UIName;
            public Image ImageUI;
            public float fillRate;
            public float targetFill;
            public float snapFillMargin;

            public void UpdateFill()
            {
                if (ImageUI.fillAmount == targetFill) return;
                ImageUI.fillAmount = Mathf.Lerp(ImageUI.fillAmount, targetFill, fillRate * Time.deltaTime);

                if (Mathf.Abs(targetFill - ImageUI.fillAmount) <= snapFillMargin) ImageUI.fillAmount = targetFill;
            }

            public void SetFill(float value)
            {
                targetFill = value;
            }

        }

        private void Update()
        {
            for (int i = 0; i < ImageUIList.Length; i++)
            {
                ImageUIList[i].UpdateFill();
            }
        }

        public bool SetFill(string UIName, float fill)
        {
            for (int i = 0; i < ImageUIList.Length; i++)
            {
                if (UIName == ImageUIList[i].UIName)
                {
                    ImageUIList[i].SetFill(fill);
                    return true;
                }
            }

            Debug.LogError(" Image UI of nane " + UIName + " does not exist");
            return false;
        }


        public bool SetFillForce(string UIName, float fill)
        {
            for (int i = 0; i < ImageUIList.Length; i++)
            {
                if (UIName == ImageUIList[i].UIName)
                {
                    ImageUIList[i].ImageUI.fillAmount = fill;
                    return true;
                }
            }

            Debug.LogError(" Image UI of nane " + UIName + " does not exist");
            return false;
        }

        public bool SetImage(string UIName, Sprite image)
        {
            for (int i = 0; i < ImageUIList.Length; i++)
            {
                if (UIName == ImageUIList[i].UIName)
                {
                    ImageUIList[i].ImageUI.sprite = image;
                    return true;
                }
            }

            Debug.LogError(" Image UI of nane " + UIName + " does not exist");
            return false;
        }


    }
}