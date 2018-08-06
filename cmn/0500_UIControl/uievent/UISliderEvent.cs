using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISliderEvent : MonoBehaviour {

	public void Change(float val)
    {
		var slider = GetComponent<Slider>();
        MainEventMachine.V.PushEvent(MainStateEventId.SLIDER,HierarchyUtility.GetAbsoluteNodePath(gameObject), val);
    }	
}
