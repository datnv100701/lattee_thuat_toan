﻿namespace DefaultNamespace
{
    public class Item
    {
        private int _id;
        public ColorType Color { get; private set; }
        public Tray TrayHolder { get; set; }
        
        public Tray TrayHolderTemp { get; set; }

        public Item(ColorType color)
        {
            Color = color;
            _id = -1;
        }

        public Item(ColorType color, Tray trayHolder)
        {
            Color = color;
            _id = -1;
            TrayHolder = trayHolder;
        }

        public bool HasId()
        {
            if (_id == -1)
                return false;
            return true;
        }

        public void ResetId()
        {
            _id = -1;
        }

        public int GetId()
        {
            return _id;
        }

        public void SetId(int id)
        {
            _id = id;
        }
    }
}