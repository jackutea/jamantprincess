using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JackUtil {

    public class NoticeWindow : MonoBehaviour {

        public GameObject noticeBd;
        public GameObject titleBd;
        public Text titleText;
        Image bgImg;
        RectTransform rect;
        [HideInInspector]
        public NoticeContentGo contentPrefab;

        List<NoticeContentGo> contentList;

        void Awake() {

            bgImg = GetComponent<Image>();
            rect = GetComponent<RectTransform>();

            contentList = new List<NoticeContentGo>();

        }

        public void SetMaxWidth(float _width = 120) {
            rect.sizeDelta = new Vector2(_width, rect.sizeDelta.y);
        }

        public void SetBgColor(Color _bgColor) {

            bgImg.color = _bgColor;

        }

        public void SetNotice(string _title = "") {

            if (_title == "") {

                titleBd.SetActive(false);

            } else {

                titleBd.SetActive(true);
                titleText.text = _title;

            }

            contentList.DestroyGoList();

            this.Show();

        }

        public void AddContent(string _content, Sprite _sprite = null, Color _color = default) {

            NoticeContentGo _contentGo = Instantiate(JUIPrefabCollection.Instance.noticeContentPrefab, noticeBd.transform);
            if (_color == default) {
                _color = Color.white;
            }
            _contentGo.RenderContent(_content, _sprite, _color);
            contentList.Add(_contentGo);

        }

    }

}