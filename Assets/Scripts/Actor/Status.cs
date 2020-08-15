using System;

namespace Jam {

    [Serializable]
    public class Status {

        public float jumpSpeed;
        public float fallingSpeed;
        public float fallingSpeedMax;
        public float raiseSpeed;

        public Status(int _bodySize) {

            switch(_bodySize) {
                case 0:
                    jumpSpeed = 7.25f;
                    fallingSpeed = 8f;
                    fallingSpeedMax = 12f;
                    raiseSpeed = 1f;
                    break;
                case 1:
                    jumpSpeed = 13f;
                    fallingSpeed = 11.5f;
                    fallingSpeedMax = 20f;
                    raiseSpeed = 2.0f;
                    break;
                case 2:
                    jumpSpeed = 12.5f;
                    fallingSpeed = 20f;
                    fallingSpeedMax = 30f;
                    raiseSpeed = 3.2f;
                    break;

            }

        }

    }
}