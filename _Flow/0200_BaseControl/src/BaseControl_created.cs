//  psggConverterLib.dll converted from BaseControl.xlsx. 
using System;
public partial class BaseControl : StateManager {

    public void Start()
    {
        Goto(S_START);
    }
    public bool IsEnd()
    {
        return CheckState(S_END);
    }



    /*
        S_START
    */
    void S_START(bool bFirst)
    {
        if (bFirst)
        {
        }
        if (!HasNextState())
        {
            SetNextState(S_ERRORDLG_INIT);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_END
    */
    void S_END(bool bFirst)
    {
        if (bFirst)
        {
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_DEBUG_INIT
        デバッグ機能初期化
    */
    void S_DEBUG_INIT(bool bFirst)
    {
        if (bFirst)
        {
        }
        if (!HasNextState())
        {
            SetNextState(S_NET_INIT);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_NET_INIT
        通信初期化
    */
    void S_NET_INIT(bool bFirst)
    {
        if (bFirst)
        {
        }
        if (!HasNextState())
        {
            SetNextState(S_ASSETBUNDLE_INIT);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_ERRORDLG_INIT
        エラーダイアログ初期化
    */
    void S_ERRORDLG_INIT(bool bFirst)
    {
        if (bFirst)
        {
            errordlg_init();
        }
        if (!errordlg_isdone()) return;
        if (!HasNextState())
        {
            SetNextState(S_DEBUG_INIT);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_ASSETBUNDLE_INIT
        アセットバンドル初期化
    */
    void S_ASSETBUNDLE_INIT(bool bFirst)
    {
        if (bFirst)
        {
        }
        if (!HasNextState())
        {
            SetNextState(S_FADE_INIT);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_FADE_INIT
        フェード初期化
    */
    void S_FADE_INIT(bool bFirst)
    {
        if (bFirst)
        {
            fade_init();
        }
        if (!HasNextState())
        {
            SetNextState(S_END);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }

}

