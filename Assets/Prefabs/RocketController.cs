using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    [SerializeField] GameObject effect;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float speed;
    private int dir;

    [SerializeField] bool isHealth = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //GamePlayController.Instance.DecreaseTime();
            SpawEffect();
            Destroy(this.gameObject);
        }else if (collision.gameObject.tag == "Player")
        {
            GameController.Instance.UpdateSlider(isHealth ? 1 : -1);
            SpawEffect();
            Destroy(this.gameObject);
        }else if (collision.gameObject.tag == "Ground")
        {
            SpawEffect();
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, 0);
    }

    private void SpawEffect()
    {
        GameObject eff = Instantiate(effect, Vector3.zero, Quaternion.identity, transform);
        eff.transform.localPosition = Vector3.zero;
        eff.transform.parent = null;
        Destroy(eff, 1f);
    }

    public void SetFlipX(bool flipX)
    {
        spriteRenderer.flipX = flipX;
    }

    public void SetSpeed(int dir)
    {
        speed *= dir;
    }
}
