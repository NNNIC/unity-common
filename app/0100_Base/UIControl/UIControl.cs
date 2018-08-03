using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour {

    [HideInInspector]
    public UIControlWorkCompo[] m_tcs;

    public static UIControl V;

    #region process
    [HideInInspector]
    public ProcessState m_state = ProcessState.UNKNOWN;    
    public void ReqStart()
    {
        m_state = ProcessState.STARTING;
    }
    #endregion

    // Use this for initialization
    IEnumerator Start () {
        V = this;
        m_state = ProcessState.WAIT_START;

        yield return null; // 全ComponentのStart完了

        while(m_state == ProcessState.WAIT_START) yield return null;

        
        Debug.Log("..Start !");

        UISpriteManager.V.ReqStart();
        while(UISpriteManager.V.m_state != ProcessState.RUNNING) yield return null;

        m_tcs = GetComponents<UIControlWorkCompo>();
        foreach(var tc in m_tcs)
        { 
            if (tc.enabled)
            { 
                tc.SetTarget_TemplateAndStart();
            }
        }
        m_state = ProcessState.RUNNING;

        while(true)
        {
            var b =Array.TrueForAll(m_tcs,tc=> {
                return tc.enabled==false || tc.IsEnd();
            });
            if (b) break;

            yield return null;
        }

        UnityEngine.Debug.Log("..END !!");
	}
	
}
