using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class LogHandler  {
    
    static bool m_bDone = false;
    static List<string> m_list = null;

    const int m_maxLen = 100;
    const int m_maxLogSize = 256;


    static bool   m_bDirty;
    static string m_buffer;

    public static void Create()
    {
        if (m_bDone) return;
        m_bDone = true;
        Application.logMessageReceived += HandlerLog;

        m_list = new List<string>();
    }

    private static void HandlerLog(string condition,string stackTrace,LogType type)
    {
        if (type != LogType.Log)
        {
            Log("[!!]condition:"  + condition);
            Log("[!!]stacktrace:" + stackTrace);
        }
        else
        {
            Log(condition);
        }
    }

    public static void Log(string log)
    {
        if (log.StartsWith("[!!]"))
        {
            _log(log,1000);
        }
        else
        {
            _log(log,m_maxLen);
        }
    }
    private static void _log(string log, int maxLen)
    {
        if (!m_bDone) return;

        var nl = Time.time.ToString("F2") + ":" + (log.Length > maxLen ? log.Substring(0, maxLen) : log);
        m_list.Insert(0, nl);
        if (m_list.Count > m_maxLogSize)
        {
            m_list.RemoveAt(m_list.Count - 1);
        }
        m_bDirty = true;
    }

    public static string GetBuffer(bool bSuppress=false)
    {
        if (m_bDirty)
        {
            m_bDirty = false;

            StringBuilder buf = new StringBuilder();
            foreach(var s in m_list)
            {
            
                if (buf!=null) buf.Append(System.Environment.NewLine);
                buf.Append(s);

                if (bSuppress)
                {
                    if (buf.Length >= 5000) // suppress of "condition:String Too Long For TextMeshGenerator Error".
                    {
                        break;
                    }
                }
            }
            m_buffer = buf.ToString();
        }
        return m_buffer;
    }
}
