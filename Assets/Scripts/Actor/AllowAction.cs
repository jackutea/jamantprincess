using System;

namespace Jam {

    public static class AllowAction {

        public const int allowMove = 1;
        public const int allowJump = 2;
        public const int allowFalling = 4;
        public const int allowFallingWithoutRaise = 8;
        public const int allowGroundCheck = 16;
        public const int allowChangeBody = 32;

    }

}