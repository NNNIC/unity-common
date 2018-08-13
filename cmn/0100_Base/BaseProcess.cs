using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProcess : MonoBehaviour {

    public static BaseProcess V;

    [HideInInspector]
    public ProcessState m_state = ProcessState.UNKNOWN;

    public void Kick()
    {
        m_state = ProcessState.KICKING;
    }

    IEnumerator Start()
    {
        V = this;
        m_state = ProcessState.WAIT_KICK;

        yield return null; // 全ComponentのStart完了

        while(m_state == ProcessState.WAIT_KICK) yield return null;

        // ErrorDlg
        ErrorDlg.V.Kick();

        while(ErrorDlg.V.m_state != ProcessState.RUNNING) yield return null;

        //
        m_state = ProcessState.RUNNING;
    }

}
