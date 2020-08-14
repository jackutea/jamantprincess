using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace JackUtil {

    public class DialogWindow : WindowBase {

        public GameObject iconBd;

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

        bool isStaticPos;
        Vector2 staticPos;
        Vector2 leftPos;
        Vector2 rightPos;

        Tween contentTween;

        void Awake() {

            button = GetComponent<Button>();
            button.onClick.AddListener(NextContent);

            currentIndex = -1;
            talkerList = new List<string>();
            contentList = new List<string>();

            isStaticPos = true;

        }

        public void SetTalkerInfo(Sprite _leftTalkerSprite, string _leftTalkerName, Sprite _rightTalkerSprite, string _rightTalkerName, Action _endTalkAction) {

            staticPos = transform.position;

            currentIndex = -1;

            leftTalkerSprite = _leftTalkerSprite;
            leftTalkerName = _leftTalkerName;
            rightTalkerSprite = _rightTalkerSprite;
            rightTalkerName = _rightTalkerName;
            
            endTalkAction = _endTalkAction;

            EventSystem.current.SetSelectedGameObject(gameObject);

        }

        public void SetStaticPos(Vector2 _staticPos) {

            isStaticPos = true;

            staticPos = _staticPos;

        }

        public void FollowPos(Vector2 _leftPos, Vector2 _rightPos) {

            isStaticPos = false;

            leftPos = _leftPos;

            rightPos = _rightPos;

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
            Vector2 _pos;
            if (talker == leftTalkerName) {
                _sprite = leftTalkerSprite;
                _pos = leftPos;
            }  else {
                _sprite = rightTalkerSprite;
                _pos = rightPos;
            }

            if (isStaticPos) {
                _pos = staticPos;
            }

            icon.sprite = _sprite;

            if (_sprite == null) {
                iconBd.SetActive(false);
            }

            JudgePos(_pos);

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