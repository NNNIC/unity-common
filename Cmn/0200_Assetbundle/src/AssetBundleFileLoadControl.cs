﻿using System;
public partial class AssetBundleFileLoadControl  {
	
	bool m_bYesNo;
	
	void br_YES(Action<bool> st)
	{
		if (!HasNextState())
		{
			if (m_bYesNo)
			{
				SetNextState(st);
			}
		}
	}

	void br_NO(Action<bool> st)
	{
		if (!HasNextState())
		{
			if (!m_bYesNo)
			{
				SetNextState(st);
			}
		}
	}
	
	
	// write your code 
	void br_ERROR(Action<bool> st)
	{
	}

	void br_RETRY(Action<bool> st)
	{
			//TODO
	}
	void br_RETRYMAX(Action<bool> st)
	{
	}

}
