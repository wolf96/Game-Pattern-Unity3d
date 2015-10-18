/*
*Hi, I'm Lin Dong,
*this script is about prototype pattern in unity3d
*if you want to get more detail please enter my blog http://blog.csdn.net/wolf96
*my Email: wolf_crixus@sina.cn 
*/
using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    Monster prototype;
	// Use this for initialization
   public void setPrototype(Monster _prototype)
    {
        this.prototype = _prototype;
	}
	

  public  GameObject createMonster(Vector3 pos, Quaternion rot)
    {
        return prototype.clone(pos,  rot);
	}



  /*public GameObject createPerson(GameObject Person)
  {
      return Instantiate(Person);
  }
  public GameObject createAnimal(GameObject Animal)
  {
      return Instantiate(Animal);
  }
  public GameObject createDragon(GameObject Dragon)
  {
      return Instantiate(Dragon);
  }*/
}
