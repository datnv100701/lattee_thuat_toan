using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;

public class SpaceManager : MonoBehaviour
{
    private int _width = 3;
    private int _height = 5;
    private int _index = 0;
    private Tray[,] _trays;

    private Dictionary<int, int> _dictItemOrder = new Dictionary<int, int>();
    private Dictionary<int, List<Tray>> _dictListTrayById = new Dictionary<int, List<Tray>>();

    private void Awake()
    {
        _trays = new Tray[_height, _width];
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
        items6.Add(new Item(ColorType.Green, tray6));
        items6.Add(new Item(ColorType.Green, tray6));
        items6.Add(new Item(ColorType.Green, tray6));
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
        items10.Add(new Item(ColorType.Blue, tray10));
        items10.Add(new Item(ColorType.Blue, tray10));
        items10.Add(new Item(ColorType.Blue, tray10));
        items10.Add(new Item(ColorType.Yellow, tray10));
        items10.Add(new Item(ColorType.Yellow, tray10));
        items10.Add(new Item(ColorType.Yellow, tray10));
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
        return _trays[pos.y, pos.x];
    }

    private void PlaceTray(Tray tray, Vector2Int pos)
    {
        tray.OnDependencyInject(this);
        tray.SetPos(pos);
        _trays[pos.y, pos.x] = tray;

        VisitTrays(pos);
    }

    private void AddValueDictItemOrder(int index, int count)
    {
        if (_dictItemOrder.TryGetValue(_index, out int value))
        {
            _dictItemOrder[_index] = value + count;
        }
        else
        {
            _dictItemOrder[_index] = count;
        }
    }

    private void VisitTrays(Vector2Int start)
    {
        Tray tray = GetTray(start);
        List<Item> items = tray.GetItems();
        int count = items.Count;
        for (int i = 0; i < count; i++)
        {
            if (items[i].HasId())
                continue;

            if (VisitAroundTraysByColor(tray, items[i].Color, Swipe.All))
            {
                for (int j = i; j < count; j++)
                {
                    if (items[j].Color == items[i].Color)
                    {
                        items[j].SetId(_index);
                    }
                }

                AddValueDictItemOrder(_index, 1);

                _index++;
            }
        }
    }

    private bool VisitAroundTraysByColor(Tray tray, ColorType color, Swipe swipe)
    {
        bool isValid = false;

        if (swipe != Swipe.Up && tray.GetTrayUp().TrySetIdByColor(color, _index, out int amountUp))
        {
            AddValueDictItemOrder(_index, amountUp);
            VisitAroundTraysByColor(tray.GetTrayUp(), color, Swipe.Up);
            isValid = true;
        }

        if (swipe != Swipe.Down && tray.GetTrayDown().TrySetIdByColor(color, _index, out int amountDown))
        {
            AddValueDictItemOrder(_index, amountDown);
            VisitAroundTraysByColor(tray.GetTrayDown(), color, Swipe.Down);
            isValid = true;
        }
        
        if (swipe != Swipe.Left && tray.GetTrayLeft().TrySetIdByColor(color, _index, out int amountLeft))
        {
            AddValueDictItemOrder(_index, amountLeft);
            VisitAroundTraysByColor(tray.GetTrayLeft(), color, Swipe.Left);
            isValid = true;
        }
        
        if (swipe != Swipe.Right && tray.GetTrayRight().TrySetIdByColor(color, _index, out int amountRight))
        {
            AddValueDictItemOrder(_index, amountRight);
            VisitAroundTraysByColor(tray.GetTrayRight(), color, Swipe.Right);
            isValid = true;
        }
        
        return isValid;
    }

    public bool IsValidPos(Vector2Int pos)
    {
        if (pos.x >= _width || pos.x < 0)
            return false;
        if (pos.y >= _height || pos.y < 0)
            return false;
        return true;
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