using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class AudioManager : Singleton<AudioManager> {

        [HideInInspector]
        public AudioSource audioPlayer;

        protected override void Awake() {

            base.Awake();

            audioPlayer = GetComponent<AudioSource>();

        }

    }
}