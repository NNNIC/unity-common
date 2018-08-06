using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScrollViewEvent : MonoBehaviour {
    public object m_control;
	public void Change(Vector2 val)
    {
		var scrollrect = GetComponent<ScrollRect>();
        MainEventMachine.V.PushEvent(MainStateEventId.SCROLLVIEW,m_control,HierarchyUtility.GetAbsoluteNodePath(gameObject), val);
    }	
}
