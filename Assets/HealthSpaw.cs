using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpaw : MonoBehaviour
{
    [SerializeField] GameObject[] objects;

    [SerializeField] Transform target;
    [SerializeField] float delayTime = 2f;
    [SerializeField] float delayMinTime = 2f;
    [SerializeField] float delayMaxTime = 2f;

    private float time;
    [SerializeField] Transform spawPointMin;
    [SerializeField] Transform spawPointMax;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > delayTime)
        {
            SpawObject();
            time = 0;
            delayTime = Random.Range(delayMinTime, delayMaxTime);
        }
    }

    void SpawObject()
    {
        int index = Random.Range(0, objects.Length);
        GameObject obj = Instantiate(objects[index]);

        float randomPos = Random.Range(spawPointMin.position.x, spawPointMax.position.x);

        obj.transform.position = new Vector2(randomPos, obj.transform.position.y);

    }

}
