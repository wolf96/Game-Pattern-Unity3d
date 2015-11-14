/*
*Hi, I'm Lin Dong,
*this script is about Subclass Sandbox pattern in unity3d
*if you want to get more detail please enter my blog http://blog.csdn.net/wolf96
*my Email: wolf_crixus@sina.cn 
*/
using UnityEngine;
using System.Collections;

public class SkillBase : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip[] audio;
    private Move1 moveFunc;
    private Hero2 hero;
    protected GameObject heroObject;

    public void init(AudioSource _audioSource, AudioClip[] _audio, Move1 _moveFunc, Hero2 _hero, GameObject _heroObject)
    {
        this.audio = _audio;
        this.audioSource = _audioSource;
        this.moveFunc = _moveFunc;
        this.hero = _hero;
        this.heroObject = _heroObject;
    }
    protected void act(int actID)
    {
        hero.Act();
    }
    protected void playSound(int soundID)
    {
        audioSource.PlayOneShot(audio[soundID]);
    }

    protected void move(Vector3 dir, float moveSpeed, bool isRun)
    {
        moveFunc.move(dir, moveSpeed, isRun);
    }
    protected void jump()
    {
        moveFunc.jump();
    }
    protected void particalEffect()
    {

    }

    virtual public void action()
    {

    }

}
