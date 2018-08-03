using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


public class UIControlWorkCompo : MonoBehaviour {

    public string m_control_name;
	private Type  m_cotrol_type { get { return System.Type.GetType(m_control_name);}}

	public object 		   m_sm;
    MethodInfo             m_sm_update;
    MethodInfo             m_sm_start;
    MethodInfo             m_sm_isEnd;
    MethodInfo             m_sm_SetTargetAndTemplate;

	public Canvas          m_target;
    public Canvas          m_template;

	void Start () {
		m_sm = Activator.CreateInstance(m_cotrol_type);
        m_sm_update = m_cotrol_type.GetMethod("update");
        m_sm_isEnd  = m_cotrol_type.GetMethod("IsEnd");
        m_sm_start  = m_cotrol_type.GetMethod("Start");
        m_sm_SetTargetAndTemplate = m_cotrol_type.GetMethod("SetTargetAndTemplate");
	}
	
	void Update () {
		if (m_sm!=null && m_sm_update != null) m_sm_update.Invoke(m_sm,null);
	}

	public void SetTarget_TemplateAndStart()
    {
        m_sm_SetTargetAndTemplate.Invoke(m_sm, new object[] {m_target,m_template });
        m_sm_start.Invoke(m_sm,null);
    }
    public bool IsEnd()
    {
        return (bool)m_sm_isEnd.Invoke(m_sm,null);
    }
}
