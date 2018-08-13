//  psggConverterLib.dll converted from AssetBundleFileLoadControl.xlsx. 
using System;
public partial class AssetBundleFileLoadControl : StateManager {

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
            SetNextState(S_Check_LoadReqFileList);
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
        S_Check_LoadReqFileList
        リクエストファイルリスト確認
    */
    void S_Check_LoadReqFileList(bool bFirst)
    {
        if (bFirst)
        {
        }
        br_YES(S_CheckCache);
        br_NO(S_END);
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_HTTPREQ
        httprequest
    */
    void S_HTTPREQ(bool bFirst)
    {
        if (bFirst)
        {
        }
        br_ERROR(S_DISP_ERROR);
        if (!HasNextState())
        {
            SetNextState(S_UNZIP);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_UNZIP
        キャッシュ領域にファイル展開
    */
    void S_UNZIP(bool bFirst)
    {
        if (bFirst)
        {
        }
        if (!HasNextState())
        {
            SetNextState(S_LoadFromCache);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_LoadFromCache
        キャッシュよりロード
    */
    void S_LoadFromCache(bool bFirst)
    {
        if (bFirst)
        {
        }
        if (!HasNextState())
        {
            SetNextState(S_Check_LoadReqFileList);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_CheckCache
        キャッシュにあるか？
    */
    void S_CheckCache(bool bFirst)
    {
        if (bFirst)
        {
        }
        br_YES(S_LoadFromCache);
        br_NO(S_HTTPREQ);
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_DISP_ERROR
        エラー表示
    */
    void S_DISP_ERROR(bool bFirst)
    {
        if (bFirst)
        {
        }
        br_RETRY(S_HTTPREQ);
        br_RETRYMAX(S_DISP_FATALERROR);
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_DISP_FATALERROR
        復旧できないエラー表示へ
    */
    void S_DISP_FATALERROR(bool bFirst)
    {
        if (bFirst)
        {
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

