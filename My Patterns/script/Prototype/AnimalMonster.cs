/*
*Hi, I'm Lin Dong,
*this script is about prototype pattern in unity3d
*if you want to get more detail please enter my blog http://blog.csdn.net/wolf96
*my Email: wolf_crixus@sina.cn 
*/
using UnityEngine;
using System.Collections;

public class AnimalMonster : Monster
{
    public AnimalMonster()
    {
        MonsterName = "Animal";
        attack = 8;
        defense = 15;
        weapon = "tooth";
    }

}
