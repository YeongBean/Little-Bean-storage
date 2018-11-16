using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attack : MonoBehaviour {

    public Text skill_details;
    public Text left_actions;
    public Text my_hp;
    public Text enemy_hp;
    public int enemy_def;
    public int slot_num;
    private bool attack_possible;
    private int my_atk;
    private int my_skillDMG;
    private int cnts;
    private int skillRank;
    private int skill_action;
    private int my_healing;
    private string detail;
    private string showing_detail;
    public int plus = 1;

    private Animator[] anima = new Animator[3];
    private string tempname;

    private void Start()
    {
        anima[0] = GameObject.Find("character1").GetComponent<Animator>();
        anima[1] = GameObject.Find("character2").GetComponent<Animator>();
        anima[2] = GameObject.Find("character3").GetComponent<Animator>();
    }

    public void setSkill()
    {
        cnts = GameObject.Find("Canvas").GetComponent<show_skills>().cnt[slot_num];
        skillRank = GameObject.Find("Canvas").GetComponent<show_skills>().skill_rank[slot_num];
        detail = GameObject.Find("Canvas").GetComponent<show_skills>().skills[cnts].skill_explanation.ToString();
        enemy_def = GameObject.Find("Canvas").GetComponent<set_status>().enemyDEF;
        switch (skillRank)
        {
            case 1:
                my_skillDMG = GameObject.Find("Canvas").GetComponent<show_skills>().skills[cnts].skill_dmg_bronze;
                skill_action = GameObject.Find("Canvas").GetComponent<show_skills>().skills[cnts].skill_action_bronze;
                my_healing = GameObject.Find("Canvas").GetComponent<show_skills>().skills[cnts].skill_heal_bronze;
                break;
            case 2:
                my_skillDMG = GameObject.Find("Canvas").GetComponent<show_skills>().skills[cnts].skill_dmg_silver;
                skill_action = GameObject.Find("Canvas").GetComponent<show_skills>().skills[cnts].skill_action_silver;
                my_healing = GameObject.Find("Canvas").GetComponent<show_skills>().skills[cnts].skill_heal_silver;
                break;
            case 3:
                my_skillDMG = GameObject.Find("Canvas").GetComponent<show_skills>().skills[cnts].skill_dmg_gold;
                skill_action = GameObject.Find("Canvas").GetComponent<show_skills>().skills[cnts].skill_action_gold;
                my_healing = GameObject.Find("Canvas").GetComponent<show_skills>().skills[cnts].skill_heal_gold;
                break;
        }



        for (int i = 0; i < 3; i++)
            if (GameObject.Find("Canvas").GetComponent<show_skills>().characters[i].character_name == GameObject.Find("Canvas").GetComponent<show_skills>().skills[cnts].skill_character)
                my_atk = GameObject.Find("Canvas").GetComponent<show_skills>().characters[i].character_atk;
    }


    public void My_attack()
    {
        GameObject.Find("turn end button").GetComponent<set_cap>().uis1.transform.rotation = Quaternion.Euler(0, 90, 0);
        GameObject.Find("turn end button").GetComponent<set_cap>().uis2.transform.rotation = Quaternion.Euler(0, -90, 0);
        attack_possible = (skill_action <= int.Parse(left_actions.text));
        

        if (skill_details.text.ToString() == showing_detail)
        {
            if (skill_action <= int.Parse(left_actions.text) && plus > -1)
            {
                if(tempname == GameObject.Find("Canvas").GetComponent<show_skills>().characters[0].character_name)
                    anima[0].Play("attack");
                else if(tempname == GameObject.Find("Canvas").GetComponent<show_skills>().characters[1].character_name)
                    anima[1].Play("attack");
                else anima[2].Play("attack");

                enemy_hp.text = (int.Parse(enemy_hp.text.ToString()) - ((my_atk * my_skillDMG) / (enemy_def * 5))).ToString();
                my_hp.text = (int.Parse(my_hp.text.ToString()) + ((my_atk * my_healing) / (enemy_def * 5))).ToString();
                attack_possible = false;
                plus--;
                left_actions.text = (int.Parse(left_actions.text) - skill_action).ToString();
                GameObject.Find("enemy").GetComponent<Shaker>().ShakeMe();
                GetComponent<set_cap>().capping();
            }
        }
        else
        {
            if (plus > 0)
            {
                showing_detail = detail;
                if (my_atk > 0) showing_detail = showing_detail + "\n 위력 : " + my_skillDMG;
                if (my_healing > 0) showing_detail = showing_detail + "\n 회복력 : " + my_healing;
                plus--;
            }
            if(attack_possible == true)
                skill_details.text = showing_detail;

            tempname = GameObject.Find("Canvas").GetComponent<show_skills>().playing_character_names[slot_num];
            plus = 0;
        }
    }
}
