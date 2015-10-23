/*
*Hi, I'm Lin Dong,
*this script is about state pattern in unity3d
*if you want to get more detail please enter my blog http://blog.csdn.net/wolf96
*my Email: wolf_crixus@sina.cn 
*/
using UnityEngine;
using System.Collections;

public class State 
{
    protected static string input;
    protected GameObject Person;
    protected Hero Person_ctrl;
    protected float chargeTime;
    protected float MaxTime;
    // Use this for initialization
    public State(GameObject _Person)
    {
        this.Person = _Person;
        this.Person_ctrl = _Person.GetComponent<Hero>();

    }
    public virtual void handleInput(object sender, InputEventArgs e)
    {

    }
    public virtual void UpDate()
    {

    }
    public virtual void UpDate(string dir,bool isRun)
    {
      
       
    }
    public virtual void Start()
    {


    }
}
