using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIToggleEvent : MonoBehaviour {
    public object m_control;
	public void PushDown(bool b)
    {
		var toggle = GetComponent<Toggle>();
        MainEventMachine.V.PushEvent(MainStateEventId.TOGGLE, m_control, HierarchyUtility.GetAbsoluteNodePath(gameObject), b);
    }	
}
