using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseProcess : MonoBehaviour {

    public static BaseProcess V;

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

    IEnumerator kick_co()
    {
        var bOk = false;
        // ErrorDlg
        ErrorDlg.V.Kick(()=>bOk=true);

        while(bOk==false) yield return null;

        //
        if (m_cb!=null) m_cb();
    }

}
