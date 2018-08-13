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

    void Start()
    {
        V = this;
    }

    Action m_cb;
    public void Kick(Action cb)
    {
        m_cb = cb;
        StartCoroutine(kick_co());
    }

    IEnumerator kick_co() {

        Debug.Log("..Start !");
        var bOk = false;
        UISpriteManager.V.Kick(()=>bOk = true);
        while(bOk==false) yield return null;

        UIEventMachineInterface p = null;
        foreach(var c in  GetComponents<MonoBehaviour>())
        {
            var cand = c as UIEventMachineInterface;
            if (cand!=null)
            {
                p = cand;
                break;
            }
        }

        p.SetTarget_TemplateAndStart();

        if (m_cb!=null) m_cb();
        UnityEngine.Debug.Log("..END !!");
	}
	
}
