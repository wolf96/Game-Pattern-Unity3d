/*
*Hi, I'm Lin Dong,
*this script is about prototype pattern in unity3d
*JSON for Data Modeling
*read JSON from txt
*if you want to get more detail please enter my blog http://blog.csdn.net/wolf96
*my Email: wolf_crixus@sina.cn 
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class Spawner_JSON : MonoBehaviour
{
    public TextAsset txt;
    string filePath;
    string fileName;
    // Use this for initialization
    void Start()
    {

        print(txt.text);
        Monster m = createMonster("Person");
        print("name = " + m.MonsterName + " ,attack = " + m.attack);

    }
    // Update is called once per frame
    Monster ReadJsonFromTXT(string name)
    {
        //解析json
        Monster monster = new Monster();
        JsonData jd = JsonMapper.ToObject(txt.text);
        print(jd.IsArray);
        JsonData monsterData = jd["Monster"];
        print(monsterData.IsArray);
        //打印一下数组
        for (int i = 0; i < monsterData.Count; i++)
        {
            if (name == monsterData[i]["MonsterName"].ToString())
            {
                monster.MonsterName = monsterData[i]["MonsterName"].ToString();
                monster.attack = int.Parse(monsterData[i]["attack"].ToString());
                monster.defense = int.Parse(monsterData[i]["defense"].ToString());
                monster.weapon = monsterData[i]["weapon"].ToString();
            }
        }

        return monster;
    }
    public Monster createMonster(string name)
    {
        return ReadJsonFromTXT(name);
    }
}
