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
        Change,

    }

    public class AudioManager : Singleton<AudioManager> {

        public AudioSource audioPlayer;
        public AudioSource bgmPlayer;

        public AudioClip BGM;
        public AudioClip kill;
        public AudioClip broken;
        public AudioClip walk;
        public AudioClip fallingWall;
        public AudioClip jump;
        public AudioClip transDoor;

        protected override void Awake() {

            base.Awake();

        }

        void Update() {

        }

        public void PlayBGM(bool _isstart) {

            bgmPlayer.volume = 0.2f;

            if (!_isstart) {

                bgmPlayer.Stop();

            } else {

                bgmPlayer.clip = BGM;
                bgmPlayer.Play();

            }

        }

        public void Play(AudioType _audio) {

            audioPlayer.volume = 0.5f;

            switch(_audio) {
                case AudioType.Broken: audioPlayer.clip = broken; audioPlayer.loop = false; break;
                case AudioType.Kill: audioPlayer.clip = kill; audioPlayer.loop = false; break;
                case AudioType.Walk: return;
                case AudioType.FallingWall: audioPlayer.clip = fallingWall; audioPlayer.loop = false; break;
                case AudioType.Jump: audioPlayer.clip = jump; audioPlayer.loop = false; break;
                case AudioType.TransDoor: audioPlayer.clip = transDoor; audioPlayer.loop = false; break;
                case AudioType.Change: audioPlayer.clip = walk; audioPlayer.loop = false; break;
                default: DebugUtil.Log("错误类型"); break;
            }

            // print("Player" + _audio.ToString());
            // if (audioPlayer.clip == walk) {
            //     if (!audioPlayer.isPlaying) {
            //         audioPlayer.Play(); 
            //     }
            //     return;
            // }

            audioPlayer.Play(); 

        }

    }
}