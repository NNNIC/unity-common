﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITest01EventMachine : MonoBehaviour {

    EventMachine<UITest01Control> m_em;
    UITest01Control               m_sm { get { return (UITest01Control)m_em.m_sm; } }

    public Canvas m_target;
    public Canvas m_template;

	void Start () {
		m_em = new EventMachine<UITest01Control>();
	}
	
	void Update () {
		m_em.Update();
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
