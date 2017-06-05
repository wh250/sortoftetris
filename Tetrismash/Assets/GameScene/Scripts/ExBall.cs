using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExBall : MonoBehaviour {
    public GameObject main;
    public int w;
    public bool hit = false;
    public void death()
    {
        main.GetComponent<Main>().xball.Remove(gameObject);
        transform.GetChild(0).GetComponent<Oscillate>().death();
        transform.GetChild(0).parent = null;
        Destroy(gameObject);
    }

	// Use this for initialization
	void Start () {
        main.GetComponent<Main>().xball.Add(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        if(main.GetComponent<Main>().bottom[Mathf.RoundToInt(transform.position.x) + w] >= Mathf.Round(transform.position.y))
        {
            death();
        }
        if (main.transform.childCount > 0)
        {
            if (Vector2.Distance(main.transform.GetChild(0).position, transform.position) < .7F)
            {
                main.GetComponent<Main>().ballnum += 1;
                main.GetComponent<Main>().settext();
                death();
            }
        }
        if (hit) { death(); }
	}
}
