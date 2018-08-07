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

    #region process
    [HideInInspector]
    public ProcessState m_state = ProcessState.UNKNOWN;    
    public void Kick()
    {
        m_state = ProcessState.KICKING;
    }
    #endregion

    IEnumerator Start () {
        V = this;
        m_state = ProcessState.WAIT_KICK;

        yield return null; // 全ComponentのStart完了

        while(m_state == ProcessState.WAIT_KICK) yield return null;
        
        Debug.Log("..Start !");

        UISpriteManager.V.Kick();
        while(UISpriteManager.V.m_state != ProcessState.RUNNING) yield return null;

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

        m_state = ProcessState.RUNNING;

        UnityEngine.Debug.Log("..END !!");
	}
	
}
