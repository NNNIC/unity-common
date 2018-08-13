using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonEvent : MonoBehaviour {

    public object m_control;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PushDown()
    {
        MainEventMachine.V.PushEvent( MainStateEventId.BUTTON, m_control, this.name);
    }

}
