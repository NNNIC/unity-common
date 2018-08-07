using System;
using System.Collections.Generic;
using UnityEngine;
public partial class DbgMenuControl  {

    public static DbgMenuControl V;

    //const string ID = "DBGMENU::";

    public class Item
    {
        public string NAME;
        public string TEXT;
        public float  X = 0;
        public float  Y = 0;
        public float  W = 200;
        public float  H = 40; 
        public Action CB;

        public Item(string iname, float y, Action cb=null)
        {
            NAME = iname;
            TEXT = iname;
            Y    = y;
            CB   = cb;
        }
    }

    List<Item> m_items;
    int        m_index;
    Item       IT { get { return m_index < m_items.Count ? m_items[m_index] : null; } }


    void dbgmenu_setup()
    {
        V = this;
        var sh = 50f;
        m_items = new List<Item>();

        DbgMenuList.RegistDbgMenu((name,cb)=> {
            m_items.Add( new Item( name , -sh * m_items.Count, cb));
        });

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