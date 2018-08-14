using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObj : MonoBehaviour {

    public static StaticObj V;
    public GameObject baseRoot;

	void Start () {
        V = this;
		GameObject.DontDestroyOnLoad(gameObject);
	}
	
}
