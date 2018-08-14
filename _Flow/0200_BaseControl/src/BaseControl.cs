using System;
public partial class BaseControl  {

	bool m_bYesNo;
	
	void br_YES(Action<bool> st)
	{
		if (!HasNextState())
		{
			if (m_bYesNo)
			{
				SetNextState(st);
			}
		}
	}

	void br_NO(Action<bool> st)
	{
		if (!HasNextState())
		{
			if (!m_bYesNo)
			{
				SetNextState(st);
			}
		}
	}
    
    bool m_errordlg_done;
    void errordlg_init()
    {
        m_errordlg_done = false;
        ErrorDlg.V.Kick(()=> { m_errordlg_done = true;});
    }	
    bool errordlg_isdone()
    {
        return m_errordlg_done;
    }

    void fade_init()
    {
        var go = Fade.Create();
        go.transform.parent = StaticObj.V.baseRoot.transform;
    }

}
