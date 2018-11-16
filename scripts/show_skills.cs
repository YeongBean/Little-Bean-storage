using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class show_skills : MonoBehaviour {

    public Text current_turn;
    public Text leftAction;
    public Text my_hp;
    public Text enemy_hp;
    public SpriteRenderer enemy_img;
    public character[] characters = new character[3];
    public enemy enemies;
    public string[] playing_character_names = new string[5];

    public skill_card[] skills = new skill_card[24];

    public Text[] s_actions = new Text[5];
    public Image[] s_frame = new Image[5];
    public Image[] s_img = new Image[5];
    public int[] skill_rank = new int[5];

    public int[] cnt = new int[5];

    // Use this for initialization
    void Start () {
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 8; j++)
            {
                skills[j + (8 * i)] = characters[i].slots[j];
                skills[j + (8 * i)].rank = characters[i].skillRanks[j];
            }

        current_turn.text = "1".ToString();
        GameObject.Find("Canvas").GetComponent<set_status>().setStats();
        GameObject.Find("turn end button").GetComponent<enemyTurn>().enemy_settings();
        leftAction.text = GameObject.Find("Canvas").GetComponent<set_status>().myACTION.ToString();
        my_hp.text = GameObject.Find("Canvas").GetComponent<set_status>().myHEL.ToString();
        showSkills();

        GameObject.Find("hand card1").GetComponent<attack>().setSkill();
        GameObject.Find("hand card2").GetComponent<attack>().setSkill();
        GameObject.Find("hand card3").GetComponent<attack>().setSkill();
        GameObject.Find("hand card4").GetComponent<attack>().setSkill();
        GameObject.Find("hand card5").GetComponent<attack>().setSkill();

        enemy_hp.text = enemies.enemy_hel.ToString();
        enemy_img.sprite = enemies.enemy_img;
    }

    // Update is called once per frame
    void Update () {
		
	}
    public void setComponents(character ch1, character ch2, character ch3, enemy emy)
    {
        characters[0] = ch1;
        characters[1] = ch2;
        characters[2] = ch3;
        enemies = emy;
    }
    public void showSkills()
    {
        cnt[0] = -1;
        cnt[1] = -1;
        cnt[2] = -1;
        cnt[3] = -1;
        cnt[4] = -1;

        cnt[0] = Random.Range(0, 24);
        while((cnt[0] == cnt[1])|| (cnt[0] == cnt[2])|| (cnt[0] == cnt[3])|| (cnt[0] == cnt[4]))
            cnt[0] = Random.Range(0, 24);

        s_img[0].sprite = skills[cnt[0]].skill_img;
        playing_character_names[0] = skills[cnt[0]].skill_character;
        skill_rank[0] = skills[cnt[0]].rank;
        if (skill_rank[0] == 1)
        {
            s_actions[0].text = skills[cnt[0]].skill_action_bronze.ToString();
            s_frame[0].sprite = skills[cnt[0]].skill_frame_bronze;
        }else if (skill_rank[0] == 2)
        {
            s_actions[0].text = skills[cnt[0]].skill_action_silver.ToString();
            s_frame[0].sprite = skills[cnt[0]].skill_frame_silver;
        }
        else if (skill_rank[0] == 3)
        {
            s_actions[0].text = skills[cnt[0]].skill_action_gold.ToString();
            s_frame[0].sprite = skills[cnt[0]].skill_frame_gold;
        }

        cnt[1] = Random.Range(0, 24);
        while ((cnt[1] == cnt[0]) || (cnt[1] == cnt[2]) || (cnt[1] == cnt[3]) || (cnt[1] == cnt[4]))
            cnt[1] = Random.Range(0, 24);

        s_img[1].sprite = skills[cnt[1]].skill_img;
        playing_character_names[1] = skills[cnt[1]].skill_character;
        skill_rank[1] = skills[cnt[1]].rank;
        if (skill_rank[1] == 1)
        {
            s_actions[1].text = skills[cnt[1]].skill_action_bronze.ToString();
            s_frame[1].sprite = skills[cnt[1]].skill_frame_bronze;
        }
        else if (skill_rank[1] == 2)
        {
            s_actions[1].text = skills[cnt[1]].skill_action_silver.ToString();
            s_frame[1].sprite = skills[cnt[1]].skill_frame_silver;
        }
        else if (skill_rank[1] == 3)
        {
            s_actions[1].text = skills[cnt[1]].skill_action_gold.ToString();
            s_frame[1].sprite = skills[cnt[1]].skill_frame_gold;
        }

        cnt[2] = Random.Range(0, 24);
        
        while ((cnt[2] == cnt[1]) || (cnt[2] == cnt[0]) || (cnt[2] == cnt[3]) || (cnt[2] == cnt[4]))
            cnt[2] = Random.Range(0, 24);

        s_img[2].sprite = skills[cnt[2]].skill_img;
        playing_character_names[2] = skills[cnt[2]].skill_character;
        skill_rank[2] = skills[cnt[2]].rank;
        if (skill_rank[2] == 1)
        {
            s_actions[2].text = skills[cnt[2]].skill_action_bronze.ToString();
            s_frame[2].sprite = skills[cnt[2]].skill_frame_bronze;
        }
        else if (skill_rank[2] == 2)
        {
            s_actions[2].text = skills[cnt[2]].skill_action_silver.ToString();
            s_frame[2].sprite = skills[cnt[2]].skill_frame_silver;
        }
        else if (skill_rank[2] == 3)
        {
            s_actions[2].text = skills[cnt[2]].skill_action_gold.ToString();
            s_frame[2].sprite = skills[cnt[2]].skill_frame_gold;
        }

        cnt[3] = Random.Range(0, 24);
        while ((cnt[3] == cnt[1]) || (cnt[3] == cnt[2]) || (cnt[3] == cnt[0]) || (cnt[3] == cnt[4]))
            cnt[3] = Random.Range(0, 24);

        s_img[3].sprite = skills[cnt[3]].skill_img;
        playing_character_names[3] = skills[cnt[3]].skill_character;
        skill_rank[3] = skills[cnt[3]].rank;
        if (skill_rank[3] == 1)
        {
            s_actions[3].text = skills[cnt[3]].skill_action_bronze.ToString();
            s_frame[3].sprite = skills[cnt[3]].skill_frame_bronze;
        }
        else if (skill_rank[3] == 2)
        {
            s_actions[3].text = skills[cnt[3]].skill_action_silver.ToString();
            s_frame[3].sprite = skills[cnt[3]].skill_frame_silver;
        }
        else if (skill_rank[3] == 3)
        {
            s_actions[3].text = skills[cnt[3]].skill_action_gold.ToString();
            s_frame[3].sprite = skills[cnt[3]].skill_frame_gold;
        }

        cnt[4] = Random.Range(0, 24);
        while ((cnt[4] == cnt[1]) || (cnt[4] == cnt[2]) || (cnt[4] == cnt[3]) || (cnt[4] == cnt[0]))
            cnt[4] = Random.Range(0, 24);

        s_img[4].sprite = skills[cnt[4]].skill_img;
        playing_character_names[4] = skills[cnt[4]].skill_character;
        skill_rank[4] = skills[cnt[4]].rank;
        if (skill_rank[4] == 1)
        {
            s_actions[4].text = skills[cnt[4]].skill_action_bronze.ToString();
            s_frame[4].sprite = skills[cnt[4]].skill_frame_bronze;
        }
        else if (skill_rank[4] == 2)
        {
            s_actions[4].text = skills[cnt[4]].skill_action_silver.ToString();
            s_frame[4].sprite = skills[cnt[4]].skill_frame_silver;
        }
        else if (skill_rank[4] == 3)
        {
            s_actions[4].text = skills[cnt[4]].skill_action_gold.ToString();
            s_frame[4].sprite = skills[cnt[4]].skill_frame_gold;
        }
    }
}
