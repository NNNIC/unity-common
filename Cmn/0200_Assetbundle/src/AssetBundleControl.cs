using System;
public partial class AssetBundleControl  {
	
    bool m_bNeed = false;    	
    void br_NeedUpdate(Action<bool> st)
    {
        if (!HasNextState())
        {
            if (m_bNeed) SetNextState(st);
        }
    }
   void  br_NotNeedUpdate(Action<bool> st)
    {
        if (!HasNextState())
        {
            if (!m_bNeed) SetNextState(st);
        }
    }

}
