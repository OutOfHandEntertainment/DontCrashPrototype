using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBehavior : MonoBehaviour {
    private enum STATE { CHASE, STATIONARY, CRASH, ESCAPE}

    public float vehicleSpeed = 8f;
    private STATE currentState;
    private Transform currentDirection;
    private Vector3 currentPosition;
    private float attackPosition;
    private bool attacked;
    private int hitCounter;
	// Use this for initialization
	void Start () {
        EnterChaseState();		
	}
	
	// Update is called once per frame
	void Update () {

        switch (currentState) {
            case STATE.CHASE:
                UpdateChase();
                break;
            case STATE.STATIONARY:
                UpdateStationary();
                break;
            case STATE.CRASH:
                UpdateCrash();
                break;
            case STATE.ESCAPE:
                UpdateEscape();
                break;
        }		
	}

    private void EnterChaseState()
    {
        currentState = STATE.CHASE;
        transform.position = new Vector3(-30, 0, -15);
        transform.Rotate(0, 90, 0);
    }

    private void UpdateChase()
    {
        if (transform.position.x <= 0f)
        {
            transform.Translate(Vector3.forward * (Time.deltaTime * vehicleSpeed));
        }
        else
        {
            EnterStationaryState();
        }

    }

    private void EnterStationaryState()
    {
        currentState = STATE.STATIONARY;
        StartCoroutine(UpdateStationary());
    }

    private IEnumerator UpdateStationary()
    {
        yield return new WaitForSecondsRealtime(1f);
        if(hitCounter == 2)
        {
            EnterEscapeState();
        }
        EnterCrashState();
    }

    private void EnterCrashState()
    {
        currentState = STATE.CRASH;
        currentPosition = transform.position;
        attackPosition = Random.Range(-1f, 1f);
    }

    private void UpdateCrash()
    {
        Debug.Log(currentState);
        Debug.Log(currentPosition);
        if (transform.position.z <= -5f)
        {
            transform.Translate(Vector3.left * Time.deltaTime * vehicleSpeed);
            transform.Translate(Vector3.forward * Time.deltaTime * attackPosition * vehicleSpeed);
        }
        else
        {
            EnterEscapeState();
        }

    }

    private void EnterEscapeState()
    {
        currentState = STATE.ESCAPE;
        hitCounter++;
    }

    private void UpdateEscape()
    {
        if(transform.position.z >= -12f)
        {
            transform.Translate(Vector3.right * Time.deltaTime * vehicleSpeed);
        }
        else if (hitCounter <= 2)
        {
            EnterStationaryState();
        }
        else if(transform.position.x >= 50)
        {
            Destroy(this.gameObject);
        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime * vehicleSpeed);
        }
    }
}

