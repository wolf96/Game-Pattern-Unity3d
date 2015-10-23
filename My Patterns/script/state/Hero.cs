/*
*Hi, I'm Lin Dong,
*this script is about state pattern in unity3d
*if you want to get more detail please enter my blog http://blog.csdn.net/wolf96
*my Email: wolf_crixus@sina.cn 
*/
using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour//hero_state
{
    public HeroCtrl personCtrl;
    private State heroStateActVer;
    private State heroStateMoveVer;
    InputEventArgs inputArgs;
    private bool isRun = false;

    private State[] hero_act_state = new State[3];
    /*
     *0-idle
     *1-act
     *2-def
     */
    private State[] hero_move_state = new State[3];
    /*
     *0-idle
     *1-move
     *2-jump
     */

    // Use this for initialization
    public delegate void InputEventHandler(object sender, InputEventArgs e);
    public event InputEventHandler InputTran;
    // Update is called once per frame
    void Input_events(InputEventArgs e)
    {

        if (e != null)
        {
            InputTran(this, e);
        }
    }


    void Start()
    {


        personCtrl = this.GetComponent<HeroCtrl>();
        heroStateActVer = new IdleStateActVer(this.gameObject);
        heroStateMoveVer = new IdleStateMoveVer(this.gameObject);
        inputArgs = new InputEventArgs("", "", "");
        hero_act_state[0] = new IdleStateActVer(this.gameObject);
        hero_act_state[1] = new ActState(this.gameObject);
        hero_act_state[2] = new DefenseState(this.gameObject);

        hero_move_state[0] = new IdleStateMoveVer(this.gameObject);
        hero_move_state[1] = new MoveState(this.gameObject);
        hero_move_state[2] = new JumpState(this.gameObject);

        InputTran += new InputEventHandler(heroStateActVer.handleInput);
        InputTran += new InputEventHandler(heroStateMoveVer.handleInput);
    }
    public State GetNowMoveState()
    {
        //        print(heroStateMoveVer.ToString());
        return this.heroStateMoveVer;
    }
    public State GetMoveState(int stateIndex)
    {
        return hero_move_state[stateIndex];
    }
    public void SetMoveState(int stateIndex)
    {

        this.heroStateMoveVer = hero_move_state[stateIndex];
    }




    public State GetNowActState()
    {
        //      print(heroStateActVer.ToString());
        return this.heroStateActVer;
    }
    public State GetActState(int stateIndex)
    {
        return hero_act_state[stateIndex];
    }
    public void SetActState(int stateIndex)
    {

        this.heroStateActVer = hero_act_state[stateIndex];
    }
    // Update is called once per frame
    void Update()
    {
        //http://docs.unity3d.com/ScriptReference/Input-inputString.html
        #region act&jump input
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRun = true;
        }
        if (Input.anyKeyDown)
        {//  print(Input.inputString);
            foreach (char c in Input.inputString)
            {
                if (c != null)
                {
                    inputArgs.input = c.ToString();// Input.inputString;
                    Input_events(inputArgs);
                }
            }

        }

        #endregion

        #region move input


        if (Input.GetKey(KeyCode.S))
        {
            inputArgs.input = "s";
            inputArgs.input = Input.inputString;
            Input_events(inputArgs);
            heroStateMoveVer.UpDate("down", isRun);
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputArgs.input = "a";
            inputArgs.input = Input.inputString;
            Input_events(inputArgs);
            heroStateMoveVer.UpDate("left", isRun);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            inputArgs.input = "d";
            inputArgs.input = Input.inputString;
            Input_events(inputArgs);
            heroStateMoveVer.UpDate("right", isRun);
        }

        isRun = false;

        #endregion
        heroStateActVer.UpDate();//
    }
}
