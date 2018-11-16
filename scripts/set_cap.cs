using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class set_cap : MonoBehaviour {

    public GameObject uis1;
    public GameObject uis2;

    public float duration = 0.5f;
    public float power = 1.0f;
    public float slow = 1.0f;
    public int slot_num;
    public bool chker = false;
    public bool enemy_turn_end = false;
    public bool gameover;
    //true가 마스크
 
    public void Update()
    {
        //오른쪽이 1 왼쪽이 3
        if (chker == true)
        {
            if (duration > 0)
            {
                if (gameover == false)
                {
                    if (enemy_turn_end == false)
                    {
                        uis1.transform.Rotate(Vector3.down * power * slow);
                        uis2.transform.Rotate(Vector3.up * power * slow);
                    }
                    else
                    {
                        uis1.transform.Rotate(Vector3.up * power * slow);
                        uis2.transform.Rotate(Vector3.down * power * slow);
                    }
                }
                else
                {
                    uis1.transform.Rotate(Vector3.left * power * slow);
                    uis2.transform.Rotate(Vector3.right * power * slow);
                }

                duration -= Time.deltaTime;
            }
            else
            {
                chker = false;
                gameover = false;
            }
        }
        else
        {
            gameover = false;
            duration = 0.5f;
        }
        
    }

    public void capping()
    {
        enemy_turn_end = false;
        chker = true;        
    }
}
