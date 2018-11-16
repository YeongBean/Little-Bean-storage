using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotate_ui : MonoBehaviour {

    public GameObject uis;
    public float duration;
    public float power = 1.0f;
    public float slow = 1.0f;
    public int direction = 1;
    public bool chker = false;
    
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (duration > 0)
        {
            switch (direction)
            {
                case 0:
                    transform.Rotate(Vector3.right * power);
                    break;
                case 1:
                    transform.Rotate(Vector3.down * power);
                    break;
                case 2:
                    transform.Rotate(Vector3.left * power);
                    break;
                case 3:
                    transform.Rotate(Vector3.up * power);
                    break;
                case 4:
                    transform.Translate(Vector2.down * power);
                    break;
                case 5:
                    transform.Translate(Vector2.right * power);
                    break;
                case 6:
                    transform.Translate(Vector2.left * power);
                    break;

            }

            duration -= Time.deltaTime * slow;
        }
        else uis.transform.rotation = Quaternion.Euler(0, 0, 0);
	}
}


