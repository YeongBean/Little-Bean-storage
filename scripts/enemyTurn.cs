using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyTurn : MonoBehaviour {

    public Text current_trn;
    public Text my_health;
    public Text myACTION;
    public Text details;
    public Text enemy_health;
    private bool enemy_turn;


    private int enemy_actions;
    private int enemy_attack;
    private int my_actions;
    private int my_hps;
    private int my_deffence;

    private float waitings;
    private int enemy_dmgs;
    private float slow;

    private Animator[] anima = new Animator[3];
    private int temp;

	// Use this for initialization
	void Start () {
        slow = 1.0f;
        waitings = 1.5f;
        enemy_turn = false;
        anima[0] = GameObject.Find("character1").GetComponent<Animator>();
        anima[1] = GameObject.Find("character2").GetComponent<Animator>();
        anima[2] = GameObject.Find("character3").GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        if (enemy_turn)
        {
            if (waitings > 0)
            {
                waitings -= Time.deltaTime * slow;
            }
            else
            {
                temp = Random.Range(0, 7);
                switch (temp)
                {
                    case 0:
                        anima[0].Play("hit");
                        break;
                    case 1:
                        anima[1].Play("hit");
                        break;
                    case 2:
                        anima[2].Play("hit");
                        break;
                    case 3:
                        anima[1].Play("hit");
                        anima[2].Play("hit");
                        break;
                    case 4:
                        anima[2].Play("hit");
                        anima[0].Play("hit");
                        break;
                    case 5:
                        anima[0].Play("hit");
                        anima[1].Play("hit");
                        break;
                    case 6:
                        anima[0].Play("hit");
                        anima[1].Play("hit");
                        anima[2].Play("hit");
                        break;
                }
                anima[0].Play("hit");
                enemy_dmgs = Random.Range(0, 2);
                if (enemy_dmgs == 0) enemy_dmgs = GameObject.Find("Canvas").GetComponent<set_status>().enemyDMG1;
                else enemy_dmgs = GameObject.Find("Canvas").GetComponent<set_status>().enemyDMG2;

                my_hps = my_hps - (enemy_attack * enemy_dmgs) / (my_deffence * 2);
                if(my_hps < 1) my_hps = 0;
                    
                my_health.text = my_hps.ToString();
                my_actions = GameObject.Find("Canvas").GetComponent<set_status>().myACTION;                
                enemy_actions--;

                waitings = 1.5f;
                if (my_hps >= 1)
                {
                    if (enemy_actions == 0)
                    {
                        enemy_actions = GameObject.Find("Canvas").GetComponent<set_status>().enemyACTION;
                        current_trn.text = (int.Parse(current_trn.text) + 1).ToString();
                        GameObject.Find("Canvas").GetComponent<show_skills>().showSkills();

                        GameObject.Find("hand card1").GetComponent<attack>().setSkill();
                        GameObject.Find("hand card2").GetComponent<attack>().setSkill();
                        GameObject.Find("hand card3").GetComponent<attack>().setSkill();
                        GameObject.Find("hand card4").GetComponent<attack>().setSkill();
                        GameObject.Find("hand card5").GetComponent<attack>().setSkill();
                        enemy_turn = false;
                        myACTION.text = my_actions.ToString();
                        details.text = "";

                        GameObject.Find("turn end button").GetComponent<set_cap>().enemy_turn_end = true;
                        GameObject.Find("turn end button").GetComponent<set_cap>().chker = true;
                        GameObject.Find("turn end button").GetComponent<set_cap>().duration = 0.5f;

                        GameObject.Find("hand card1").GetComponent<set_cap>().uis1.transform.rotation = Quaternion.Euler(0, 90, 0);
                        GameObject.Find("hand card1").GetComponent<set_cap>().uis2.transform.rotation = Quaternion.Euler(0, -90, 0);
                        GameObject.Find("hand card1").GetComponent<attack>().plus = 1;

                        GameObject.Find("hand card2").GetComponent<set_cap>().uis1.transform.rotation = Quaternion.Euler(0, 90, 0);
                        GameObject.Find("hand card2").GetComponent<set_cap>().uis2.transform.rotation = Quaternion.Euler(0, -90, 0);
                        GameObject.Find("hand card2").GetComponent<attack>().plus = 1;

                        GameObject.Find("hand card3").GetComponent<set_cap>().uis1.transform.rotation = Quaternion.Euler(0, 90, 0);
                        GameObject.Find("hand card3").GetComponent<set_cap>().uis2.transform.rotation = Quaternion.Euler(0, -90, 0);
                        GameObject.Find("hand card3").GetComponent<attack>().plus = 1;

                        GameObject.Find("hand card4").GetComponent<set_cap>().uis1.transform.rotation = Quaternion.Euler(0, 90, 0);
                        GameObject.Find("hand card4").GetComponent<set_cap>().uis2.transform.rotation = Quaternion.Euler(0, -90, 0);
                        GameObject.Find("hand card4").GetComponent<attack>().plus = 1;

                        GameObject.Find("hand card5").GetComponent<set_cap>().uis1.transform.rotation = Quaternion.Euler(0, 90, 0);
                        GameObject.Find("hand card5").GetComponent<set_cap>().uis2.transform.rotation = Quaternion.Euler(0, -90, 0);
                        GameObject.Find("hand card5").GetComponent<attack>().plus = 1;
                    }
                }
                else
                {
                    GameObject.Find("failed masks").GetComponent<set_cap>().gameover = true;
                    GameObject.Find("failed masks").GetComponent<set_cap>().chker = true;
                    enemy_turn = false;
                }
            }
        }
	}

    public void enemy_settings()
    {
        enemy_actions = GameObject.Find("Canvas").GetComponent<set_status>().enemyACTION;
        enemy_attack = GameObject.Find("Canvas").GetComponent<set_status>().enemyATK;
        my_deffence = GameObject.Find("Canvas").GetComponent<set_status>().myDEF;
        
    }

    public void enemyATTACKING()
    {

        my_hps = int.Parse(my_health.text);
        
        enemy_turn = true;
    }
}
