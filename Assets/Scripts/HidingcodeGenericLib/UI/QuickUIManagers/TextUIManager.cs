using System;
using TMPro;
using UnityEngine;

namespace HidingcodeGenericLib.UI.QuickUIManagers
{
    public class TextUIManager : MonoBehaviour
    {

        public static TextUIManager instanceUIManager;
        //singleton pattern
        private void Awake()
        {
            if (instanceUIManager == null)
            {
                instanceUIManager = this;
            }

            if (instanceUIManager != this)
            {
                Destroy(gameObject);
            }

            InitTextUI();

        }

        public void InitTextUI()
        {
            for (int i = 0; i < textUIList.Length; i++)
            {
                textUIList[i].InitUI();
            }
        }

        [SerializeField] TextUI[] textUIList;

        [Serializable]
        struct TextUI
        {
            public string UIName;
            public TextMeshProUGUI textMesh;
            public bool textGoUp;
            public float textGoUpDistance;
            public float textEffectTime;
            public LeanTweenType easeType;
            private Vector3 originalPos;
            private bool canAnimate;
            [SerializeField] private bool explixitDefineStartY;
            [SerializeField] Vector3 startPos;
            private int tweenId;

            public void SetText(string text)
            {
                textMesh.text = text;
                if (textGoUp && canAnimate) {
                    LeanTween.cancel(textMesh.gameObject, tweenId);
                    textMesh.transform.localPosition = originalPos;
                    tweenId =  LeanTween.moveLocalY(textMesh.gameObject, originalPos.y + textGoUpDistance, textEffectTime).setLoopPingPong(1).id;
                }
                
            }

            public void InitUI()
            {
                if (explixitDefineStartY) originalPos = startPos;
                else originalPos = textMesh.transform.localPosition;
                canAnimate = true;
                tweenId = -1;
            }

            private void AnimateEffectBack()
            {
                LeanTween.moveLocalY(textMesh.gameObject, originalPos.y, textEffectTime);
            }
        }


        public bool SetText(string UIName, string text)
        {
            for (int i = 0; i < textUIList.Length; i++)
            {
                if (UIName == textUIList[i].UIName)
                {
                    textUIList[i].SetText(text);
                    return true;
                }
            }

            Debug.LogError("text UI of nane " + UIName + " does not exist");
            return false;
        }
    }
}