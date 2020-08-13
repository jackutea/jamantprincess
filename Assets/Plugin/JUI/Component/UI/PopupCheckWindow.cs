using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace JackUtil {

    public class PopupCheckWindow : MonoBehaviour {

        public Text titleText;
        public Text contentText;
        public Button yesButton;
        public Text yesText;
        public Button noButton;
        public Text noText;

        // TODO FontSize Padding BordSize

        public void SetTexts(string _title, string _content) {

            SetTitle(_title);

            SetContent(_content);

        }

        public void SetTitle(string _text) {

            titleText.text = _text;

        }

        public void SetContent(string _text) {

            contentText.text = _text;

        }

        public void BindingYes(Action _action) {

            yesButton.onClick.RemoveAllListeners();
            yesButton.onClick.AddListener(() => {
                _action?.Invoke();
                if (_action == null) {
                    DebugUtil.LogWarning("未绑定事件");
                    DefaultClose();
                }
            });

            EventSystem.current.SetSelectedGameObject(yesButton.gameObject);

        }

        public void BindingNo(Action _action) {

            noButton.onClick.RemoveAllListeners();
            noButton.onClick.AddListener(() => {
                _action?.Invoke();
                if (_action == null) {
                    DebugUtil.LogWarning("未绑定事件");
                    DefaultClose();
                }
            });

        }

        void DefaultClose() {

            Destroy(gameObject);

        }

    }
}