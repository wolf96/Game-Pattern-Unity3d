/*
*Hi, I'm Lin Dong,
*this script is about Subclass Sandbox pattern in unity3d
*if you want to get more detail please enter my blog http://blog.csdn.net/wolf96
*my Email: wolf_crixus@sina.cn 
*/
using UnityEngine;
using System.Collections;

public class skill1 : SkillBase
{

    override public void action()
    {
        playSound(0);
        act(0);
        jump();
    }
}
