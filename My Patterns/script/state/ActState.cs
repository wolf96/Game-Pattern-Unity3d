/*
*Hi, I'm Lin Dong,
*this script is about state pattern in unity3d
*if you want to get more detail please enter my blog http://blog.csdn.net/wolf96
*my Email: wolf_crixus@sina.cn 
*/
using UnityEngine;
using System.Collections;

public class ActState : State
{


    public ActState(GameObject _Person)
        : base(_Person)
    {

    }
    public override void Start()
    {
        this.chargeTime = 0.0f;
        this.MaxTime = Person_ctrl.personCtrl.getAct1Time();// actAnimation1;//. 10.0f;//应等于动画时间

        Person_ctrl.personCtrl.Act();
    }
    public override void handleInput(object sender, InputEventArgs e)
    {

        input = e.input;
        switch (input)
        { 
            case "j"://攻击//连击处理？
                if (chargeTime > MaxTime - 0.1f)
                {
              //      Person_ctrl.SetActState(1);
                    Person_ctrl.GetActState(1).Start();
                   // chargeTime = 0.0f;
                    //再播放一次
                }
                break;
            case "i"://防御
                if (chargeTime > MaxTime - 0.8f)
                {
                    Person_ctrl.SetActState(2);
                    Person_ctrl.GetNowActState().Start();
                    // chargeTime = 0.0f;
        
                }
                break;
        }



        //   Debug.Log(e.input);
        //     print(e.input);
    }
    public override void UpDate()
    {
        

        if (chargeTime < MaxTime)
            chargeTime += Time.timeScale / Time.deltaTime;
        else
        {
            this.chargeTime = 0.0f;
            Person_ctrl.SetActState(0);
            Person_ctrl.GetNowActState().Start();
        }
    }
}
