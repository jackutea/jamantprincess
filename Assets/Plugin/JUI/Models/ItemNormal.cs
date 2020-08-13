using System;
using System.Collections.Generic;

namespace JackUtil {

    [Serializable]
    public class ItemNormal : ItemBase {

        public ItemNormal() {

            m_itemEnum = ItemEnum.None;
            m_num = 1;
            m_maxSlot = 100;

        }

        public static ItemBase CreateItem(ItemEnum _enum, int _maxSlot, int _num) {
            ItemNormal _item = new ItemNormal();
            _item.m_itemEnum = _enum;
            _item.m_num = _num;
            _item.m_maxSlot = _maxSlot;
            return _item;
        }

        public ItemEnum m_itemEnum;
        public override ItemEnum GetItemEnum {
            get => m_itemEnum;
        }

        public int m_num;
        public override int num {
            get => m_num;
            set => m_num = value;
        }

        public int m_maxSlot;
        public override int maxSlot { get => m_maxSlot; }
    }
}