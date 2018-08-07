using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInputFieldEvent : MonoBehaviour {

    public object m_control;

	public void Change(string val)
    {
		var inputfield = GetComponent<InputField>();
        MainEventMachine.V.PushEvent(MainStateEventId.INPUTFIELD_CHANGE,m_control,HierarchyUtility.GetAbsoluteNodePath(gameObject), val);
    }	
	public void End(string val)
	{
		var inputfield = GetComponent<InputField>();
        MainEventMachine.V.PushEvent(MainStateEventId.INPUTFIELD_END,m_control,HierarchyUtility.GetAbsoluteNodePath(gameObject), val);
	}
}
