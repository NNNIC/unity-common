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
            SetNextState(S_APP_INIT_START);
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
        S_WAIT_BASE_READY
        BASEの準備待ち
    */
    void S_WAIT_BASE_READY(bool bFirst)
    {
        if (bFirst)
        {
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
            SetNextState(S_READY_ALL);
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
            ui_start();
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
            SetNextState(S_UI_START);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_APP_INIT_START
        アプリ側初期化開始
    */
    void S_APP_INIT_START(bool bFirst)
    {
        if (bFirst)
        {
            app_init_start();
        }
        if (!HasNextState())
        {
            SetNextState(S_WAIT_BASE_READY);
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

