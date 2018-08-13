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
        BaseProcess.V.Kick();
    }

    bool base_init_done()
    {
        return BaseProcess.V.m_state == ProcessState.RUNNING;
    }

    void ui_start() {
        UIControl.V.Kick();
    }

    void check_event_and_dispatch()
    {
        var cur = (MainStateEvent)m_eventman.CUR;
        if (cur!=null && cur.control!=null)
        {
            var p = (StateManagerGetEventManInterface)cur.control;
            if (p!=null)
            {
                p.GetEventMan().Push(cur);
            }
        }
    }
}
