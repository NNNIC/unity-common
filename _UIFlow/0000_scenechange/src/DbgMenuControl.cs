using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        Action<string, Action> regst = (name,cb) => {
            m_items.Add( new Item( name , -sh * m_items.Count, cb));
        }; 

        //regst("Scene 0", ()=> {
        //    SceneManager.LoadScene(0);
        //});
        regst("Scene 1", ()=> {
            SceneManager.LoadScene(1);
        });
        regst("Scene 2", ()=> {
            SceneManager.LoadScene(2);
        });
        regst("Scene 3", ()=> {
            SceneManager.LoadScene(3);
        });
        regst("Scene 4", ()=> {
            SceneManager.LoadScene(4);
        });
        regst("Scene 5", ()=> {
            SceneManager.LoadScene(5);
        });
        regst("FADE", ()=> {            
            if (Fade.Alpha()==1)
            {
                Fade.FadeIn();
            }
            else
            {
                Fade.FadeOut();
            }
        });

        regst("HIDE MENU", ()=> {
            UIControl.V.Hide();
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