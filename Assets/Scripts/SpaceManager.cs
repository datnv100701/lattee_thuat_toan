using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;

public class SpaceManager : MonoBehaviour
{
    private int _row = 5;
    private int _column = 3;
    private int _index = 0;
    private Tray[,] _trays;

    private Dictionary<int, int> _dictItemCountOrder = new Dictionary<int, int>();
    private Dictionary<int, HashSet<Tray>> _dictListTrayById = new Dictionary<int, HashSet<Tray>>();
    private Dictionary<int, List<Item>> _dictItemOrder = new Dictionary<int, List<Item>>();

    private void Awake()
    {
        _trays = new Tray[_row, _column];
        //do 1, xanh 2, tim 3, vang 4, blue 5;

        Tray tray1 = new Tray(new Vector2Int(0, 1));
        List<Item> items1 = new List<Item>();
        items1.Add(new Item(ColorType.Red, tray1));
        items1.Add(new Item(ColorType.Red, tray1));
        items1.Add(new Item(ColorType.Green, tray1));
        items1.Add(new Item(ColorType.Purple, tray1));
        tray1.AddItems(items1);
        tray1.OnDependencyInject(this);
        _trays[0, 1] = tray1;

        Tray tray2 = new Tray(new Vector2Int(1, 0));
        List<Item> items2 = new List<Item>();
        items2.Add(new Item(ColorType.Green, tray2));
        items2.Add(new Item(ColorType.Purple, tray2));
        items2.Add(new Item(ColorType.Yellow, tray2));
        items2.Add(new Item(ColorType.Yellow, tray2));
        tray2.AddItems(items2);
        tray2.OnDependencyInject(this);
        _trays[1, 0] = tray2;

        Tray tray3 = new Tray(new Vector2Int(1, 2));
        List<Item> items3 = new List<Item>();
        items3.Add(new Item(ColorType.Green, tray3));
        items3.Add(new Item(ColorType.Green, tray3));
        items3.Add(new Item(ColorType.Green, tray3));
        tray3.AddItems(items3);
        tray3.OnDependencyInject(this);
        _trays[1, 2] = tray3;

        Tray tray4 = new Tray(new Vector2Int(2, 0));
        List<Item> items4 = new List<Item>();
        items4.Add(new Item(ColorType.Blue, tray4));
        items4.Add(new Item(ColorType.Blue, tray4));
        items4.Add(new Item(ColorType.Blue, tray4));
        items4.Add(new Item(ColorType.Purple, tray4));
        items4.Add(new Item(ColorType.Purple, tray4));
        items4.Add(new Item(ColorType.Purple, tray4));
        tray4.AddItems(items4);
        tray4.OnDependencyInject(this);
        _trays[2, 0] = tray4;

        Tray tray5 = new Tray(new Vector2Int(2, 1));
        List<Item> items5 = new List<Item>();
        items5.Add(new Item(ColorType.Green, tray5));
        items5.Add(new Item(ColorType.Green, tray5));
        items5.Add(new Item(ColorType.Green, tray5));
        items5.Add(new Item(ColorType.Purple, tray5));
        items5.Add(new Item(ColorType.Purple, tray5));
        items5.Add(new Item(ColorType.Purple, tray5));
        tray5.AddItems(items5);
        tray5.OnDependencyInject(this);
        _trays[2, 1] = tray5;

        Tray tray6 = new Tray(new Vector2Int(2, 2));
        List<Item> items6 = new List<Item>();
        items6.Add(new Item(ColorType.Red, tray6));
        items6.Add(new Item(ColorType.Red, tray6));
        items6.Add(new Item(ColorType.Red, tray6));
        items6.Add(new Item(ColorType.Purple, tray6));
        items6.Add(new Item(ColorType.Purple, tray6));
        items6.Add(new Item(ColorType.Purple, tray6));
        tray6.AddItems(items6);
        tray6.OnDependencyInject(this);
        _trays[2, 2] = tray6;

        Tray tray7 = new Tray(new Vector2Int(3, 0));
        List<Item> items7 = new List<Item>();
        items7.Add(new Item(ColorType.Red, tray7));
        items7.Add(new Item(ColorType.Red, tray7));
        items7.Add(new Item(ColorType.Red, tray7));
        tray7.AddItems(items7);
        tray7.OnDependencyInject(this);
        _trays[3, 0] = tray7;

        Tray tray8 = new Tray(new Vector2Int(3, 1));
        List<Item> items8 = new List<Item>();
        items8.Add(new Item(ColorType.Yellow, tray8));
        items8.Add(new Item(ColorType.Yellow, tray8));
        items8.Add(new Item(ColorType.Yellow, tray8));
        items8.Add(new Item(ColorType.Green, tray8));
        items8.Add(new Item(ColorType.Green, tray8));
        items8.Add(new Item(ColorType.Green, tray8));
        tray8.AddItems(items8);
        tray8.OnDependencyInject(this);
        _trays[3, 1] = tray8;
        
        Tray tray9 = new Tray(new Vector2Int(3, 2));
        List<Item> items9 = new List<Item>();
        items9.Add(new Item(ColorType.Blue, tray9));
        items9.Add(new Item(ColorType.Blue, tray9));
        items9.Add(new Item(ColorType.Blue, tray9));
        items9.Add(new Item(ColorType.Yellow, tray9));
        items9.Add(new Item(ColorType.Yellow, tray9));
        items9.Add(new Item(ColorType.Yellow, tray9));
        tray9.AddItems(items9);
        tray9.OnDependencyInject(this);
        _trays[3, 2] = tray9;

        Tray tray10 = new Tray(new Vector2Int(4, 1));
        List<Item> items10 = new List<Item>();
        items10.Add(new Item(ColorType.Purple, tray10));
        items10.Add(new Item(ColorType.Purple, tray10));
        items10.Add(new Item(ColorType.Purple, tray10));
        items10.Add(new Item(ColorType.Green, tray10));
        items10.Add(new Item(ColorType.Green, tray10));
        items10.Add(new Item(ColorType.Green, tray10));
        tray10.AddItems(items10);
        tray10.OnDependencyInject(this);
        _trays[4, 1] = tray10;

        Tray tray11 = new Tray();
        List<Item> items11 = new List<Item>();
        items11.Add(new Item(ColorType.Red, tray11));
        items11.Add(new Item(ColorType.Yellow, tray11));
        items11.Add(new Item(ColorType.Green, tray11));
        tray11.AddItems(items11);

        PlaceTray(tray11, new Vector2Int(1, 1));
    }

    public Tray GetTray(Vector2Int pos)
    {
        return _trays[pos.x, pos.y];
    }

    private void PlaceTray(Tray tray, Vector2Int pos)
    {
        tray.OnDependencyInject(this);
        tray.SetPos(pos);
        _trays[pos.x, pos.y] = tray;

        VisitTrays(pos);
        Sort();

        // for (int i = 1; i <= _index; i++)
        // {
        //     if (_dictItemCountOrder.TryGetValue(i, out int value))
        //         Debug.Log(i + " " + value);
        // }
    }

    private void AddValueDictItemCountOrder(int index, int count)
    {
        if (_dictItemCountOrder.TryGetValue(index, out int value))
        {
            _dictItemCountOrder[index] = value + count;
        }
        else
        {
            _dictItemCountOrder[index] = count;
        }
    }

    private void AddValueDictTrayOrder(int index, Tray tray)
    {
        if (_dictListTrayById.TryGetValue(index, out HashSet<Tray> value))
        {
            _dictListTrayById[index].Add(tray);
        }
        else
        {
            _dictListTrayById[index] = new HashSet<Tray>();
            _dictListTrayById[index].Add(tray);
        }
    }

    private void AddValueDictItemOrder(int index, List<Item> items)
    {
        if (_dictItemOrder.TryGetValue(index, out List<Item> value))
        {
            _dictItemOrder[index].AddRange(items);
        }
        else
        {
            _dictItemOrder[index] = new List<Item>();
            _dictItemOrder[index].AddRange(items);
        }
    }

    private void AddValueDictItemOrder(int index, Item item)
    {
        if (_dictItemOrder.TryGetValue(index, out List<Item> value))
        {
            _dictItemOrder[index].Add(item);
        }
        else
        {
            _dictItemOrder[index] = new List<Item>();
            _dictItemOrder[index].Add(item);
        }
    }

    private void VisitTrays(Vector2Int pos)
    {
        Tray tray = GetTray(pos);
        List<Item> items = tray.GetItems();
        int count = items.Count;
        for (int i = 0; i < count; i++)
        {
            if (items[i].HasId())
                continue;

            _index++;
            int id = _index;
            if (VisitAroundTraysByColor(id, tray, items[i].Color, Swipe.All))
            {
                for (int j = i; j < count; j++)
                {
                    if (!items[j].HasId() && items[j].Color == items[i].Color)
                    {
                        items[j].SetId(id);
                        AddValueDictItemCountOrder(id, 1);
                        AddValueDictItemOrder(id, items[j]);
                        AddValueDictTrayOrder(id, tray);
                    }
                }
            }
            else
            {
                _index--;
            }
        }
    }

    private bool VisitAroundTraysByColor(int id, Tray tray, ColorType color, Swipe swipe)
    {
        bool isValid = false;

        if (swipe != Swipe.Down && tray.GetTrayUp() != null &&
            tray.GetTrayUp().TrySetIdByColor(color, id, out int amountUp, out List<Item> itemsUp))
        {
            AddValueDictItemCountOrder( id, amountUp);
            AddValueDictItemOrder(id, itemsUp);
            AddValueDictTrayOrder(id, tray.GetTrayUp());
            VisitAroundTraysByColor(id, tray.GetTrayUp(), color, Swipe.Up);
            VisitTrays(tray.GetTrayUp().GetPos());
            isValid = true;
        }

        if (swipe != Swipe.Up && tray.GetTrayDown() != null && tray.GetTrayDown()
                .TrySetIdByColor(color, id, out int amountDown, out List<Item> itemsDown))
        {
            AddValueDictItemCountOrder(id, amountDown);
            AddValueDictItemOrder(id, itemsDown);
            AddValueDictTrayOrder(id, tray.GetTrayDown());
            VisitAroundTraysByColor(id, tray.GetTrayDown(), color, Swipe.Down);
            VisitTrays(tray.GetTrayDown().GetPos());
            isValid = true;
        }

        if (swipe != Swipe.Right && tray.GetTrayLeft() != null && tray.GetTrayLeft()
                .TrySetIdByColor(color, id, out int amountLeft, out List<Item> itemsLeft))
        {
            AddValueDictItemCountOrder(id, amountLeft);
            AddValueDictItemOrder(id, itemsLeft);
            AddValueDictTrayOrder(id, tray.GetTrayLeft());
            VisitAroundTraysByColor(id, tray.GetTrayLeft(), color, Swipe.Left);
            VisitTrays(tray.GetTrayLeft().GetPos());
            isValid = true;
        }

        if (swipe != Swipe.Left && tray.GetTrayRight() != null && tray.GetTrayRight()
                .TrySetIdByColor(color, id, out int amountRight, out List<Item> itemsRight))
        {
            AddValueDictItemCountOrder(id, amountRight);
            AddValueDictItemOrder(id, itemsRight);
            AddValueDictTrayOrder(id, tray.GetTrayRight());
            VisitAroundTraysByColor(id, tray.GetTrayRight(), color, Swipe.Right);
            VisitTrays(tray.GetTrayRight().GetPos());
            isValid = true;
        }

        return isValid;
    }

    private void Sort()
    {
        ComputeAllTraysPriority();
        int numOfSort = ComputeNumOfSort();

        for (int i = 0; i < numOfSort; i++)
        {
            int id = GetIdMaxCount();
            List<Tray> trays = GetAndSortListTraysById(id);
            for (int j = 0; j < trays.Count; j++)
            {
                if (CheckTrayCanCollapseItems(id, trays[j]))
                {
                    // MoveItems();
                    _dictItemCountOrder[id] = Mathf.Max(0, _dictItemCountOrder[id] - 6);
                    j = trays.Count;
                }
            }
        }
    }

    private List<Tray> GetAndSortListTraysById(int id)
    {
        List<Tray> trays = new List<Tray>();
        trays.AddRange(_dictListTrayById[id]);
        trays.Sort((a, b) => b.CountEmptySlot().CompareTo(a.CountEmptySlot()));
        
        return trays;
    }

    private bool CheckTrayCanCollapseItems(int id, Tray tray)
    {
        int count = tray.CountItem();
        for (int i = 0; i < count; i++)
        {
            List<int> listIdChecked = new List<int>();
            if (_dictItemCountOrder[id] >= 6)
            {
                int swapId = tray.GetItem(i).GetId();
                if (tray.GetItem(i).GetId() == id)
                    continue;
                if (listIdChecked.IndexOf(swapId) != -1)
                    continue;
                int totalSlotCanSwap = 0;
                foreach (var t in _dictListTrayById[swapId])
                {
                    totalSlotCanSwap += t.GetSlotCanSwap(id);
                }

                if (tray.CountItemById(swapId) > totalSlotCanSwap)
                    return false;

                listIdChecked.Add(swapId);
            }
            else
            {
                
            }
        }

        return true;
    }

    private void MoveItems(int id, Tray tray)
    {
        int count = 0;
        List<Item> items = tray.GetItems();
        List<Item> itemsCollapse = new List<Item>();
        for (int i = 0; i < tray.CountItem(); i++)
        {
            if (items[i].GetId() != id)
            {
                HashSet<Tray> trays = _dictListTrayById[items[i].GetId()];
                foreach (var t in trays)
                {
                    for (int k = 0; k < t.CountItem(); k++)
                    {
                        if (t.GetItem(k).GetId() == id)
                        {
                            itemsCollapse.Add(t.GetItem(k));
                            t.RemoveAt(k);
                            t.Insert(k, items[i]);
                            count++;
                        }
                    }
                }
            }
            else
            {
                count++;
            }
        }
    }

    private void ComputeAllTraysPriority()
    {
        for (int i = 0; i < _row; i++)
        {
            for (int j = 0; j < _column; j++)
            {
                if (_trays[i, j] == null)
                    continue;
                _trays[i, j].ComputePriority();
            }
        }
    }

    private int ComputeNumOfSort()
    {
        int num = 0;
        foreach (var item in _dictItemCountOrder)
        {
            num += item.Value / 6 + 1;
        }

        return num;
    }

    private int GetIdMaxCount()
    {
        int id = _dictItemCountOrder.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
        return id;
    }

    public bool IsValidPos(Vector2Int pos)
    {
        if (pos.x >= _row || pos.x < 0)
            return false;
        if (pos.y >= _column || pos.y < 0)
            return false;
        return true;
    }

    public int GetCountItemById(int id)
    {
        return _dictItemCountOrder.GetValueOrDefault(id, 0);
    }
}

public enum ColorType
{
    Green,
    Red,
    Yellow,
    Blue,
    Purple
}

public enum Swipe
{
    All,
    Up,
    Down,
    Left,
    Right
}