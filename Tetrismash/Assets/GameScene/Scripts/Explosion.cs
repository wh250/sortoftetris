using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    public GameObject main;
    public Sprite f0;
    public Sprite f1;
    public Sprite f2;
    public Sprite f3;
    public Sprite f4;
    public Sprite f5;
    public Sprite f6;
    public Sprite f7;
    public Sprite f8;
    public Sprite f9;
    public Sprite f10;
    public Sprite f11;
    public Sprite f12;
    public Sprite f13;
    public Sprite f14;
    public Sprite f15;
    public Sprite f16;
    public Sprite f17;
    public Sprite f18;
    public Sprite f19;
    public Sprite f20;
    public Sprite f21;
    public Sprite f22;
    public Sprite f23;
    public Sprite f24;
    public Sprite f25;
    public Sprite f26;
    public Sprite f27;
    public Sprite f28;
    public Sprite f29;
    public Sprite f30;
    int t = 0;
    void updatesprite()
    {
        switch (t)
        {
            case 0:
                gameObject.GetComponent<SpriteRenderer>().sprite = f0;
                break;
            case 1:
                gameObject.GetComponent<SpriteRenderer>().sprite = f1;
                break;
            case 2:
                gameObject.GetComponent<SpriteRenderer>().sprite = f2;
                break;
            case 3:
                gameObject.GetComponent<SpriteRenderer>().sprite = f3;
                break;
            case 4:
                gameObject.GetComponent<SpriteRenderer>().sprite = f4;
                break;
            case 5:
                gameObject.GetComponent<SpriteRenderer>().sprite = f5;
                break;
            case 6:
                gameObject.GetComponent<SpriteRenderer>().sprite = f6;
                break;
            case 7:
                gameObject.GetComponent<SpriteRenderer>().sprite = f7;
                break;
            case 8:
                gameObject.GetComponent<SpriteRenderer>().sprite = f8;
                break;
            case 9:
                gameObject.GetComponent<SpriteRenderer>().sprite = f9;
                break;
            case 10:
                gameObject.GetComponent<SpriteRenderer>().sprite = f10;
                break;
            case 11:
                gameObject.GetComponent<SpriteRenderer>().sprite = f11;
                break;
            case 12:
                gameObject.GetComponent<SpriteRenderer>().sprite = f12;
                break;
            case 13:
                gameObject.GetComponent<SpriteRenderer>().sprite = f13;
                break;
            case 14:
                gameObject.GetComponent<SpriteRenderer>().sprite = f14;
                break;
            case 15:
                gameObject.GetComponent<SpriteRenderer>().sprite = f15;
                break;
            case 16:
                gameObject.GetComponent<SpriteRenderer>().sprite = f16;
                break;
            case 17:
                gameObject.GetComponent<SpriteRenderer>().sprite = f17;
                break;
            case 18:
                gameObject.GetComponent<SpriteRenderer>().sprite = f18;
                break;
            case 19:
                gameObject.GetComponent<SpriteRenderer>().sprite = f19;
                break;
            case 20:
                gameObject.GetComponent<SpriteRenderer>().sprite = f20;
                break;
            case 21:
                gameObject.GetComponent<SpriteRenderer>().sprite = f21;
                break;
            case 22:
                gameObject.GetComponent<SpriteRenderer>().sprite = f22;
                break;
            case 23:
                gameObject.GetComponent<SpriteRenderer>().sprite = f23;
                break;
            case 24:
                gameObject.GetComponent<SpriteRenderer>().sprite = f24;
                break;
            case 25:
                gameObject.GetComponent<SpriteRenderer>().sprite = f25;
                break;
            case 26:
                gameObject.GetComponent<SpriteRenderer>().sprite = f26;
                break;
            case 27:
                gameObject.GetComponent<SpriteRenderer>().sprite = f27;
                break;
            case 28:
                gameObject.GetComponent<SpriteRenderer>().sprite = f28;
                break;
            case 29:
                gameObject.GetComponent<SpriteRenderer>().sprite = f29;
                break;
            case 30:
                gameObject.GetComponent<SpriteRenderer>().sprite = f30;
                break;
            default:
                gameObject.GetComponent<SpriteRenderer>().sprite = null;
                break;
        }
        gameObject.GetComponent<SpriteRenderer>().transform.localScale = Vector3.one * 100 / 32;
    }
    // Use this for initialization
    void Start () {
        main.GetComponent<Main>().xplsn.Add(transform.position);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        t++;
        updatesprite();
        if (t > 30)
        {
            main.GetComponent<Main>().xplsn.Remove(transform.position);
            Destroy(gameObject);
        }
	}
}
