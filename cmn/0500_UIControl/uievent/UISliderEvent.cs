using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISliderEvent : MonoBehaviour {

    public object m_control;

	public void Change(float val)
    {
		var slider = GetComponent<Slider>();
        MainEventMachine.V.PushEvent(MainStateEventId.SLIDER,m_control,HierarchyUtility.GetAbsoluteNodePath(gameObject), val);
    }	
}
