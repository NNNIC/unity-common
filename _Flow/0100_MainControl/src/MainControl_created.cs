//  psggConverterLib.dll converted from MainControl.xlsx. 
public partial class MainControl : StateManager {

    public override void Start()
    {
        Goto(S_START);
    }

    public override bool IsEnd()
    {
        return CheckState(S_END);
    }



    /*
        S_START
        開始
    */
    void S_START(bool bFirst)
    {
        if (bFirst)
        {
        }
        if (!HasNextState())
        {
            SetNextState(S_GOTO_APPSCENE);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_END
        終了
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
        S_APP_INIT
        アプリ側初期化
    */
    void S_APP_INIT(bool bFirst)
    {
        if (bFirst)
        {
        }
        if (!HasNextState())
        {
            SetNextState(S_READY_ALL);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_BASE_INIT
        ベース初期化
    */
    void S_BASE_INIT(bool bFirst)
    {
        if (bFirst)
        {
            base_init();
        }
        base_update();
        if (!base_init_done()) return;
        if (!HasNextState())
        {
            SetNextState(S_APP_INIT);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_UI_START
        UI開始
    */
    void S_UI_START(bool bFirst)
    {
        if (bFirst)
        {
            ui_start("dbg_uitest_01");
        }
        if (!HasNextState())
        {
            SetNextState(S_EVENT_PROC);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_READY_ALL
        全準備完了
    */
    void S_READY_ALL(bool bFirst)
    {
        if (bFirst)
        {
        }
        if (!HasNextState())
        {
            SetNextState(S_UI_START1);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_GOTO_APPSCENE
        Appシーンへ移動
    */
    void S_GOTO_APPSCENE(bool bFirst)
    {
        if (bFirst)
        {
            appscene_go();
        }
        if (!HasNextState())
        {
            SetNextState(S_APP_PREBASE_INIT);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_UI_START1
        UI開始
    */
    void S_UI_START1(bool bFirst)
    {
        if (bFirst)
        {
            ui_start("dbg_scene_change");
        }
        if (!HasNextState())
        {
            SetNextState(S_EVENT_PROC);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_APP_PREBASE_INIT
        BASEより先に初期化するＡＰＰ用
    */
    void S_APP_PREBASE_INIT(bool bFirst)
    {
        if (bFirst)
        {
            app_prebase_init();
        }
        if (!HasNextState())
        {
            SetNextState(S_BASE_INIT);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_EVENT_PROC
        イベント処理
    */
    void S_EVENT_PROC(bool bFirst)
    {
        if (bFirst)
        {
        }
        check_event_and_dispatch();
        if (HasNextState())
        {
            GoNextState();
        }
    }

}

