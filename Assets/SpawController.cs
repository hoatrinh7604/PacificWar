using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawController : MonoBehaviour
{
    [SerializeField] GameObject[] objects;

    [SerializeField] Transform target;
    [SerializeField] float delayTime = 2f;
    [SerializeField] float delayMinTime = 2f;
    [SerializeField] float delayMaxTime = 2f;
    [SerializeField] float speedObj = 5f;
    private float time;
    private float timeSys;

    [SerializeField] bool isRight;

    [SerializeField] Transform spawPointMin;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeSys += Time.deltaTime;

        if (time > delayTime)
        {
            SpawObject();
            time = 0;
            delayTime = Random.Range(delayMinTime, delayMaxTime);
        }

        if(timeSys > 20)
        {
            delayMinTime = 0.5f;
            delayMaxTime = 1.5f;
        }
    }

    void SpawObject()
    {
        int index = Random.Range(0, objects.Length);
        GameObject obj = Instantiate(objects[index]);
        if(isRight)
        {
            obj.GetComponentInChildren<SpriteRenderer>().flipX = true;
        }    
        obj.GetComponent<SawController>().SetTarget(target, isRight);


        obj.transform.position = new Vector2(spawPointMin.position.x, obj.transform.position.y);
        
    }

    public void UpdateSpeed()
    {
        speedObj += 1;
    }
}
