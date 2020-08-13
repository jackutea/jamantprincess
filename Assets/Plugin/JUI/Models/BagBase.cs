using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JackUtil {

    [Serializable]
    public abstract class BagBase {

        public virtual ItemBase this[int _index] {
            get => itemArray[_index];
        }
        public abstract ItemBase[] itemArray { get; }
        public abstract void SetMaxSlot(int _maxSlot);
        public abstract bool HasEmptySlot(out int _emptyIndex);
        public abstract int GetAllowInsertNumber(ItemBase _item);
        public abstract int GetSameItemNumber(ItemBase _item);
        public abstract int InsertItem(ItemBase _item);
        public abstract void SwitchItemSlot(int _currentIndex, int _targetIndex);

    }
}