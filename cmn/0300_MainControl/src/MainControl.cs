using System;

public partial class MainControl  {

	//app側連携
	public static Action m_app_init_start;
	void app_init_start()
	{
		if (m_app_init_start!=null) m_app_init_start();
	}

    bool base_isready()
    {
        return BaseProcess.V!=null;
    }

    void base_init() {
        BaseProcess.V.ReqStart();
    }

    bool base_init_done()
    {
        return BaseProcess.V.m_state == ProcessState.RUNNING;
    }

    void ui_start() {
        UIControl.V.ReqStart();
    }

    string m_dbgmenu_buttonname;
    void br_DBGMENU(Action<bool> st)
    {
        if (!HasNextState())
        {
            var cur = MainStateEvent.Cur();
            if (cur!=null && cur.id == MainStateEventId.BUTTON && DbgMenuControl.V.IsDbgMenuAction(cur.name))
            { 
                m_dbgmenu_buttonname = cur.name;
                SetNextState(st);
            }
        }
    }
    void exec_dbgmenu()
    {
        DbgMenuControl.V.CallAction(m_dbgmenu_buttonname);
    }

	void br_BUT05(Action<bool> st)
    {
        if (!HasNextState())
        {
            var cur = MainStateEvent.Cur();
            if (cur!=null && cur.id == MainStateEventId.BUTTON && cur.name == "BUT05" )
            { 
                SetNextState(st);
            }
        }
    }

    void disp_error()
    {
        ErrorDlg.V.SetError("test");
    }

}
