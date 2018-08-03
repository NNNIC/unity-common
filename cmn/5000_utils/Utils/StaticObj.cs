using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObj : MonoBehaviour {

	void Start () {
		GameObject.DontDestroyOnLoad(gameObject);
	}
	
}
