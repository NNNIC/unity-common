using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScrollbarEvent : MonoBehaviour {
    public object m_control;
	public void Change(float val)
    {
		var scrollbar = GetComponent<Scrollbar>();
        MainEventMachine.V.PushEvent(MainStateEventId.SCROLLBAR,m_control, HierarchyUtility.GetAbsoluteNodePath(gameObject), val);
    }	
}
