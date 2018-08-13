using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObj : MonoBehaviour {

    public StaticObj V;

	void Start () {
        V = this;
		GameObject.DontDestroyOnLoad(gameObject);
	}
	
}
