using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager {

    public Queue<object> m_eventlist { get; private set; }
    public object CUR { get; private set; }

    public bool existEvent { get { return m_eventlist!=null && m_eventlist.Count > 0; } }
    public int  countEvent { get { return m_eventlist!=null ? m_eventlist.Count : 0; } }
        
    public EventManager()
    {
        m_eventlist = new Queue<object>();
        CUR = null;
    }

    public void Push(object @event)
    {
        if (m_eventlist==null) m_eventlist = new Queue<object>();
        m_eventlist.Enqueue(@event);
    }

    public void Update()
    {
        CUR = null;
        if (m_eventlist!=null && m_eventlist.Count>0)
        {
            CUR = m_eventlist.Dequeue();
        }
    }

}
