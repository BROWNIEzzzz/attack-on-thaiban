using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    public GameObject monster;
    public float timeElaps = 0;
    public float ItemCycle = 0.5f;
    public bool isRand = false;
   

    // Update is called once per frame
    void Update()
    {
        timeElaps += Time.deltaTime;
        if (timeElaps > ItemCycle)
        {
            GameObject temp;
            temp = (GameObject)Instantiate(monster);
            isRand = true;
            Vector3 positionMonster = temp.transform.position;
            temp.transform.position = new Vector3(Random.Range(-3f, 3f), positionMonster.y, positionMonster.z);
            timeElaps -= ItemCycle;
        }

        if (isRand)
        {
            RandpmSpawnRate();
        }
    }

    void RandpmSpawnRate()
    {
        ItemCycle = Random.Range(0.5f, 4f);
        isRand = false;
    }
}
