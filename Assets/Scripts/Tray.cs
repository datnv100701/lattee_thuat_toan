﻿using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class Tray
    {
        private readonly List<Item> _items = new List<Item>();
        private Vector2Int _currentPos;
        private SpaceManager _spaceManager;

        private readonly Vector2Int _up = new Vector2Int(-1, 0);
        private readonly Vector2Int _down = new Vector2Int(1, 0);
        private readonly Vector2Int _left = new Vector2Int(0, -1);
        private readonly Vector2Int _right = new Vector2Int(0, 1);

        private int _priority;

        public Tray()
        {
            _items = new List<Item>();
        }

        public Tray(List<Item> items)
        {
            _items = items;
        }

        public Tray(List<Item> items, Vector2Int currentPos)
        {
            _items = items;
            _currentPos = currentPos;
        }

        public Tray(Vector2Int currentPos)
        {
            _currentPos = currentPos;
        }

        public void AddItems(List<Item> items)
        {
            _items.AddRange(items);
        }

        public void OnDependencyInject(SpaceManager spaceManager)
        {
            _spaceManager = spaceManager;
        }

        public Item GetItem(int index)
        {
            return _items[index];
        }

        public List<Item> GetItems()
        {
            return _items;
        }

        public int CountItem()
        {
            return _items.Count;
        }

        public int CountItemById(int id)
        {
            int total = 0;
            for (int i = 0; i < _items.Count; i++)
            {
                if (!_items[i].HasId() || _items[i].GetId() != id)
                    continue;
                total++;
            }

            return total;
        }

        public int GetSlotCanSwap(int id)
        {
            int total = 0;
            int count = _items.Count;
            for (int i = 0; i < count; i++)
            {
                if (_items[i].GetId() == id)
                {
                    total++;
                }
            }

            total += 6 - total;
            return total;
        }

        public Tray GetTrayUp()
        {
            return GetTrayByDirection(_up);
        }

        public Tray GetTrayDown()
        {
            return GetTrayByDirection(_down);
        }

        public Tray GetTrayRight()
        {
            return GetTrayByDirection(_right);
        }

        public Tray GetTrayLeft()
        {
            return GetTrayByDirection(_left);
        }

        public bool TrySetIdByColor(ColorType color, int id, out int amount, out List<Item> items)
        {
            bool isValid = false;
            int count = _items.Count;
            amount = 0;
            items = new List<Item>();
            for (int i = 0; i < count; i++)
            {
                if (_items[i].Color != color)
                    continue;

                if (_items[i].HasId())
                    return false;

                amount++;
                items.Add(_items[i]);
                isValid = true;
                _items[i].SetId(id);
            }

            return isValid;
        }

        private Tray GetTrayByDirection(Vector2Int dir)
        {
            if (!_spaceManager.IsValidPos(_currentPos + dir))
                return null;
            return _spaceManager.GetTray(_currentPos + dir);
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public void RemoveItemById(int id, int count)
        {
        }

        public void RemoveItem(Item item)
        {
            _items.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _items.RemoveAt(index);
        }

        public void Insert(int index, Item item)
        {
            _items.Insert(index, item);
        }

        public int CountEmptySlot()
        {
            return 6 - _items.Count;
        }

        public Vector2Int GetPos() => _currentPos;

        public void SetPos(Vector2Int pos)
        {
            _currentPos = pos;
        }

        public int CountPositionCanPlace()
        {
            int countItemNotSetId = 0;
            int length = _items.Count;
            for (int i = 0; i < length; i++)
            {
                if (_items[i].HasId())
                    continue;
                countItemNotSetId++;
            }

            return 6 - countItemNotSetId;
        }

        public void ComputePriority()
        {
            List<int> listIdIterated = new List<int>();
            _priority = 0;
            int length = _items.Count;
            for (int i = 0; i < length; i++)
            {
                if (!_items[i].HasId())
                    continue;
                if (listIdIterated.IndexOf(_items[i].GetId()) != -1)
                    continue;
                _priority += _spaceManager.GetCountItemById(_items[i].GetId());
                listIdIterated.Add(_items[i].GetId());
            }
        }

        public int GetPriority()
        {
            return _priority;
        }
    }
}