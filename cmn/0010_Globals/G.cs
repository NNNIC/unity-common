using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class G {
    public static bool IsDbgMenu() {
        var scene = SceneManager.GetActiveScene();
        return (scene.name.ToLower() == "dbgmenu");
    }
}
