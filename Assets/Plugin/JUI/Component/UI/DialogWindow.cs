using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace JackUtil {

    public class DialogWindow : MonoBehaviour {

        Sprite leftTalkerSprite;
        Sprite rightTalkerSprite;
        string leftTalkerName;
        string rightTalkerName;
        List<string> talkerList;
        List<string> contentList;
        int currentIndex;

        Button button;

        public Text contentText;
        public Text nameText;
        public Image icon;
        public Action endTalkAction;

        Tween contentTween;

        void Awake() {

            button = GetComponent<Button>();
            button.onClick.AddListener(NextContent);

            currentIndex = -1;
            talkerList = new List<string>();
            contentList = new List<string>();

        }

        public void SetTalkerInfo(Sprite _leftTalkerSprite, string _leftTalkerName, Sprite _rightTalkerSprite, string _rightTalkerName, Action _endTalkAction) {

            currentIndex = -1;

            leftTalkerSprite = _leftTalkerSprite;
            leftTalkerName = _leftTalkerName;
            rightTalkerSprite = _rightTalkerSprite;
            rightTalkerName = _rightTalkerName;
            
            endTalkAction = _endTalkAction;

            EventSystem.current.SetSelectedGameObject(gameObject);

        }

        public void AddContent(bool _isLeftTalker, string _content, string _talkerName = "") {

            if (_isLeftTalker) {

                _talkerName = _talkerName == "" ? leftTalkerName : _talkerName;
                
            } else {

                _talkerName = _talkerName == "" ? rightTalkerName : _talkerName;

            }

            talkerList.Add(_talkerName);
            contentList.Add(_content);

        }

        public void NextContent() {

            (string talker, string content) = GetCurrent();

            if (talker == string.Empty && content == string.Empty) {
                endTalkAction?.Invoke();
                Destroy(gameObject);
                return;
            }

            nameText.text = talker;

            if (contentTween != null) {

                contentTween.Kill();

            }

            contentTween = contentText.DOText(content, content.Length * 0.04f);

            Sprite _sprite;
            if (talker == leftTalkerName) {
                _sprite = leftTalkerSprite;
            }  else {
                _sprite = rightTalkerSprite;
            }

            icon.sprite = _sprite;

        }

        (string talker, string content) GetCurrent() {

            if (currentIndex + 1 < talkerList.Count && currentIndex + 1 < contentList.Count) {

                currentIndex += 1;

                return (talkerList[currentIndex], contentList[currentIndex]);

            } else {

                currentIndex = -1;

                return (string.Empty, string.Empty);

            }

        }

    }
}