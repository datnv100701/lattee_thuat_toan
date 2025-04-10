using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class Tray
    {
        private readonly List<Item> _items = new List<Item>();
        private Vector2Int _currentPos;
        private SpaceManager _spaceManager;

        private readonly Vector2Int _up = new Vector2Int(0, 1);
        private readonly Vector2Int _down = new Vector2Int(0, -1);
        private readonly Vector2Int _left = new Vector2Int(-1, 0);
        private readonly Vector2Int _right = new Vector2Int(1, 0);

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

        public List<Item> GetItems()
        {
            return _items;
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

        public bool TrySetIdByColor(ColorType color, int id, out int amount)
        {
            bool isValid = false;
            int count = _items.Count;
            amount = 0;
            for (int i = 0; i < count; i++)
            {
                if (_items[i].Color != color)
                    continue;

                if (_items[i].HasId())
                    return false;
                
                amount++;
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

        public int CountEmptySlot()
        {
            return 6 - _items.Count;
        }

        public void SetPos(Vector2Int pos)
        {
            _currentPos = pos;
        }
    }
}