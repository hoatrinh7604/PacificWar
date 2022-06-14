using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour
{
    public Vector2 startForce;
    public int point;
    public float hp;
    [SerializeField] float speed;
    public Rigidbody2D rb;
    private Transform target;

    [SerializeField] GameObject bullet;
    private float time;
    private float timeSys;
    private float timeDelay = 1f;
    [SerializeField] float timemaxDelay = 1.5f;

    private bool startMoving = false;
    public bool flipX;

    [SerializeField] GameObject effect;
    private void Update()
    {
        if (startMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target.position) < 0.01f)
            {
                Destroy(this.gameObject);
            }

            time += Time.deltaTime;
            timeSys += Time.deltaTime;

            if(time > timeDelay)
            {
                SpawBullet();
                timeDelay = Random.Range(0.7f, timemaxDelay);
                time = 0;
            }

            if(timeSys > 20)
            {
                timemaxDelay = 1;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            SpawEffect();
            Destroy(this.gameObject);
        }
    }

    private void SpawEffect()
    {
        GameObject eff = Instantiate(effect, Vector3.zero, Quaternion.identity, transform);
        eff.transform.localPosition = Vector3.zero;
        eff.transform.parent = null;
        Destroy(eff, 1f);
    }

    public void SpawBullet()
    {
        GameObject bulletObj = Instantiate(bullet, Vector3.zero, Quaternion.identity, transform);
        bulletObj.transform.localPosition = Vector3.zero;
        bulletObj.transform.parent = null;
        bulletObj.GetComponent<RocketController>().SetFlipX(this.flipX);
        bulletObj.GetComponent<RocketController>().SetSpeed(this.flipX ? 1 : -1);

    }

    public void SetTarget(Transform target, bool flipX)
    {
        this.flipX = flipX;
        this.target = target;
        startMoving = true;
        speed = Random.Range(3f, 6f);
    }

    public int GetPoint()
    {
        return point;
    }

    public float GetHP()
    {
        return hp;
    }
}
