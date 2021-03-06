﻿using System;
using UnityEngine.SceneManagement;

public partial class MainControl  {

    void appscene_go()
    {
        SceneManager.LoadScene("app");
    }

	//app側連携
	public static Action m_app_init_start;
	void app_prebase_init()
	{
		if (m_app_init_start!=null) m_app_init_start();
	}

    #region base initialization
    BaseControl m_base_mc;
    void base_init()
    {
        m_base_mc = new BaseControl();
        m_base_mc.Start();
    }
    void base_update()
    {
        m_base_mc.update();
    }
    bool base_init_done()
    {
        return m_base_mc.IsEnd();
    }
    #endregion

    bool m_uiOk = false;
    void ui_start(string first_ui_name) {
        m_uiOk = false;
        UIControl.V.m_firstMenuName = first_ui_name;
        UIControl.V.Kick(()=>m_uiOk=true);
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
