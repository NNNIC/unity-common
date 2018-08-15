using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DbgMenu : MonoBehaviour {

    GUISkin m_skin;

    float m_bw { get { return ScreenDef.GetRealSize(80); } }

    bool m_bGuiFirstDone = false;
    private void gui_init()
    {
        if (m_bGuiFirstDone) return;
        m_bGuiFirstDone = true;

        m_skin = (GUISkin)Object.Instantiate(GUI.skin);
        m_skin.label.fontSize  = (int)ScreenDef.GetRealSize(32);
        m_skin.button.fontSize = (int)ScreenDef.GetRealSize(32);
    }
    private void OnGUI()
    {
        gui_init();
        GUI.skin = m_skin;

        GUILayout.Label("Debug Menu");
        if (GUILayout.Button("Back To App"))
        {
            SceneManager.LoadScene("app");
        }
        if (GUILayout.Button("UIControl Show"))
        {
            UIControl.V.Show();
        }
    }

}
