using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JackUtil;

namespace Jam {

    public class BulletShooter : BlockBase {

        public Vector2 shootDir;
        public float shootSpeed;
        public float gapTime;
        public bool isActivated;

        Bullet bulletPrefab;

        Sequence action;

        void Start() {

            bulletPrefab = PrefabCollection.Instance.bulletPrefab;

            if (isActivated) {

                Activated();

            }
            
        }

        public void Activated() {

            isActivated = true;

            action?.Kill();

            action = DOTween.Sequence();

            action.AppendCallback(() => {

                print("Shoot");

                Bullet _bullet = Instantiate(bulletPrefab, transform.parent);
                _bullet.fallingDir = shootDir;
                _bullet.fallingSpeed = shootSpeed;
                _bullet.waitTime = 0;
                _bullet.transform.position = (Vector2)transform.position + _bullet.fallingDir;
                // _bullet.Hide();
                _bullet.Activated();

            });
            action.AppendInterval(gapTime);
            action.SetLoops(-1);

        }

    }

}