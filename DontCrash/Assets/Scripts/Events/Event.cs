using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Event : MonoBehaviour {

	public enum EventTypes { vehicle, obstacle, fork };

	public int difficultyRating;
	public float postDelay;
	
	// Update is called once per frame
	void Update () {
		
	}
}
