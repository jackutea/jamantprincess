using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using JackUtil;

namespace Jam {

    [ExecuteInEditMode]
    public class MainCam : MonoBehaviour {

        public Material material;
        public bool isGray;

        void Awake() {

        }

        void OnRenderImage(RenderTexture srcTexture, RenderTexture destTexture){
            if (isGray) {
                // material.SetFloat ("_LuminosityAmount", 0.5f);
                Graphics.Blit (srcTexture, destTexture, material);
            } else {
                Graphics.Blit (srcTexture, destTexture);
            }
        }

    }
}