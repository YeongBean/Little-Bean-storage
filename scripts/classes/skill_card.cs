using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "skill card", menuName = "SkillCard")]
public class skill_card : ScriptableObject{

    public string skill_character;
    public string skill_name;

    //skill actions
    public int skill_action_bronze;
    public int skill_action_silver;
    public int skill_action_gold;

    //skill dmgs
    public int skill_dmg_bronze;
    public int skill_dmg_silver;
    public int skill_dmg_gold;

    //skill healing amount
    public int skill_heal_bronze;
    public int skill_heal_silver;
    public int skill_heal_gold;

    //skill frames
    public Sprite skill_img;
    public Sprite skill_frame_bronze;
    public Sprite skill_frame_silver;
    public Sprite skill_frame_gold;

    public int rank;

    //skill details
    public string skill_explanation = "";


}
