using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace JackUtil {
    
    public class OptionWindow : MonoBehaviour {

        public Text titleText;
        public Text conenteText;

        public GameObject optionBd;
        OptionButtonGo buttonPrefab;
        [HideInInspector]
        public List<OptionButtonGo> optionList;
        OptionButtonGo defaultOption;

        void Awake() {

            buttonPrefab = JUIPrefabCollection.Instance.optionButtonPrefab;

            optionList = new List<OptionButtonGo>();

        }

        public void SetTexts(string _title, string _content) {

            SetTitle(_title);

            SetContent(_content);

        }

        public void SetTitle(string _title) {

            titleText.text = _title;

        }

        public void SetContent(string _content) {

            conenteText.text = _content;

        }

        public OptionButtonGo AddOption(string _optionName, Action _optionAction) {

            OptionButtonGo _option = Instantiate(buttonPrefab, optionBd.transform);

            _option.buttonText.text = _optionName;

            _option.button.onClick.RemoveAllListeners();

            _option.button.onClick.AddListener(() => {
                _optionAction?.Invoke();
                if (_optionAction == null) {
                    DebugUtil.LogWarning("未绑定事件");
                    Destroy(gameObject);
                }
            });

            optionList.Add(_option);

            if (defaultOption == null) {

                defaultOption = _option;
                
            }

            return _option;

        }

        public void SetDefaultOption(OptionButtonGo _optionGo) {

            EventSystem.current.SetSelectedGameObject(_optionGo.gameObject);

        }

    }
}