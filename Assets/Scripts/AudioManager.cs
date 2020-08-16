using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public enum AudioType {

        Kill,
        Broken,
        Walk,
        FallingWall,
        Jump,
        TransDoor,
    }

    public class AudioManager : Singleton<AudioManager> {

        [HideInInspector]
        public AudioSource audioPlayer;

        public AudioClip BGM;
        public AudioClip kill;
        public AudioClip broken;
        public AudioClip walk;
        public AudioClip fallingWall;
        public AudioClip jump;
        public AudioClip transDoor;

        protected override void Awake() {

            base.Awake();

            audioPlayer = GetComponent<AudioSource>();

        }

        void Update() {

        }

        public void Play(AudioType _audio) {

            switch(_audio) {
                case AudioType.Broken: audioPlayer.clip = broken; audioPlayer.loop = false; break;
                case AudioType.Kill: audioPlayer.clip = kill; audioPlayer.loop = false; break;
                case AudioType.Walk: audioPlayer.clip = walk; audioPlayer.loop = false; break;
                case AudioType.FallingWall: audioPlayer.clip = fallingWall; audioPlayer.loop = false; break;
                case AudioType.Jump: audioPlayer.clip = jump; audioPlayer.loop = false; break;
                case AudioType.TransDoor: audioPlayer.clip = transDoor; audioPlayer.loop = false; break;
                default: DebugUtil.Log("错误类型"); break;
            }

            // print("Player" + _audio.ToString());
            if (audioPlayer.clip == walk) {
                if (!audioPlayer.isPlaying) {
                    audioPlayer.Play(); 
                }
            } else {
                audioPlayer.Play(); 
            }

        }

    }
}