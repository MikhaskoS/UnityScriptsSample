using UnityEngine;
using System.Collections;


public class LocalizationTextAttribute : System.Attribute
{
	
	public string LocalizationID = string.Empty;

	
	public LocalizationTextAttribute(string ID)
	{
		LocalizationID = ID;
	}
}
