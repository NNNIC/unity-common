using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class app : MonoBehaviour {

	void Awake () {
        MainControl.m_app_init_start = DbgMenuList.app_init_start;		
	}
	
}
