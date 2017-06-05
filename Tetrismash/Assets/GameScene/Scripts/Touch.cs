using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour {
    public GameObject main;
    int t=0;
    Vector3 temp;
    Vector2 pos;
    Vector2 ballpos;
    Vector2 angle;
    Vector2 balldir;
    float force;
	// Use this for initialization
	void Start () {
        temp.x = .1F;
        temp.y = .1F;
        temp.z = 1;
        transform.localScale = temp;
    }
	
	// Update is called once per frame
	void Update () {
        t++;
        temp.x +=.1F;
        temp.y +=.1F;
        transform.localScale = temp;
        if (main.transform.childCount > 0)
        {
            pos.x = transform.position.x;
            pos.y = transform.position.y;
            ballpos.x = main.transform.GetChild(0).position.x;
            ballpos.y = main.transform.GetChild(0).position.y;
            if (Vector2.Distance(ballpos, pos) < temp.x)
            {
                force = .3F * (temp.x - Vector2.Distance(ballpos, pos));
                angle.x = ballpos.x - pos.x;
                angle.y = ballpos.y - pos.y;
                balldir.x = main.transform.GetChild(0).gameObject.GetComponent<ball>().dir.x+force*angle.x;
                balldir.y = main.transform.GetChild(0).gameObject.GetComponent<ball>().dir.y+force*angle.y;
                main.transform.GetChild(0).gameObject.GetComponent<ball>().dir = Vector3.Normalize(balldir);
                //balldir = balldir - 2 * Vector2.Dot(angle, balldir) * angle;
                /*if (balldir != Vector2.zero)
                {
                    main.transform.GetChild(0).gameObject.GetComponent<ball>().dir.y = balldir.y;
                    main.transform.GetChild(0).gameObject.GetComponent<ball>().dir.x = balldir.x;
                }*/
            }
            if (Vector2.Distance(ballpos, pos) < .5F && t==1)
            {
                main.transform.GetChild(0).gameObject.GetComponent<ball>().exp += 10;
            }
        }
        if (t == 15)
        {
            Destroy(gameObject);
        }
	}
}
