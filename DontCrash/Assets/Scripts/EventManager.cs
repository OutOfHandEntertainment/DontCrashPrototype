using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

	public VehicleFactoryManager factory;

	public float TimeBetweenEvents;
	public float TimeBetweenDifficultyAdjustment;

	private double difficultyRating;

	private const float expectedGameLengthModifier = 12f;
	private const float sinFrequencyModifier = 2f;
	private const float sinAmplitudeModifier = 2f;
	private const float difficultySlopeModifier = 5f / 3f;
	private const float baseDifficultyRating = 2f;

	private const float randomModifierMin = -.3f;
	private const float randomModifierMax = .3f;

	// Use this for initialization
	void Start () {
		StartCoroutine(events());
		StartCoroutine(difficultyManager());
	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator events() {
		while (true) {
			yield return new WaitForSecondsRealtime(TimeBetweenEvents);

			//factory.ConstructVehicle(VehicleFactoryManager.vehicleTypes.light);
		}
	}

	IEnumerator difficultyManager() {
		while (true) {
			difficultyRating = calculateDifficultyRating();
			Debug.Log(difficultyRating);

			yield return new WaitForSecondsRealtime(TimeBetweenDifficultyAdjustment);
		}
	}

	// Use difficulty equation to calculate event difficulty rating based on current time
	private int calculateDifficultyRating() {
		float timeMinutes = GameManager.GameManagerInstance.getGameTime()/60;
		double calculatedDifficulty;

		System.Random rand = new System.Random();
		double randomModifier = (rand.NextDouble() * (randomModifierMax - randomModifierMin)) + randomModifierMin;

		// Equation to calculate difficulty rating. Has base linear slope modified by a sin function to give peaks and valleys
		// to difficulty
		// diff = diffSlope*x + sin(frequencyModifier*x) + baseDifficulty
		calculatedDifficulty = ((difficultySlopeModifier*timeMinutes) + (sinAmplitudeModifier*Math.Sin(sinFrequencyModifier*timeMinutes)) + baseDifficultyRating);

		// add modifier to calculated difficulty +/- some percent
		calculatedDifficulty += calculatedDifficulty * randomModifier;

		// return rating rounded to nearest whole number
		return Convert.ToInt32(calculatedDifficulty);
	}
}
