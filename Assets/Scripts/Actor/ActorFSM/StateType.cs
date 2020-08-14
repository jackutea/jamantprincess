using System;

namespace Jam {

    public enum StateType {

        Idle,

    }

    public static class StateTypeExtention {

        public static int ToInt(this StateType _enum) {
            return (int)_enum;
        }

    }
}