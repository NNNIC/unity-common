using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEventMachine : MonoBehaviour {

    public static MainEventMachine V;

    EventMachine<MainControl> m_em;

    private void Start()
    {
        V = this;
        m_em = new EventMachine<MainControl>();
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
    //public MainStateEvent CurEvent { get {
    //    var cur = m_em.EventMan.CUR;
    //    if (cur!=null) return (MainStateEvent)cur;
    //    return null;
    //} }
}
