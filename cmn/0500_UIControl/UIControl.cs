using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// UI Control
//    * splite managerの起動
//
public class UIControl : MonoBehaviour {

    public static UIControl V;
    public string           m_firstMenuName;
    public GameObject       m_firstMenu;


    #region START KICK
    void Start()
    {
        V = this;
    }
    Action m_cb;
    public void Kick(Action cb)
    {
        if (!string.IsNullOrEmpty(m_firstMenuName))
        {
            m_firstMenu = GameObject.Find(m_firstMenuName);
        }

        m_cb = cb;
        StartCoroutine(kick_co());
    }

    IEnumerator kick_co() {

        Debug.Log("..Start !");
        var bOk = false;
        UISpriteManager.V.Kick(()=>bOk = true);
        while(bOk==false) yield return null;

        UIEventMachineInterface p = null;
        if (m_firstMenu!=null) {
            foreach(var c in  m_firstMenu.GetComponents<MonoBehaviour>())
            {
                var cand = c as UIEventMachineInterface;
                if (cand!=null)
                {
                    p = cand;
                    break;
                }
            }

            if (p!=null)
            {
                while(!p.IsReady()) yield return null;
                p.SetTarget_TemplateAndStart();
            }
        }

        if (m_cb!=null) m_cb();
        UnityEngine.Debug.Log("..END !!");
	}
    #endregion

    public void Hide(string name=null)
    {
        var target = m_firstMenu;
        if (!string.IsNullOrEmpty(name))
        {
            target = GameObject.Find(name);
        }
        if (target != null)
        {
            target.SetActive(false);
        }
    }
    public void Show(string name=null)
    {
        var target = m_firstMenu;
        if (!string.IsNullOrEmpty(name))
        {
            target = GameObject.Find(name);
        }
        if (target != null)
        {
            target.SetActive(true);
        }
    }
}
