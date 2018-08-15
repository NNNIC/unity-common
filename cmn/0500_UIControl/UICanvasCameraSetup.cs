using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class UICanvasCameraSetup : MonoBehaviour {

    public Canvas        m_canvas;
    public Camera        m_cam;

    
	// Use this for initialization
	void Start () {

        ScreenDef.screen_height = Screen.height;
        ScreenDef.screen_width  = Screen.width;

        var tr  = m_canvas.GetComponent<RectTransform>();

        tr.anchorMin = Vector2.one;
        tr.anchorMax = Vector2.one;
        tr.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, ScreenDef.reference_width);
        tr.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,   ScreenDef.reference_height_fix);
        tr.anchoredPosition = VectorUtil.Affect_XY(tr.anchoredPosition,0,0);


        // カメラセットアップ
        m_canvas.worldCamera = m_cam;

        m_cam.orthographic     = true;
        m_cam.orthographicSize = ScreenDef.orthographicSize;
        m_cam.farClipPlane  = 150;
        m_cam.nearClipPlane = 1;
        m_cam.transform.position = VectorUtil.Add_Z(tr.position,-100);
        m_cam.rect = new Rect( 0,ScreenDef.view_y,1,ScreenDef.view_height);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
