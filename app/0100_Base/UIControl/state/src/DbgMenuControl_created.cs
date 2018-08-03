//  psggConverterLib.dll converted from DbgMenuControl.xlsx. 
public partial class DbgMenuControl : UIControlApi {

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
            SetNextState(S_INIT);
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
        S_CREATE_PANEL
        パネル生成
    */
    void S_CREATE_PANEL(bool bFirst)
    {
        if (bFirst)
        {
            create("PNL_DBGMENU","Scroll View");
            set_anchor("MC");
            set_pivot("MC");
            set_size(640,500);
            set_pos(0,0);
        }
        set_content_to_parent();
        if (!HasNextState())
        {
            SetNextState(S_0001);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_INIT
        init
    */
    void S_INIT(bool bFirst)
    {
        if (bFirst)
        {
            setup();
        }
        if (!HasNextState())
        {
            SetNextState(S_CREATE_PANEL);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_BUT06
        button 01 作成
    */
    void S_BUT06(bool bFirst)
    {
        if (bFirst)
        {
            create(IT.NAME,"Button");
            set_anchor("TC");
            set_pivot("TC");
            set_size(IT.W, IT.H);
            set_pos(IT.X,IT.Y);
            set_text(IT.NAME);
        }
        if (!HasNextState())
        {
            SetNextState(S_LOOPCHECK);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_0001
        デバッグメニューの準備
    */
    void S_0001(bool bFirst)
    {
        if (bFirst)
        {
            dbgmenu_setup();
        }
        if (!HasNextState())
        {
            SetNextState(S_BUT06);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_LOOPCHECK
        ループ確認
    */
    void S_LOOPCHECK(bool bFirst)
    {
        if (bFirst)
        {
            next_loop();
        }
        br_YES(S_BUT06);
        br_NO(S_END);
        if (HasNextState())
        {
            GoNextState();
        }
    }

}

