using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class DbgMenuList  {

    public static void app_init_start()
    {
        m_regist2 = RegistDbgMenuUse;
    }
    static void RegistDbgMenuUse( Action<string, Action> regst )
    {
        regst("Scene 0", ()=> {
            SceneManager.LoadScene(0);
        });
        regst("Scene 1", ()=> {
            SceneManager.LoadScene(1);
        });
        regst("Scene 2", ()=> {
            SceneManager.LoadScene(2);
        });
        regst("Scene 3", ()=> {
            SceneManager.LoadScene(3);
        });
        regst("Scene 4", ()=> {
            SceneManager.LoadScene(4);
        });
        regst("Scene 5", ()=> {
            SceneManager.LoadScene(5);
        });

        regst("HIDE MENU 10 SEC", ()=> {
            

        });

    }
}
