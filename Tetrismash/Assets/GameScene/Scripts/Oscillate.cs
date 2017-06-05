using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillate : MonoBehaviour {
    public float max;
    public float min;
    int t=0;
    float spd = .1F;
    bool dead = false;
    public void death()
    {
        t = 0;
        min -= .2F;
        spd -= .06F;
        max += 1F;
        dead = true;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(dead && t >= 13) { Destroy(gameObject); }
        t++;
        transform.localScale = Vector3.one*(min+(max-min)*Mathf.Sin(t*spd));
	}
}
