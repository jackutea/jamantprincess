using System;
using System.Collections.Generic;

namespace JackUtil {

    [Serializable]
    public abstract class ItemBase {

        public abstract ItemEnum GetItemEnum { get; }
        public abstract int num { get; set; }
        public abstract int maxSlot { get; }

    }
}