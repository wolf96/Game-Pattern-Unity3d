/*
*Hi, I'm Lin Dong,
*this script is about Subclass Sandbox pattern in unity3d
*if you want to get more detail please enter my blog http://blog.csdn.net/wolf96
*my Email: wolf_crixus@sina.cn 
*/
using UnityEngine;
using System.Collections;

public class Hero2 : HeroBase{
    
    public AudioClip[] audio=new AudioClip[2];

    private SkillBase[] skill = new SkillBase[2];


	void Start () {


        skill[0] = new skill1();
        skill[1] = new skill2();

        skill[0].init(this.GetComponent<AudioSource>(),audio,this.GetComponent<Move1>(),this,this.gameObject);
        skill[1].init(this.GetComponent<AudioSource>(), audio, this.GetComponent<Move1>(), this,this.gameObject);
	}

	void Update () {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            skill[0].action();

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            skill[1].action();

        }

	}
}
