using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color : MonoBehaviour {
    int colour=0;
    int type=0;
    bool set=false;
    public void setvar(int c, int t, bool s)
    {
        colour = c;
        type = t;
        set = s;
    }
    public Sprite grey;
    public Sprite pink;
    public Sprite red;
    public Sprite orange;
    public Sprite yellow;
    public Sprite green;
    public Sprite turquoise;
    public Sprite blue;
    public Sprite purple;
    public Sprite bombgrey;
    public Sprite bombpink;
    public Sprite bombred;
    public Sprite bomborange;
    public Sprite bombyellow;
    public Sprite bombgreen;
    public Sprite bombturquoise;
    public Sprite bombblue;
    public Sprite bombpurple;
    public Sprite agrey;
    public Sprite apink;
    public Sprite ared;
    public Sprite aorange;
    public Sprite ayellow;
    public Sprite agreen;
    public Sprite aturquoise;
    public Sprite ablue;
    public Sprite apurple;
    public Sprite ballgrey;
    public Sprite ballpink;
    public Sprite ballred;
    public Sprite ballorange;
    public Sprite ballyellow;
    public Sprite ballgreen;
    public Sprite ballturquoise;
    public Sprite ballblue;
    public Sprite ballpurple;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch (type)
        {
            case 0:
                if (set)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = grey;
                }
                else
                {
                    switch (colour)
                    {
                        case 1:
                            gameObject.GetComponent<SpriteRenderer>().sprite = pink;
                            break;
                        case 2:
                            gameObject.GetComponent<SpriteRenderer>().sprite = red;
                            break;
                        case 3:
                            gameObject.GetComponent<SpriteRenderer>().sprite = orange;
                            break;
                        case 4:
                            gameObject.GetComponent<SpriteRenderer>().sprite = yellow;
                            break;
                        case 5:
                            gameObject.GetComponent<SpriteRenderer>().sprite = green;
                            break;
                        case 6:
                            gameObject.GetComponent<SpriteRenderer>().sprite = turquoise;
                            break;
                        case 7:
                            gameObject.GetComponent<SpriteRenderer>().sprite = blue;
                            break;
                        case 8:
                            gameObject.GetComponent<SpriteRenderer>().sprite = purple;
                            break;
                        default:
                            break;
                    }
                }
                break;
            case 1:
                if (set)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = bombgrey;
                }
                else
                {
                    switch (colour)
                    {
                        case 1:
                            gameObject.GetComponent<SpriteRenderer>().sprite = bombpink;
                            break;
                        case 2:
                            gameObject.GetComponent<SpriteRenderer>().sprite = bombred;
                            break;
                        case 3:
                            gameObject.GetComponent<SpriteRenderer>().sprite = bomborange;
                            break;
                        case 4:
                            gameObject.GetComponent<SpriteRenderer>().sprite = bombyellow;
                            break;
                        case 5:
                            gameObject.GetComponent<SpriteRenderer>().sprite = bombgreen;
                            break;
                        case 6:
                            gameObject.GetComponent<SpriteRenderer>().sprite = bombturquoise;
                            break;
                        case 7:
                            gameObject.GetComponent<SpriteRenderer>().sprite = bombblue;
                            break;
                        case 8:
                            gameObject.GetComponent<SpriteRenderer>().sprite = bombpurple;
                            break;
                        default:
                            break;
                    }
                }
                break;
            case 2:
                if (set)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = agrey;
                }
                else
                {
                    switch (colour)
                    {
                        case 1:
                            gameObject.GetComponent<SpriteRenderer>().sprite = apink;
                            break;
                        case 2:
                            gameObject.GetComponent<SpriteRenderer>().sprite = ared;
                            break;
                        case 3:
                            gameObject.GetComponent<SpriteRenderer>().sprite = aorange;
                            break;
                        case 4:
                            gameObject.GetComponent<SpriteRenderer>().sprite = ayellow;
                            break;
                        case 5:
                            gameObject.GetComponent<SpriteRenderer>().sprite = agreen;
                            break;
                        case 6:
                            gameObject.GetComponent<SpriteRenderer>().sprite = aturquoise;
                            break;
                        case 7:
                            gameObject.GetComponent<SpriteRenderer>().sprite = ablue;
                            break;
                        case 8:
                            gameObject.GetComponent<SpriteRenderer>().sprite = apurple;
                            break;
                        default:
                            break;
                    }
                }
                break;
            case 3:
                if (set)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = ballgrey;
                }
                else
                {
                    switch (colour)
                    {
                        case 1:
                            gameObject.GetComponent<SpriteRenderer>().sprite = ballpink;
                            break;
                        case 2:
                            gameObject.GetComponent<SpriteRenderer>().sprite = ballred;
                            break;
                        case 3:
                            gameObject.GetComponent<SpriteRenderer>().sprite = ballorange;
                            break;
                        case 4:
                            gameObject.GetComponent<SpriteRenderer>().sprite = ballyellow;
                            break;
                        case 5:
                            gameObject.GetComponent<SpriteRenderer>().sprite = ballgreen;
                            break;
                        case 6:
                            gameObject.GetComponent<SpriteRenderer>().sprite = ballturquoise;
                            break;
                        case 7:
                            gameObject.GetComponent<SpriteRenderer>().sprite = ballblue;
                            break;
                        case 8:
                            gameObject.GetComponent<SpriteRenderer>().sprite = ballpurple;
                            break;
                        default:
                            break;
                    }
                }
                break;
            default:
                break;
        }
        gameObject.GetComponent<SpriteRenderer>().transform.localScale = Vector3.one * 100/32;
    }
}
