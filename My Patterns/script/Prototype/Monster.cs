/*
*Hi, I'm Lin Dong,
*this script is about prototype pattern in unity3d
*if you want to get more detail please enter my blog http://blog.csdn.net/wolf96
 **my Email: wolf_crixus@sina.cn 
*/
using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {
    public string MonsterName;
    public int attack;
    public int defense;
    public string weapon;


    //shallow clone
 /*   virtual public Monster clone()
    {
        return this;
	}*/
    //deep clone
  public  GameObject clone(Vector3 pos, Quaternion rot)
    {
        return Instantiate(this.gameObject, pos, rot) as GameObject;
    }
}
