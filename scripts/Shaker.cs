using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shaker : MonoBehaviour {

    public GameObject obj;
    public float power = 15f;
    public float duration = 0.5f;
    public Transform cards;
    public float slowDownAmount = 1.0f;
    public bool shouldShake = false;

    Vector2 startPos;
    float initialDuration;

    private void Start()
    {
        cards = obj.transform;
        startPos = cards.localPosition;
        initialDuration = duration;
    }

    private void Update()
    {
        if(shouldShake)
        {
            if(duration >0)
            {
                if(duration <= 0.1f)
                    cards.localPosition = startPos + Random.insideUnitCircle * power;
                
                duration -= Time.deltaTime * slowDownAmount;
            }
            else
            {
                shouldShake = false;
                duration = initialDuration;
                cards.localPosition = startPos;
            }
        }
    }

    public void ShakeMe()
    {
        shouldShake = true;
    }
}
