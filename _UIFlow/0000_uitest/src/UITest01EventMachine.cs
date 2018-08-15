using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITest01EventMachine : MonoBehaviour, UIEventMachineInterface {

    EventMachine                  m_em;
    UITest01Control               m_sm { get { return (UITest01Control)m_em.m_sm; } }

    public Canvas m_target;
    public Canvas m_template;

    public bool IsReady() { return m_bReady; }
    private bool m_bReady = false;

	void Start () {
		m_em = new EventMachine(typeof(UITest01Control));
        m_bReady = true;
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
