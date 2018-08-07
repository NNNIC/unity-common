using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class EventMachine {

    #region event manager
    protected EventManager m_evman;
    public EventManager    EventMan { get { return m_evman;  } }
    #endregion

    #region constructor
    public  StateManager m_sm { get; private set; }

    public EventMachine(Type t)
    {
        m_sm = (StateManager)Activator.CreateInstance(t);
        m_evman = new EventManager();
        m_sm.SetEventMan(m_evman);

    }
    #endregion

    #region Framework
    public void Start()
    {
        m_sm.Start();
    }
	public void Update () {
        m_evman.Update();
        m_sm.update();        	    	
	}
    public bool IsEnd()
    {
        return m_sm.IsEnd();
    }
    #endregion
}