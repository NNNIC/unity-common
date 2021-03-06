using System;
using UnityEngine;
public class StateManager : StateManagerGetEventManInterface
{
    public EventManager m_eventman { get; private set; }

    Action<bool> m_curfunc;
    Action<bool> m_nextfunc;
    Action<bool> m_tempfunc;

    bool         m_noWait;
    
    public virtual void Start() { }
    public virtual bool IsEnd() {  return true; }

    public void SetEventMan(EventManager eventman) { m_eventman = eventman; }
    public EventManager GetEventMan() { return m_eventman; }

    public void update()
    {
        while(true)
        {
            var bFirst = false;
            if (m_nextfunc!=null)
            {
                m_curfunc = m_nextfunc;
                m_nextfunc = null;
                bFirst = true;

                Debug.Log("Into .. " + m_curfunc.Method.Name);
               
            }
            m_noWait = false;
            if (m_curfunc!=null)
            {   
                m_curfunc(bFirst);
            }
            if (!m_noWait) break;
        }
    }
    public void Goto(Action<bool> func)
    {
        m_nextfunc = func;
    }
    public bool CheckState(Action<bool> func)
    {
        return m_curfunc == func;
    }
    // for tempfunc
    public void SetNextState(Action<bool> func)
    {
        m_tempfunc = func;
    }
    public void GoNextState()
    {
        m_nextfunc = m_tempfunc;
        m_tempfunc = null;
    }
    public bool HasNextState()
    {
        return m_tempfunc != null;
    }
    public void NoWait()
    {
        m_noWait = true;
    }
}
