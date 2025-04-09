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

        List<Item> items1 = new List<Item>();
        items1.Add(new Item(ColorType.Red));
        items1.Add(new Item(ColorType.Red));
        items1.Add(new Item(ColorType.Green));
        items1.Add(new Item(ColorType.Purple));
        Tray tray1 = new Tray(items1, new Vector2Int(0, 1));
        tray1.OnDependencyInject(this);
        _trays[0, 1] = tray1;

        List<Item> items2 = new List<Item>();
        items2.Add(new Item(ColorType.Green));
        items2.Add(new Item(ColorType.Purple));
        items2.Add(new Item(ColorType.Yellow));
        items2.Add(new Item(ColorType.Yellow));
        Tray tray2 = new Tray(items2, new Vector2Int(1, 0));
        tray2.OnDependencyInject(this);
        _trays[1, 0] = tray2;

        List<Item> items3 = new List<Item>();
        items3.Add(new Item(ColorType.Green));
        items3.Add(new Item(ColorType.Green));
        items3.Add(new Item(ColorType.Green));
        Tray tray3 = new Tray(items3, new Vector2Int(1, 2));
        tray3.OnDependencyInject(this);
        _trays[1, 2] = tray3;

        List<Item> items4 = new List<Item>();
        items4.Add(new Item(ColorType.Blue));
        items4.Add(new Item(ColorType.Blue));
        items4.Add(new Item(ColorType.Blue));
        items4.Add(new Item(ColorType.Purple));
        items4.Add(new Item(ColorType.Purple));
        items4.Add(new Item(ColorType.Purple));
        Tray tray4 = new Tray(items4, new Vector2Int(2, 0));
        tray4.OnDependencyInject(this);
        _trays[2, 0] = tray4;

        List<Item> items5 = new List<Item>();
        items5.Add(new Item(ColorType.Green));
        items5.Add(new Item(ColorType.Green));
        items5.Add(new Item(ColorType.Green));
        items5.Add(new Item(ColorType.Purple));
        items5.Add(new Item(ColorType.Purple));
        items5.Add(new Item(ColorType.Purple));
        Tray tray5 = new Tray(items5, new Vector2Int(2, 1));
        tray5.OnDependencyInject(this);
        _trays[2, 1] = tray5;

        List<Item> items6 = new List<Item>();
        items6.Add(new Item(ColorType.Green));
        items6.Add(new Item(ColorType.Green));
        items6.Add(new Item(ColorType.Green));
        items6.Add(new Item(ColorType.Purple));
        items6.Add(new Item(ColorType.Purple));
        items6.Add(new Item(ColorType.Purple));
        Tray tray6 = new Tray(items6, new Vector2Int(2, 2));
        tray6.OnDependencyInject(this);
        _trays[2, 2] = tray6;

        List<Item> items7 = new List<Item>();
        items7.Add(new Item(ColorType.Red));
        items7.Add(new Item(ColorType.Red));
        items7.Add(new Item(ColorType.Red));
        Tray tray7 = new Tray(items7, new Vector2Int(3, 0));
        tray7.OnDependencyInject(this);
        _trays[3, 0] = tray7;

        List<Item> items8 = new List<Item>();
        items8.Add(new Item(ColorType.Yellow));
        items8.Add(new Item(ColorType.Yellow));
        items8.Add(new Item(ColorType.Yellow));
        items8.Add(new Item(ColorType.Green));
        items8.Add(new Item(ColorType.Green));
        items8.Add(new Item(ColorType.Green));
        Tray tray8 = new Tray(items8, new Vector2Int(3, 1));
        tray8.OnDependencyInject(this);
        _trays[3, 1] = tray8;

        List<Item> items9 = new List<Item>();
        items9.Add(new Item(ColorType.Blue));
        items9.Add(new Item(ColorType.Blue));
        items9.Add(new Item(ColorType.Blue));
        items9.Add(new Item(ColorType.Yellow));
        items9.Add(new Item(ColorType.Yellow));
        items9.Add(new Item(ColorType.Yellow));
        Tray tray9 = new Tray(items9, new Vector2Int(3, 2));
        tray9.OnDependencyInject(this);
        _trays[3, 2] = tray9;

        List<Item> items10 = new List<Item>();
        items10.Add(new Item(ColorType.Blue));
        items10.Add(new Item(ColorType.Blue));
        items10.Add(new Item(ColorType.Blue));
        items10.Add(new Item(ColorType.Yellow));
        items10.Add(new Item(ColorType.Yellow));
        items10.Add(new Item(ColorType.Yellow));
        Tray tray10 = new Tray(items10, new Vector2Int(4, 1));
        tray10.OnDependencyInject(this);
        _trays[4, 1] = tray10;

        List<Item> items11 = new List<Item>();
        items11.Add(new Item(ColorType.Red));
        items11.Add(new Item(ColorType.Yellow));
        items11.Add(new Item(ColorType.Green));
        Tray tray11 = new Tray(items11);

        PutTray(tray11, new Vector2Int(1, 1));
    }

    public Tray GetTray(Vector2Int pos)
    {
        return _trays[pos.y, pos.x];
    }

    private void PutTray(Tray tray, Vector2Int pos)
    {
        tray.OnDependencyInject(this);
        tray.SetPos(pos);
        _trays[pos.y, pos.x] = tray;
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

            if (VisitAroundTraysByItem(tray, items[i]))
            {
                for (int j = i; j < count; j++)
                {
                    if (items[j].Color == items[i].Color)
                    {
                        items[j].SetId(_index);
                    }
                }
                
                _dictItemOrder[_index] += 1;
                _index++;
            }
        }
    }

    private bool VisitAroundTraysByItem(Tray tray, Item item)
    {
        bool isValid = tray.GetTrayUp().TrySetIdByColor(item.Color, _index) ||
                       tray.GetTrayDown().TrySetIdByColor(item.Color, _index) ||
                       tray.GetTrayLeft().TrySetIdByColor(item.Color, _index) ||
                       tray.GetTrayRight().TrySetIdByColor(item.Color, _index);
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