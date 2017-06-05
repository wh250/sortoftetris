using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aBomb : MonoBehaviour {
    public GameObject main;
    public GameObject explosion;
    public int w;
    public int h;
    public void explode()
    {
        GameObject tmp = Instantiate(explosion, transform.position + Vector3.back, transform.rotation);
        tmp.GetComponent<Explosion>().main = main;
        main.GetComponent<Main>().abomb.Remove(gameObject);
        Destroy(gameObject);
    }
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<SpriteRenderer>().transform.localScale = Vector3.one * 100 / 32;
        main.GetComponent<Main>().abomb.Add(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.down * .025F, Space.World);
        if (transform.position.y <= -h)
        {
            explode();
        }
    }
}
