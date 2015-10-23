/*
*Hi, I'm Lin Dong,
*this script is about state pattern in unity3d
*if you want to get more detail please enter my blog http://blog.csdn.net/wolf96
*my Email: wolf_crixus@sina.cn 
*/
using UnityEngine;
using System.Collections;

public class IdleStateMoveVer : State {
    public IdleStateMoveVer(GameObject _Person)
        : base(_Person)
    {

    }
    public override void Start()
    {
        Person_ctrl.personCtrl.Idle();
    }
    public override void handleInput(object sender, InputEventArgs e)
    {
        input = e.input;
        switch (input)
        {
            case "w"://jump
                Person_ctrl.SetMoveState(2);
                Person_ctrl.GetNowMoveState().Start();

                break;
            case "a":


                break;
            case "s":

            case "d":

                   Person_ctrl.SetMoveState(1);
                    Person_ctrl.GetNowMoveState().Start();
                break;
        }

    }
    public override void UpDate()
    {

        Person_ctrl.personCtrl.Idle();
    }
}
