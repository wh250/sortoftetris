using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    public GameObject main;
    public GameObject explosion;
    public GameObject airbmb;
    public GameObject exball;
    public int color;
    public bool set;
    public int type;
    public int w;
    public int h;
    public bool destroy = false;
    int temp;
    Vector2 ballpos;
    Vector2 pos;
    GameObject tmp;
    bool bouncecheck()
    {
        if (Mathf.Abs(ballpos.x - transform.position.x) < .5F && Mathf.Abs(ballpos.y-transform.position.y)<1)
        {
            return true;
        }
        if (Mathf.Abs(ballpos.y - transform.position.y) < .5F && Mathf.Abs(ballpos.x - transform.position.x) < 1)
        {
            return true;
        }
        if(Vector2.Distance(new Vector2(transform.position.x+(Mathf.Sign(ballpos.x-transform.position.x)*.5F), transform.position.y + (Mathf.Sign(ballpos.y - transform.position.y) * .5F)), ballpos) < .5F)
        {
            return true;
        }
        return false;
    }
    void bounce()
    {
        if (Vector2.Distance(ballpos, transform.position) < main.transform.GetChild(0).gameObject.GetComponent<ball>().bdis)
        {
            if (Mathf.Abs(ballpos.x - transform.position.x) < .5F && ballpos.y>transform.position.y)
            {
                temp = 1;
            }
            if (ballpos.x - transform.position.x > .5F && ballpos.y- transform.position.y > .5F)
            {
                temp = 2;
            }
            if (Mathf.Abs(ballpos.y - transform.position.y) < .5F && ballpos.x > transform.position.x)
            {
                temp = 3;
            }
            if (ballpos.x - transform.position.x > .5F && ballpos.y - transform.position.y < -.5F)
            {
                temp = 4;
            }
            if (Mathf.Abs(ballpos.x - transform.position.x) < .5F && ballpos.y < transform.position.y)
            {
                temp = 5;
            }
            if (ballpos.x - transform.position.x < -.5F && ballpos.y - transform.position.y < -.5F)
            {
                temp = 6;
            }
            if (Mathf.Abs(ballpos.y - transform.position.y) < .5F && ballpos.x < transform.position.x)
            {
                temp = 7;
            }
            if (ballpos.x - transform.position.x < -.5F && ballpos.y - transform.position.y > .5F)
            {
                temp = 8;
            }
            main.transform.GetChild(0).GetComponent<ball>().setbounce(gameObject, Vector2.Distance(ballpos, transform.position), temp);
        }
    }
    bool inExpRange(Vector3 pos,Vector3 expos)
    {
        int dis = Mathf.Abs(Mathf.RoundToInt(pos.x)-Mathf.RoundToInt(expos.x))+Mathf.Abs(Mathf.RoundToInt(pos.y)-Mathf.RoundToInt(expos.y));
        if (dis > 2) { return false; }
        return true;
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(main.GetComponent<Main>().rowclear && transform.position.y == -h - 1)
        {
            type = 0;
            main.GetComponent<Main>().score -= 2;
            destroy = true;
        }
        /*if (main.GetComponent<Main>().xplsn.ToArray().Length > 0)
        {
            for(int i=0;i< main.GetComponent<Main>().xplsn.ToArray().Length; i++)
            {
                if (Vector2.Distance(transform.position, (Vector3) main.GetComponent<Main>().xplsn.ToArray().GetValue(i)) < 2)
                {
                    destroy = true;
                }
            }
        }*/
        if (main.GetComponent<Main>().xplsn.Count>0)
        {
            for(int i = 0; i < main.GetComponent<Main>().xplsn.Count; i++)
            {
                if (inExpRange(main.GetComponent<Main>().xplsn.ToArray()[i], transform.position))
                {
                    destroy = true;
                }
            }
        }
        if (main.GetComponent<Main>().abomb.Count > 0)
        {
            for (int i = 0; i < main.GetComponent<Main>().abomb.Count; i++)
            {
                if (Vector2.Distance(main.GetComponent<Main>().abomb.ToArray()[i].transform.position, transform.position) < .9F && main.GetComponent<Main>().abomb.ToArray()[i].transform.position.y>transform.position.y)
                {
                    main.GetComponent<Main>().abomb.ToArray()[i].GetComponent<aBomb>().explode();
                }
            }
        }
        if (main.GetComponent<Main>().xball.Count > 0)
        {
            for (int i = 0; i < main.GetComponent<Main>().xball.Count; i++)
            {
                if (Vector2.Distance(main.GetComponent<Main>().xball.ToArray()[i].transform.position, transform.position)<.7F)
                {
                    main.GetComponent<Main>().xball.ToArray()[i].GetComponent<ExBall>().death();
                }
            }
        }
        if (destroy)
        {
            main.GetComponent<Main>().score++;
            main.GetComponent<Main>().settext2();
            if (set && main.GetComponent<Main>().bottom[Mathf.RoundToInt(transform.position.x) + w]>Mathf.RoundToInt(transform.position.y)) { main.GetComponent<Main>().bottom[Mathf.RoundToInt(transform.position.x) + w] = Mathf.RoundToInt(transform.position.y); }
            if (type ==1)
            {
                GameObject tmp=Instantiate(explosion, transform.position + Vector3.back, transform.rotation);
                tmp.GetComponent<Explosion>().main = main;
            }
            if (type == 2)
            {
                GameObject tmp = Instantiate(airbmb, transform.position + Vector3.back, transform.rotation);
                tmp.GetComponent<aBomb>().main = main;
                tmp.GetComponent<aBomb>().w = w;
                tmp.GetComponent<aBomb>().h = h;
            }
            if (type == 3)
            {
                GameObject tmp = Instantiate(exball, transform.position + Vector3.back, transform.rotation);
                tmp.GetComponent<ExBall>().main = main;
                tmp.GetComponent<ExBall>().w = w;
            }
            Destroy(gameObject);
        }
        gameObject.GetComponent<color>().setvar(color, type, set);
        pos.x = transform.position.x;
        pos.y = transform.position.y;
        if (main.transform.childCount > 0)
        {
            ballpos = main.transform.GetChild(0).position;
            if (Vector2.Distance(ballpos, pos) < 1.5F)
            {
                if (bouncecheck() && !destroy)
                {
                    bounce();
                }
            }
        }
        if (!set) {
            transform.Translate(Vector3.down * .015F, Space.World);
            if (transform.position.y <= main.GetComponent<Main>().bottom[Mathf.RoundToInt(transform.position.x)+w])
            {
                main.GetComponent<Main>().bottom[Mathf.RoundToInt(transform.position.x) + w] += 1;
                transform.Translate(Vector3.down * (transform.position.y-Mathf.RoundToInt(transform.position.y)), Space.World);
                set = true;
            }
        }
        else
        {
            if(transform.position.y> main.GetComponent<Main>().bottom[Mathf.RoundToInt(transform.position.x) + w])
            {
                set = false;
            }
        }
	}
}