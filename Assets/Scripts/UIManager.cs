using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class UIManager : MonoBehaviour {

        static UIManager m_instance;
        public static UIManager Instance => m_instance;

        public Camera uiCamera;
        public Canvas uiCanvas;

        void Awake() {

            if (m_instance == null) {
                m_instance = this;
            }

        }

    }

}
