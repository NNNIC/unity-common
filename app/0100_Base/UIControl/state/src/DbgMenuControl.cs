using System;
using System.Collections.Generic;
using UnityEngine;
public partial class DbgMenuControl  {

    public class Item
    {
        public string NAME;
        public float  X = 0;
        public float  Y = 0;
        public float  W = 200;
        public float  H = 40; 

        public Item(string iname, float y)
        {
            NAME = iname;
            Y = y;
        }
    }

    List<Item> m_items;
    int        m_index;
    Item       IT { get { return m_items[m_index]; } }

    void dbgmenu_setup()
    {
        var sh = 50f;
        m_items = new List<Item>();
        
        m_items.Add( new Item("but 01", -sh * m_items.Count));
        m_items.Add( new Item("but 02", -sh * m_items.Count));
        m_items.Add( new Item("but 03", -sh * m_items.Count));
        m_items.Add( new Item("but 04", -sh * m_items.Count));
        m_items.Add( new Item("but 05", -sh * m_items.Count));
        m_items.Add( new Item("but 06", -sh * m_items.Count));
        m_items.Add( new Item("but 07", -sh * m_items.Count));
        m_items.Add( new Item("but 08", -sh * m_items.Count));
        m_items.Add( new Item("but 09", -sh * m_items.Count));
        m_items.Add( new Item("but 10", -sh * m_items.Count));
        m_items.Add( new Item("but 11", -sh * m_items.Count));
        m_items.Add( new Item("but 12", -sh * m_items.Count));
        m_items.Add( new Item("but 13", -sh * m_items.Count));
        m_items.Add( new Item("but 14", -sh * m_items.Count));
        m_items.Add( new Item("but 15", -sh * m_items.Count));
        m_items.Add( new Item("but 16", -sh * m_items.Count));
        m_items.Add( new Item("but 17", -sh * m_items.Count));
        m_items.Add( new Item("but 18", -sh * m_items.Count));
        m_items.Add( new Item("but 19", -sh * m_items.Count));

        m_index = 0;

        var rt = m_parent.GetComponent<RectTransform>();
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, (m_items.Count+1) * sh);

    }
    void next_loop()
    {
        m_index++;
        m_yesno = m_index < m_items.Count;
    }
}
