
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class JSON_TEST : MonoBehaviour {
    public TextAsset txt;
    public string filePath;
    public string fileName;
	// Use this for initialization
	void Start () {
        filePath = Application.dataPath + "/TextFile";
        fileName = filePath + "/File.txt"; 
	}
	public string GetJsonString()  
{  
    List<Monster> products = new List<Monster>(){  
    new Monster(){MonsterName="苹果",attack=5},  
    new Monster(){MonsterName="橘子",attack=2},  
    new Monster(){MonsterName="干柿子",attack=16}  
    };
    return "";
  // ProductList productlist = new ProductList();  
  //  productlist.GetProducts = products;  
 //   return new JavaScriptSerializer().Serialize(productlist);  
}

    void ReadJson()
    {
        //注意json格式。我的只能在一行写入啊，要不就报错，懂的大牛，不吝赐教啊，这是为什么呢？
        string str = "{'name':'taotao','id':10,'items':[{'itemid':1001,'itemname':'dtao'},{'itemid':1002,'itemname':'test_2'}]}";
        //这里是json解析了
        JsonData jd = JsonMapper.ToObject(str);
        Debug.Log("name=" + jd["name"]);
        Debug.Log("id=" + jd["id"]);
        JsonData jdItems = jd["items"];
        //注意这里不能用枚举foreach，否则会报错的，看到网上
        //有的朋友用枚举，但是我测试过，会报错，我也不太清楚。
        //大家注意一下就好了
        for (int i = 0; i < jdItems.Count; i++)
        {
            Debug.Log("itemid=" + jdItems["itemid"]);
            Debug.Log("itemname=" + jdItems["itemname"]);
        }
        Debug.Log("items is or not array,it's " + jdItems.IsArray);
    }
    void ReadJsonFromTXT()
    {
        //解析json
        JsonData jd = JsonMapper.ToObject(txt.text);
        Debug.Log("hp:" + jd["hp"]);
        Debug.Log("mp:" + jd["mp"]);
        JsonData weapon = jd["weapon"];
        //打印一下数组
        for (int i = 0; i < weapon.Count; i++)
        {
            Debug.Log("name=" + weapon["name"]);
            Debug.Log("color=" + weapon["color"]);
            Debug.Log("durability=" + weapon["durability"]);
        }
    }

    void WriteJsonAndPrint()
    {
        System.Text.StringBuilder strB = new System.Text.StringBuilder();
        JsonWriter jsWrite = new JsonWriter(strB);
        jsWrite.WriteObjectStart();
        jsWrite.WritePropertyName("Name");
        jsWrite.Write("taotao");
        jsWrite.WritePropertyName("Age");
        jsWrite.Write(25);
        jsWrite.WritePropertyName("MM");
        jsWrite.WriteArrayStart();
        jsWrite.WriteObjectStart();
        jsWrite.WritePropertyName("name");
        jsWrite.Write("xiaomei");
        jsWrite.WritePropertyName("age");
        jsWrite.Write("17");
        jsWrite.WriteObjectEnd();
        jsWrite.WriteObjectStart();
        jsWrite.WritePropertyName("name");
        jsWrite.Write("xiaoli");
        jsWrite.WritePropertyName("age");
        jsWrite.Write("18");
        jsWrite.WriteObjectEnd();
        jsWrite.WriteArrayEnd();
        jsWrite.WriteObjectEnd();
        Debug.Log(strB);
        JsonData jd = JsonMapper.ToObject(strB.ToString());
        Debug.Log("name=" + jd["Name"]);
        Debug.Log("age=" + jd["Age"]);
        JsonData jdItems = jd["MM"];
        for (int i = 0; i < jdItems.Count; i++)
        {
            Debug.Log("MM name=" + jdItems["name"]);
            Debug.Log("MM age=" + jdItems["age"]);
        }

    }
        void WriteJsonToFile(string path,string fileName)
    {
        System.Text.StringBuilder strB = new System.Text.StringBuilder();
        JsonWriter jsWrite = new JsonWriter(strB);
        jsWrite.WriteObjectStart();
        jsWrite.WritePropertyName("Name");
        jsWrite.Write("taotao");
        jsWrite.WritePropertyName("Age");
        jsWrite.Write(25);
        jsWrite.WritePropertyName("MM");
        jsWrite.WriteArrayStart();
        jsWrite.WriteObjectStart();
        jsWrite.WritePropertyName("name");
        jsWrite.Write("xiaomei");
        jsWrite.WritePropertyName("age");
        jsWrite.Write("17");
        jsWrite.WriteObjectEnd();
        jsWrite.WriteObjectStart();
        jsWrite.WritePropertyName("name");
        jsWrite.Write("xiaoli");
        jsWrite.WritePropertyName("age");
        jsWrite.Write("18");
        jsWrite.WriteObjectEnd();
        jsWrite.WriteArrayEnd();
        jsWrite.WriteObjectEnd();
        Debug.Log(strB);
        //创建文件目录
        DirectoryInfo dir = new DirectoryInfo(path);
        if (dir.Exists)
        {
            Debug.Log("This file is already exists");
        }
        else
        {
            Directory.CreateDirectory(path);
            Debug.Log("CreateFile");
#if UNITY_EDITOR
            AssetDatabase.Refresh();
#endif
        }
        //把json数据写到txt里
        StreamWriter sw;
        if (File.Exists(fileName))
        {
            //如果文件存在，那么就向文件继续附加（为了下次写内容不会覆盖上次的内容)
            sw = File.AppendText(fileName);
            Debug.Log("appendText");
        }
        else
        {
            //如果文件不存在则创建文件
            sw = File.CreateText(fileName);
            Debug.Log("createText");
        }
        sw.WriteLine(strB);
        sw.Close();
#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif

    }
	// Update is called once per frame
	void Update () {
	
	}
}
