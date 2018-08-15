using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogGUI : MonoBehaviour {

    GUISkin m_skin;
    Texture2D m_bgimg;
    bool      m_show;

	void Start () {
	}
	
	void Update () {
	
	}

    bool m_bGuiInitDone = false;
    void gui_init()
    {
        if (m_bGuiInitDone) return;
        m_bgimg = Resources.Load<Texture2D>("GUI/black8x8");

        m_skin = GUI.skin;
        m_skin.scrollView.normal.background = m_bgimg;    
        m_skin.label.fontSize = (int)ScreenDef.GetRealSize(32);
    }

    Vector2 m_pos;
    void OnGUI()
    {
        gui_init();

        var swh = Screen.width / 2;
        var bottom_button_height = ScreenDef.GetRealSize( 80 );
        if (m_show)
        {

            GUI.skin = m_skin;
            GUILayout.BeginArea(new Rect(0,0,Screen.width,Screen.height - bottom_button_height));
            m_pos = GUILayout.BeginScrollView(m_pos);
            {
                GUILayout.Label(LogHandler.GetBuffer(true));
            }
            GUILayout.EndScrollView();
            GUILayout.EndArea();
        }
        if (GUI.Button(new Rect(0,Screen.height - bottom_button_height, swh, bottom_button_height),"HIDE/SHOW"))
        {
            m_show = !m_show;
        }
        if (GUI.Button(new Rect(swh,Screen.height - bottom_button_height, swh, bottom_button_height),"DEBUG MENU"))
        {
            SceneManager.LoadScene("dbgMenu");
        }
    }
}
