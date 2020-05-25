using UnityEngine;
using System.Collections;

public class BaseMessage {
	public string name;
	public BaseMessage() { name = this.GetType().Name; }
} 

