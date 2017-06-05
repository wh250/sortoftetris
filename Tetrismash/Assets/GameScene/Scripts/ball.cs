using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {
    public Vector3 dir=Vector3.zero;
    public float spd=0;
    float temp;
    public int exp = 0;
    public GameObject explosion;
    public bool released = false;
    public bool bounce = false;
    public GameObject block = null;
    public int bdir = 0;
    public float bdis = 999;
    Vector3 prev;
    public int h;
    public int w;
    void ballbounce()
    {
        switch (bdir)
        {
            case 0:
                break;
            case 1:
                if (dir.y < 0)
                {
                    dir.y *= -1;
                    /*if (Vector2.Reflect(dir, Vector2.up) != Vector2.zero)
                    {
                        dir = Vector2.Reflect(dir, Vector2.up);
                    }*/
                }
                break;
            case 2:
                if (dir.x < 0 || dir.y < 0)
                {
                    temp = dir.x;
                    dir.x = -dir.y;
                    dir.y = -temp;
                    /*if (Vector2.Reflect(dir, transform.position - (block.transform.position + Vector3.up * .5F + Vector3.right * .5F)) != Vector2.zero)
                    {
                        dir = Vector2.Reflect(dir, transform.position - (block.transform.position + Vector3.up * .5F + Vector3.right * .5F));
                    }*/
                }
                break;
            case 3:
                if (dir.x < 0)
                {
                    dir.x *= -1;
                    /*if (Vector2.Reflect(dir, Vector2.right) != Vector2.zero)
                    {
                        dir = Vector2.Reflect(dir, Vector2.right);
                    }*/
                }
                break;
            case 4:
                if (dir.x < 0 || dir.y > 0)
                {
                    temp = dir.x;
                    dir.x = dir.y;
                    dir.y = temp;
                    /*if (Vector2.Reflect(dir, transform.position - (block.transform.position + Vector3.down * .5F + Vector3.right * .5F)) != Vector2.zero)
                    {
                        dir = Vector2.Reflect(dir, transform.position - (block.transform.position + Vector3.down * .5F + Vector3.right * .5F));
                    }*/
                }
                break;
            case 5:
                if (dir.y > 0)
                {
                    dir.y *= -1;
                    /*if (Vector2.Reflect(dir, Vector2.down) != Vector2.zero)
                    {
                        dir = Vector2.Reflect(dir, Vector2.down);
                    }*/
                }
                break;
            case 6:
                if (dir.x > 0 || dir.y > 0)
                {
                    temp = dir.x;
                    dir.x = -dir.y;
                    dir.y = -temp;
                    //if (Vector2.Reflect(dir, transform.position - (block.transform.position + Vector3.down * .5F + Vector3.left * .5F)) != Vector2.zero)
                    //{
                    //    dir = Vector2.Reflect(dir, transform.position - (block.transform.position + Vector3.down * .5F + Vector3.left * .5F));
                    //}
                }
                break;
            case 7:
                if (dir.x > 0)
                {
                    dir.x *= -1;
                    /*if (Vector2.Reflect(dir, Vector2.left) != Vector2.zero)
                    {
                        dir = Vector2.Reflect(dir, Vector2.left);
                    }*/
                }
                break;
            case 8:
                if (dir.x > 0 || dir.y < 0)
                {
                    temp = dir.x;
                    dir.x = dir.y;
                    dir.y = temp;
                    //if (Vector2.Reflect(dir, transform.position - (block.transform.position + Vector3.up * .5F + Vector3.left * .5F)) != Vector2.zero)
                    //{
                    //    dir = Vector2.Reflect(dir, transform.position - (block.transform.position + Vector3.up * .5F + Vector3.left * .5F));
                    //}
                }
                break;
            default:
                break;
        }
        if (block != null)
        {
            if (block.GetComponent<Block>() != null)
            {
                if (!block.GetComponent<Block>().set)
                {
                    block.GetComponent<Block>().destroy = true;
                }
            }
        }
        bdis = 999;
        bdir = 0;
        block = null;
        bounce = false;
    }

    void selfDestruct(int timer)
    {
        transform.parent.gameObject.GetComponent<Main>().release = false;
        transform.parent.gameObject.GetComponent<Main>().b = timer;
        transform.parent.gameObject.GetComponent<Main>().ballnum--;
        transform.parent.gameObject.GetComponent<Main>().settext();
        Destroy(gameObject);
    }
    public void setbounce(GameObject source, float dis, int dir)
    {
        if (dis > bdis) { return; }
        bounce = true;
        bdir = dir;
        bdis = dis;
        block = source;
    }
    // Use this for initialization
    void Start() {
        exp = 0;
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (exp <= 40)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1 - exp / 40F, 0, 1);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        
        if (exp > 0) { exp--; }
        if (exp > 60)
        {
            GameObject tmp = Instantiate(explosion, transform.position + Vector3.back, transform.rotation);
            tmp.GetComponent<Explosion>().main = transform.parent.gameObject;
            exp = 0;
            selfDestruct(40);
        }
        if (released)
        {
            if (bounce)
            {
                ballbounce();
            }
            //gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.Normalize(dir)*spd;
            transform.Translate(Vector3.Normalize(dir) * spd, Space.World);
            if(Mathf.Abs(transform.position.x)>w && Mathf.Sign(transform.position.x) == Mathf.Sign(dir.x))
            {
                dir.x *= -1;
            }
            if (transform.position.y > h && dir.y>0)
            {
                dir.y *= -1;
            }
            if (transform.position.y < -h-1)
            {
                selfDestruct(20);
            }
        }
        else
        {
            if(transform.position - prev != Vector3.zero)
            {
                dir = Vector3.Normalize(transform.position - prev);
            }
            if(Vector3.Distance(transform.position, prev) != 0)
            {
                spd = Vector3.Distance(transform.position, prev)/2;
            }
            if (spd < .1F)
            {
                spd = .1F;
            }
            if (spd >.15F){
                spd = .15F;
            }
            prev = transform.position;
        }
	}
}
