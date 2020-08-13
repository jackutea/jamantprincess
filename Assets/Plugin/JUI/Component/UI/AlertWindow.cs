using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JackUtil {

    public class AlertWindow : MonoBehaviour {

        public GameObject alertBd;
        public CanvasGroup canvasGroup;
        [HideInInspector]
        public NoticeContentGo contentPrefab;

        public Image bgImg;
        public RectTransform rect;

        List<NoticeContentGo> contentList;

        WaitForSeconds wait;

        void Awake() {

            bgImg = GetComponent<Image>();
            rect = GetComponent<RectTransform>();

            contentList = new List<NoticeContentGo>();

        }

        public void SetAlert(float _fadeTime = -1f) {

            _fadeTime = _fadeTime == -1f ? Time.deltaTime * 10 : _fadeTime;

            wait = new WaitForSeconds(_fadeTime);

            contentList.DestroyGoList();

            this.Show();

            StartCoroutine(FadeAni());

        }

        public void AddContent(string _content, Sprite _sprite = null, Color _color = default) {

            NoticeContentGo _contentGo = Instantiate(JUIPrefabCollection.Instance.noticeContentPrefab, alertBd.transform);
            _contentGo.RenderContent(_content, _sprite, _color);
            contentList.Add(_contentGo);

        }

        IEnumerator FadeAni() {

            while (canvasGroup.alpha > 0) {

                canvasGroup.alpha -= 0.1f;

                yield return wait;

            }

            Destroy(gameObject);

        }

    }
}