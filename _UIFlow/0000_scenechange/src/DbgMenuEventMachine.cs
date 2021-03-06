﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DbgMenuEventMachine : MonoBehaviour, UIEventMachineInterface {

    EventMachine                 m_em;
    DbgMenuControl               m_sm { get { return (DbgMenuControl)m_em.m_sm; } }

    public Canvas m_target;
    public Canvas m_template;   

    public bool IsReady()  { return m_bReady; }
    private bool m_bReady=false;

	void Start () {
		m_em = new EventMachine(typeof(DbgMenuControl));
        m_bReady = true;
	}
	
	void Update () {
		if (m_em!=null) m_em.Update();
	}

    public void SetTarget_TemplateAndStart()
    {
        m_sm.SetTargetAndTemplate(m_target, m_template);
        m_sm.Start();
    }

    public bool IsEnd()
    {
        return (bool)m_sm.IsEnd();
    }
}
