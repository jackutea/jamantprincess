using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class UIManager : Singleton<UIManager> {

        public Camera uiCamera;
        public Canvas uiCanvas;
        public Canvas worldCanvas;

        public DialogWindow dialog;

        public TitlePanel titlePanel;
        public GamePanel gamePanel;
        
        protected override void Awake() {

            base.Awake();

        }

        public void EnterTitle() {

            titlePanel.gameObject.SetActive(true);
            gamePanel.gameObject.SetActive(false);
            AudioManager.Instance.PlayBGM(false);

        }

        public void EnterGame() {

            titlePanel.gameObject.SetActive(false);
            gamePanel.gameObject.SetActive(true);
            AudioManager.Instance.PlayBGM(true);

        }

    }

}
