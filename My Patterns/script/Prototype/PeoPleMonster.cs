/*
*Hi, I'm Lin Dong,
*this script is about prototype pattern in unity3d
*if you want to get more detail please enter my blog http://blog.csdn.net/wolf96
*my Email: wolf_crixus@sina.cn 
*/
using UnityEngine;
using System.Collections;

public class PeoPleMonster : Monster
{
    public PeoPleMonster()
    {
        MonsterName = "person";
        attack = 10;
        defense = 10;
        weapon = "sword";
    }
}
