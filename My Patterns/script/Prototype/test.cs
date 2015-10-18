/*
*Hi, I'm Lin Dong,
*this script is about prototype pattern in unity3d
*if you want to get more detail please enter my blog http://blog.csdn.net/wolf96
*my Email: wolf_crixus@sina.cn 
*/
using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
    public Monster People;
    public Monster Animal;
    Spawner spawner;

    Spawner s1;
    Spawner s2;
	// Use this for initialization
    void Start()
    {
        spawner = new Spawner();
     if(People!=null)
        spawner.setPrototype(People);

     s1 = new SpawnerFor<PeoPleMonster>();
     s2 = new SpawnerFor<AnimalMonster>();
     s1.setPrototype(People);
     s2.setPrototype(Animal);
    }
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.A))
        {
            spawner.setPrototype(People);
            spawner.createMonster(Vector3.right*Random.Range(-100,100)*0.1f,Quaternion.identity);
        
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            spawner.setPrototype(Animal);
            spawner.createMonster(Vector3.right * Random.Range(-100, 100) * 0.1f, Quaternion.identity);

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
      
            s1.createMonster(Vector3.right * Random.Range(-100, 100) * 0.1f, Quaternion.identity);


        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            s2.createMonster(Vector3.right * Random.Range(-100, 100) * 0.1f, Quaternion.identity);


        }
	}
}
