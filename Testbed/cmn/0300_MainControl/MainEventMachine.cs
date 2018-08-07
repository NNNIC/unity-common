using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEventMachine : MonoBehaviour {

    public static MainEventMachine V;

    EventMachine m_em;

    private void Start()
    {
        V = this;
        m_em = new EventMachine(typeof(MainControl));
        m_em.Start();
    }
	
	void Update () {
        m_em.Update();		
	}

    public bool IsEnd()
    {
        return m_em.IsEnd();
    }
    public void PushEvent(MainStateEventId iid, string iname, object iobj=null)
    {
        var ev = new MainStateEvent(iid,iname,iobj);
        m_em.EventMan.Push(ev);
    }
    public void PushEvent(MainStateEventId iid, object icontrol, string iname, object iobj=null)
    {
        var ev = new MainStateEvent(iid,icontrol,iname,iobj);
        m_em.EventMan.Push(ev);
    }
}
