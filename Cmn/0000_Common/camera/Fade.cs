using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// 汎用フェード　Camera depth = 40
/// 
/// * 生成と削除
/// 　Fade.CreateにてGameObjectが生成され、戻り値となる。
/// 　削除時は、GameObjectを削除
///   
///   Note : Boot時に行う
///   
/// * 利用
/// 
///   Fade.FadeIn() ---> フェードが消える
///   Fade.FadeOut() --> フェードがかかる 
///   Fade.Alpha() --> 現在のアルファ値を返す. 1 であれば、フェード中と判断できる
/// 　
///   秒数指定するとデフォルト時間をオーバーライドして実行する。
/// 
/// </summary>
public class Fade : MonoBehaviour
{
    static readonly Vector3 POSITION         = Vector3.back * 10000;
    static readonly float   DEFAILT_FADETIME = 0.2f;
    static readonly Color   FADE_COLOR       = Color.white;

    #region 生成
    private static Fade V;
    public static GameObject Create()
    {
        if (V!=null) 
        {
            Debug.Log("Fade GameObject has been alread created!");
            return V.gameObject;
        }
        var go = new GameObject("Fade");
        V = go.AddComponent<Fade>();
        V.Init();
        return go;
    }
    #endregion

    #region 提供フェード関数
    public static void FadeIn(float time = -1)
    {
        if (V==null) return;
        V.StopAllCoroutines();
        if (time == 0)
        {
            V._set_alpha(0);
            return;
        }
        var ftime = time == -1 ? DEFAILT_FADETIME : time;
        V.StartCoroutine(V._Fade(1.0f,0.0f,ftime));
    }
    public static void FadeOut(float time = -1)
    {
        if (V==null) return;
        V.StopAllCoroutines();
        if (time == 0)
        {
            V._set_alpha(1);
            return;
        }
        var ftime = time == -1 ? DEFAILT_FADETIME : time;
        V.StartCoroutine(V._Fade(0.0f,1.0f,ftime));
    }
    public static void ShowImmediate() {
        if (V == null) return;
        V._set_alpha(0f);
    }
    public static void HideImmediate() {
        if (V == null) return;
        V._set_alpha(1f);
    }

    IEnumerator _Fade(float s, float e, float time)
    {
        var num = Mathf.CeilToInt(time * 30.0f);
        var d = (e-s)/ num; // １フレーム当りの変化量
        for(var i = 0; i<= num; i++)
        {
            _set_alpha(s + i * d);
            yield return new WaitForEndOfFrame();
        }
        _set_alpha(e);
    }
    public static float Alpha()
    {
        if(V==null) return 0;
        return V.m_alpha;
    }
    #endregion

    private GameObject   m_obj;
    private Camera       m_cam;
    private MeshRenderer m_mr;

    private float        m_alpha;

    private void Init() // フェードオブジェクトを作成して、カメラコンポーネントで写す
    {
        if (m_obj!=null) return;

        transform.position = POSITION;

        m_obj = new GameObject("obj");
        m_obj.transform.parent = transform;
        m_obj.transform.localPosition=Vector3.forward;
        m_obj.layer = LayerMask.NameToLayer("UI");

        m_mr = m_obj.AddComponent<MeshRenderer>();
        var mf = m_obj.AddComponent<MeshFilter>();
        var mesh = MeshUtil.CreateRectangle(1.1f,1.1f,true);
        mf.mesh = mesh;
        
        var shader = Resources.Load<Shader>("Shaders/OneColor");
        var mat = new Material( shader );
        m_mr.material = mat;

        m_cam = gameObject.AddComponent<Camera>();
        m_cam.orthographic = true;
        m_cam.nearClipPlane = 0.1f;
        m_cam.farClipPlane = 10f;
        m_cam.orthographicSize = 0.5f;
        m_cam.cullingMask = 1 << LayerMask.NameToLayer("UI");
        m_cam.depth = 40; 
        m_cam.clearFlags = CameraClearFlags.Depth;

        _set_alpha(0);
    }

    void Start()
    {
        if (V==null) { //通常は通らない。テストのため単独で当コンポーネントを追加した時用
            V= this; 
            Init();
        }
    }

    void OnDestroy()
    {
        V = null;
    }

    void _set_alpha(float i)
    {
       var a = Mathf.Clamp01(i);
       var c = new Color(FADE_COLOR.r, FADE_COLOR.g, FADE_COLOR.b,a);
       if (m_mr!=null)
       {
           m_mr.material.SetColor("_Color",c);
       }

        m_cam.enabled = (a!=0); //透明時はカメラ機能をOFFして処理を軽くする

        m_alpha = a;
    }

    #region TEST
    [ContextMenu("TEST FADEIN")]
    void TEST_FADEIN()
    {
        FadeIn();
    }
    [ContextMenu("TEST FADEOUT")]
    void TEST_FADEOUT()
    {
        FadeOut();
    }
    #endregion

}
