using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace JackUtil {

    public class NoticeContentGo : MonoBehaviour {

        public GameObject imageBd;
        public Image image;
        public Text text;

        public void RenderContent(string _content, Sprite _sprite, Color _color, bool _isTyping = false) {

            if (_sprite == null) {

                Destroy(imageBd.gameObject);

            } else {

                image.sprite = _sprite;

            }

            text.color = _color;

            if (_isTyping) {

                text.text = string.Empty;

                text.DOText(_content, _content.Length * 0.08f);

            } else {

                text.text = _content;

            }
            
        }

    }
}