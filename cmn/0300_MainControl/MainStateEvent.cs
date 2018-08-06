using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MainStateEventId {

    UNKNOWN,
    USER,

    BUTTON,
    TOGGLE,
    SLIDER,
    SCROLLBAR,

    INPUTFIELD_CHANGE,
    INPUTFIELD_END,

    SCROLLVIEW

}

public class MainStateEvent
{
    public MainStateEventId id;
    public object           control; //制御管理者
    public string           name;
    public object           obj;

    public MainStateEvent(MainStateEventId iid, string iname, object iobj=null)
    {
        id      = iid;
        control = null;
        name    = iname;
        obj     = iobj;
    }
    public MainStateEvent(MainStateEventId iid, object icontrol,  string iname, object iobj=null)
    {
        id      = iid;
        control = icontrol;
        name    = iname;
        obj     =  iobj;
    }
}

