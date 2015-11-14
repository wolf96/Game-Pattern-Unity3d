/*
*Hi, I'm Lin Dong,
*this script is about Subclass Sandbox pattern in unity3d
*if you want to get more detail please enter my blog http://blog.csdn.net/wolf96
*my Email: wolf_crixus@sina.cn 
*/
using UnityEngine;
using System.Collections;

public class skill2 : SkillBase
{

    override public void action()
    {
        playSound(1);
        act(1);
    //    print(heroObject.transform.rotation);
        if (heroObject.transform.rotation.w > 0)
            move(Vector3.right, 2, true);
        else if (heroObject.transform.rotation.w < 0)
            move(Vector3.left, 2, true);
    }
}
