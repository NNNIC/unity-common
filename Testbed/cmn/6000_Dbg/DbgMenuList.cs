using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public partial class DbgMenuList  {

    static Action< Action<string, Action> > m_regist2 = null;
    public static void RegistDbgMenu( Action<string, Action> regst )
    {
        if (m_regist2 != null)
        {
            m_regist2(regst);
        }
        else
        { 
            regst("TEST", ()=> { Debug.Log("!!!TEST!!!");});
        }
    }

}
