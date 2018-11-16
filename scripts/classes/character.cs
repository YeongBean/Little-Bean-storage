using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "character card", menuName = "Character")]
public class character : ScriptableObject
{
    public Sprite character_img;
    public Sprite character_frame;
    public string character_name;
    public int character_action;
    public int character_atk;
    public int character_def;
    public int character_hel;
    public skill_card[] slots = new skill_card[8];
    public int[] skillRanks = new int[8];
}
