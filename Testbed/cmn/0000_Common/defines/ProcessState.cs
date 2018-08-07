using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProcessState {
    UNKNOWN,
    WAIT_KICK, // ※STARTの意味。 UnityのStart()と混同を避けるため
    KICKING,
    RUNNING,
    OUT_OF_DATE
}
/*
    プロセスの状態 Process State

    UNKONW     --- 初期状態 
    WAIT_KICK  --- 開始待ち
    KICKING    --  開始中
    RUNNING    --  実行中

    プロセスの

    ProcessState m_state = ProcessState.UNKNOWN

    void Start() //または IEnumrator
    {
         :
        m_state = ProcessState.WAIT_KICK
    }

    void Kick()
    {
        m_state = ProcessState.KICKING
        :
        m_state = ProcessState.RUNNING
    }
*/