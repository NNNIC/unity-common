using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DbgMenu : MonoBehaviour {

    float m_bw { get { return ScreenDef.GetRealSize(80); } }


    private void OnGUI()
    {
        GUILayout.Label("Debug Menu");
        if (GUILayout.Button("Back To App"))
        {
            SceneManager.LoadScene("app");
        }
    }

}
