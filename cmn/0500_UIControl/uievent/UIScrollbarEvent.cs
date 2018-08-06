using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScrollbarEvent : MonoBehaviour {

	public void Change(float val)
    {
		var scrollbar = GetComponent<Scrollbar>();
        MainEventMachine.V.PushEvent(MainStateEventId.SCROLLBAR,HierarchyUtility.GetAbsoluteNodePath(gameObject), val);
    }	
}
