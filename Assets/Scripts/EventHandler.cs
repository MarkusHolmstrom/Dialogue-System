using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EventHandler : MonoBehaviour
{
	[Serializable]
	public class FloatEvent : UnityEvent<float>
	{
	}

	[Serializable]
	public class IntEvent : UnityEvent<int>
	{
	}

	[Serializable]
	public class PlayerEvent : UnityEvent<Player>
	{
	}
}

