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
        
        protected override void Awake() {

            base.Awake();

        }

    }

}
