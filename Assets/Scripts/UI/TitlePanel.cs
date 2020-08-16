using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class TitlePanel : MonoBehaviour {

        public Image img;
        Sequence action;

        public Image storyImg;
        bool isStory;

        void Start() {

            Vector2 _defaultPos = transform.localPosition;

            isStory = false;
            storyImg.gameObject.SetActive(false);

            action = DOTween.Sequence();
            action.Append(img.DOFade(0.85f, 0.5f));
            // action.AppendInterval(0.2f);
            action.Append(img.DOFade(1f, 0.2f));
            // action.AppendInterval(0.5f);
            action.SetLoops(-1);

        }

        void Update() {

            if (isActiveAndEnabled) {

                if (Input.GetKeyUp(KeyCode.J)) {

                    AudioManager.Instance.Play(AudioType.Change);

                    if (!isStory) {

                        isStory = true;
                        storyImg.gameObject.SetActive(true);

                    } else {

                        isStory = false;
                        App.Instance.LoadMap(App.Instance.startLevelId);
                        storyImg.gameObject.SetActive(false);
                        this.Hide();

                    }

                } else if (Input.GetKeyUp(KeyCode.Escape)) {

                    Application.Quit();

                }

            }
        }
    }
}