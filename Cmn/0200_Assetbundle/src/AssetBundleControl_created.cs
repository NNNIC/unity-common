//  psggConverterLib.dll converted from AssetBundleControl.xlsx. 
public partial class AssetBundleControl : StateManager {

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
            SetNextState(S_WAIT_READY);
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
        S_WAIT_READY
        通信環境準備待ち
    */
    void S_WAIT_READY(bool bFirst)
    {
        if (bFirst)
        {
        }
        if (!HasNextState())
        {
            SetNextState(S_GET_FILELIST_ONNET);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_CACHE_CHECK
        常駐および既存ファイルの更新必要性確認
    */
    void S_CACHE_CHECK(bool bFirst)
    {
        if (bFirst)
        {
        }
        br_NeedUpdate(S_UPDATEFILES);
        br_NotNeedUpdate(S_WAIT_REQUEST);
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_GET_FILELIST_ONNET
        ネットよりファイルリストを取得
    */
    void S_GET_FILELIST_ONNET(bool bFirst)
    {
        if (bFirst)
        {
        }
        if (!HasNextState())
        {
            SetNextState(S_CACHE_CHECK);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_WAIT_REQUEST
        要求待ち
    */
    void S_WAIT_REQUEST(bool bFirst)
    {
        if (bFirst)
        {
        }
        if (!HasNextState())
        {
            SetNextState(S_GET_FILES);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_UPDATEFILES
        ファイル更新
    */
    void S_UPDATEFILES(bool bFirst)
    {
        if (bFirst)
        {
        }
        if (!HasNextState())
        {
            SetNextState(S_WAIT_REQUEST);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_GET_FILES
        指定ファイルの取得
    */
    void S_GET_FILES(bool bFirst)
    {
        if (bFirst)
        {
        }
        if (!HasNextState())
        {
            SetNextState(S_WAIT_REQUEST);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }

}

