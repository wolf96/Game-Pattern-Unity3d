/*
*Hi, I'm Lin Dong,
*this script is about state pattern in unity3d
*if you want to get more detail please enter my blog http://blog.csdn.net/wolf96
*my Email: wolf_crixus@sina.cn 
*/
using UnityEngine;
using System.Collections;
using System;

public class InputEventArgs : EventArgs
{
    public /*readonly*/ string input;
    public string addition1;
    public string addition2;
    /*
     * act state 1 - 攻击种类（必杀，暴击，第几次攻击）   2 - 武器种类，判断来确定攻击方式  3 - 是否有组合键攻击判断
     * move state 
     */
    public InputEventArgs(string _input, string _addition1, string _addition2)
    {
        this.input = _input;
        this.addition1 = _addition1;
        this.addition2 = _addition2;
    }
}
