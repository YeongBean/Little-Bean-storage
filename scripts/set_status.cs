using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class set_status : MonoBehaviour {

    public int[] myATK = new int[3];
    public int myDEF;
    public int myHEL;
    public int myACTION;

    public int enemyATK;
    public int enemyDEF;
    public int enemyHEL;
    public int enemyACTION;
    public int enemyTYPE;
    public int enemyDMG1;
    public int enemyDMG2;

    public Image[] current_frame = new Image[3];
    public Sprite[] frame = new Sprite[6];
    public Text current_hp;

    private character[] chs = new character[3];
    private enemy emys;


    void Update()
    {
        if(int.Parse(current_hp.text) < (float)(myHEL * 0.3))
        {
            current_frame[0].sprite = frame[1];
            current_frame[1].sprite = frame[3];
            current_frame[2].sprite = frame[5];
        }
        else
        {
            current_frame[0].sprite = frame[0];
            current_frame[1].sprite = frame[2];
            current_frame[2].sprite = frame[4];
        }
    }

    public void setStats()
    {
        chs[0] = GameObject.Find("Canvas").GetComponent<show_skills>().characters[0];
        chs[1] = GameObject.Find("Canvas").GetComponent<show_skills>().characters[1];
        chs[2] = GameObject.Find("Canvas").GetComponent<show_skills>().characters[2];
        emys = GameObject.Find("Canvas").GetComponent<show_skills>().enemies;

        myATK[0] = chs[0].character_atk;
        myATK[1] = chs[1].character_atk;
        myATK[2] = chs[2].character_atk;

        myDEF = chs[0].character_def + chs[1].character_def + chs[2].character_def;
        myHEL = chs[0].character_hel + chs[1].character_hel + chs[2].character_hel;
        myACTION = chs[0].character_action + chs[1].character_action + chs[2].character_action;

        enemyATK = emys.enemy_atk;
        enemyDEF = emys.enemy_def;
        enemyHEL = emys.enemy_hel;
        enemyACTION = emys.enemy_actions;
        enemyTYPE = emys.enemy_type;
        enemyDMG1 = emys.enemy_dmg1;
        enemyDMG2 = emys.enemy_dmg2;

    }
}
