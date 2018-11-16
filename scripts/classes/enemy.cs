using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "enemy", menuName = "enemy")]
public class enemy : ScriptableObject {

    public string enemy_name;
    public string enemy_detail;
    public int enemy_actions;
    public int enemy_atk;
    public int enemy_def;
    public int enemy_hel;
    public int enemy_type; //1 기본 2 흡혈 3 자기회복 
    public int enemy_dmg1;
    public int enemy_dmg2;

    public Sprite enemy_img;
}
