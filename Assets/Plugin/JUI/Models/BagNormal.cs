using System;
using System.Collections.Generic;

namespace JackUtil {

    [Serializable]
    public class BagNormal : BagBase {

        ItemBase[] m_itemArray;
        public override ItemBase[] itemArray { get => m_itemArray; }

        public override void SetMaxSlot(int _maxSlot) {

            m_itemArray = new ItemBase[_maxSlot];

        }

        // 完全插入
        public override int InsertItem(ItemBase _item) {

            int _inserted = 0;

            // 先插入相同的
            foreach (ItemBase _itemInBag in itemArray) {

                if (_itemInBag == null) continue;

                if (_itemInBag.GetItemEnum == _item.GetItemEnum) {

                    if (_itemInBag.num + _item.num > _itemInBag.maxSlot) {

                        int _off = _itemInBag.maxSlot - _itemInBag.num;
                        _item.num -= _off;
                        _itemInBag.num += _off;
                        _inserted += _off;

                    } else {

                        _itemInBag.num += _item.num;
                        _inserted += _item.num;
                        _item.num = 0;

                    }

                }
                
            }

            if (_item.num > 0) {

                // 有剩则插入空位(如果有空位)
                int _emptyIndex;
                if (HasEmptySlot(out _emptyIndex)) {

                    itemArray[_emptyIndex] = _item;
                    _inserted += _item.num;

                } else {

                    // 装不下了

                }

            }

            return _inserted;

        }

        // 判断是否有空位
        public override bool HasEmptySlot(out int _emptyIndex) {
            return itemArray.TryGetEmptySlotIndex(out _emptyIndex);
        }

        // 判断同类物品允许插入的总数量
        public override int GetAllowInsertNumber(ItemBase _item) {

            int _num = 0;

            foreach (ItemBase _itemInBag in itemArray) {

                if (_itemInBag == null) {

                    _num += _item.maxSlot;

                } else {

                    if (_itemInBag.GetItemEnum == _item.GetItemEnum) {

                        _num += _itemInBag.maxSlot - _itemInBag.num;

                    }

                }
            }

            return _num;

        }

        // 同类物品总数
        public override int GetSameItemNumber(ItemBase _item) {

            int _num = 0;

            foreach (ItemBase _itemInBag in itemArray) {

                if (_itemInBag == null) continue;

                if (_itemInBag.GetItemEnum == _item.GetItemEnum) {

                    _num += _itemInBag.num;

                }
            }

            return _num;

        }

        // 插入物品


        // 交换位置
        public override void SwitchItemSlot(int _currentIndex, int _targetIndex) {

            ItemBase _current = itemArray[_currentIndex];
            ItemBase _target = itemArray[_targetIndex];

            if (_current.GetItemEnum == _target.GetItemEnum) {

                // 是同类 堆叠
                // 超上限 堆部分
                if (_target.num + _current.num > _target.maxSlot) {

                    int _off = _target.maxSlot - _target.num;
                    _current.num -= _off;
                    _target.num = _target.maxSlot;

                // 不超上限 全堆
                } else {

                    _target.num += _current.num;
                    _current.num = 0;
                    itemArray[_currentIndex] = null;

                }

            } else {

                // 非同类 调换位置
                itemArray[_currentIndex] = _target;
                itemArray[_targetIndex] = _current;

            }


        }
    }
}