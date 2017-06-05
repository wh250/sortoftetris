using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Main : MonoBehaviour {
    //public GameObject countball;
    public GameObject wall;
    public GameObject clwall;
    public GameObject clbottom;
    public int score = 0;
    public GameObject textbox;
    public GameObject textbox2;
    public int ballnum;
    public GameObject touch;
    public GameObject block;
    public GameObject ball;
    GameObject temp;
    GameObject cball;
    Vector3 mousepos;
    int a = 0;
    public int b = 0;
    int t = 0;
    public bool release = false;
    public float y;
    public float x;
    int w;
    int h;
    public int[] bottom;
    public List<Vector3> xplsn;
    public List<GameObject> xball;
    public List<GameObject> abomb;
    public bool rowclear = false;
    public bool lose = false;

    void makewall(int x, int y, int type)
    {
        GameObject tmp;
        if (type == 0) { tmp = Instantiate(wall, new Vector3(x, y, 0), Quaternion.identity); }
        else
        {
            if (type == 1) { tmp = Instantiate(clwall, new Vector3(x, y, 0), Quaternion.identity); }
            else { tmp = Instantiate(clbottom, new Vector3(x, y, 0), Quaternion.identity); }
        }
        tmp.transform.localScale = Vector3.one * 100 / 32;
    }

    void makeblock(int x, int y, int color)
    {
        int type = Mathf.CeilToInt(Random.value * 99.999F + .001F);
        if (type < 3)
        {
            type = 3;
        }
        else
        {
            if (type < 6)
            {
                type = 2;
            }
            else
            {
                if (type < 11)
                {
                    type = 1;
                }
                else
                {
                    type = 0;
                }
            }
        }
        GameObject temp = Instantiate(block, new Vector3(x, y, 5), transform.rotation);
        temp.GetComponent<Block>().set = false;
        temp.GetComponent<Block>().color = color;
        temp.GetComponent<Block>().type = type;
        temp.GetComponent<Block>().main = gameObject;
        temp.GetComponent<Block>().w = w;
        temp.GetComponent<Block>().h = h;
    }

    void genblocks(int w, int h)
    {
        int ww = 2 * w + 1;
        int shape = Mathf.CeilToInt(Random.value * 6.999F + .001F);
        int offset = 0;
        int color = Mathf.CeilToInt(Random.value * 7.999F + .001F);
        switch (shape)
        {
            case 1:
                offset = Mathf.CeilToInt((Random.value * (ww - 1 - .001F)) + .001F);
                makeblock(offset - w - 1, h + 3, color);
                makeblock(offset - w, h + 3, color);
                makeblock(offset - w, h + 4, color);
                makeblock(offset - w - 1, h + 4, color);
                break;
            case 2:
                if (Random.value > .5F)
                {
                    offset = Mathf.CeilToInt((Random.value * (ww - 3 - .001F)) + .001F);
                    makeblock(offset - w - 1, h + 3, color);
                    makeblock(offset - w, h + 3, color);
                    makeblock(offset - w + 1, h + 3, color);
                    makeblock(offset - w + 2, h + 3, color);
                }
                else
                {
                    offset = Mathf.CeilToInt((Random.value * (ww - .001F)) + .001F);
                    makeblock(offset - w - 1, h + 3, color);
                    makeblock(offset - w - 1, h + 4, color);
                    makeblock(offset - w - 1, h + 5, color);
                    makeblock(offset - w - 1, h + 6, color);
                }
                break;
            case 3:
                if (Random.value > .5F)
                {
                    offset = Mathf.CeilToInt((Random.value * (ww - 1 - .001F)) + .001F);
                    makeblock(offset - w - 1, h + 3, color);
                    makeblock(offset - w - 1, h + 4, color);
                    makeblock(offset - w, h + 4, color);
                    makeblock(offset - w, h + 5, color);
                }
                else
                {
                    offset = Mathf.CeilToInt((Random.value * (ww - 2 - .001F)) + .001F);
                    makeblock(offset - w - 1, h + 4, color);
                    makeblock(offset - w, h + 4, color);
                    makeblock(offset - w, h + 3, color);
                    makeblock(offset - w + 1, h + 3, color);
                }
                break;
            case 4:
                if (Random.value > .5F)
                {
                    offset = Mathf.CeilToInt((Random.value * (ww - 1 - .001F)) + .001F);
                    makeblock(offset - w - 1, h + 5, color);
                    makeblock(offset - w - 1, h + 4, color);
                    makeblock(offset - w, h + 4, color);
                    makeblock(offset - w, h + 3, color);
                }
                else
                {
                    offset = Mathf.CeilToInt((Random.value * (ww - 2 - .001F)) + .001F);
                    makeblock(offset - w - 1, h + 3, color);
                    makeblock(offset - w, h + 3, color);
                    makeblock(offset - w, h + 4, color);
                    makeblock(offset - w + 1, h + 4, color);
                }
                break;
            case 5:
                if (Random.value > .5F)
                {
                    offset = Mathf.CeilToInt((Random.value * (ww - 1 - .001F)) + .001F);
                    if (Random.value > .5F)
                    {
                        makeblock(offset - w - 1, h + 3, color);
                        makeblock(offset - w - 1, h + 4, color);
                        makeblock(offset - w - 1, h + 5, color);
                        makeblock(offset - w, h + 4, color);
                    }
                    else
                    {
                        makeblock(offset - w, h + 3, color);
                        makeblock(offset - w, h + 4, color);
                        makeblock(offset - w, h + 5, color);
                        makeblock(offset - w - 1, h + 4, color);
                    }
                }
                else
                {
                    offset = Mathf.CeilToInt((Random.value * (ww - 2 - .001F)) + .001F);
                    if (Random.value > .5F)
                    {
                        makeblock(offset - w - 1, h + 3, color);
                        makeblock(offset - w, h + 3, color);
                        makeblock(offset - w + 1, h + 3, color);
                        makeblock(offset - w, h + 4, color);
                    }
                    else
                    {
                        makeblock(offset - w - 1, h + 4, color);
                        makeblock(offset - w, h + 4, color);
                        makeblock(offset - w + 1, h + 4, color);
                        makeblock(offset - w, h + 3, color);
                    }
                }
                break;
            case 6:
                if (Random.value > .5F)
                {
                    offset = Mathf.CeilToInt((Random.value * (ww - 1 - .001F)) + .001F);
                    if (Random.value > .5F)
                    {
                        makeblock(offset - w - 1, h + 3, color);
                        makeblock(offset - w - 1, h + 4, color);
                        makeblock(offset - w - 1, h + 5, color);
                        makeblock(offset - w, h + 5, color);
                    }
                    else
                    {
                        makeblock(offset - w, h + 3, color);
                        makeblock(offset - w, h + 4, color);
                        makeblock(offset - w, h + 5, color);
                        makeblock(offset - w - 1, h + 3, color);
                    }
                }
                else
                {
                    offset = Mathf.CeilToInt((Random.value * (ww - 2 - .001F)) + .001F);
                    if (Random.value > .5F)
                    {
                        makeblock(offset - w - 1, h + 3, color);
                        makeblock(offset - w, h + 4, color);
                        makeblock(offset - w - 1, h + 4, color);
                        makeblock(offset - w + 1, h + 4, color);
                    }
                    else
                    {
                        makeblock(offset - w - 1, h + 3, color);
                        makeblock(offset - w, h + 3, color);
                        makeblock(offset - w + 1, h + 3, color);
                        makeblock(offset - w - 1, h + 4, color);
                    }
                }
                break;
            case 7:
                if (Random.value > .5F)
                {
                    offset = Mathf.CeilToInt((Random.value * (ww - 1 - .001F)) + .001F);
                    if (Random.value > .5F)
                    {
                        makeblock(offset - w - 1, h + 3, color);
                        makeblock(offset - w - 1, h + 4, color);
                        makeblock(offset - w - 1, h + 5, color);
                        makeblock(offset - w, h + 3, color);
                    }
                    else
                    {
                        makeblock(offset - w, h + 3, color);
                        makeblock(offset - w, h + 4, color);
                        makeblock(offset - w, h + 5, color);
                        makeblock(offset - w - 1, h + 5, color);
                    }
                }
                else
                {
                    offset = Mathf.CeilToInt((Random.value * (ww - 2 - .001F)) + .001F);
                    if (Random.value > .5F)
                    {
                        makeblock(offset - w - 1, h + 4, color);
                        makeblock(offset - w, h + 4, color);
                        makeblock(offset - w + 1, h + 4, color);
                        makeblock(offset - w - 1, h + 3, color);
                    }
                    else
                    {
                        makeblock(offset - w - 1, h + 3, color);
                        makeblock(offset - w, h + 3, color);
                        makeblock(offset - w + 1, h + 3, color);
                        makeblock(offset - w + 1, h + 4, color);
                    }
                }
                break;
            default:
                break;
        }
    }

    public void settext()
    {
        int offset;
        if (ballnum > 0){ offset = Mathf.FloorToInt(Mathf.Log10(ballnum)); }
        else { offset = 0; }
        textbox.GetComponent<RectTransform>().localPosition = new Vector3(Screen.width * .5F - Screen.dpi * (.5F + offset * .1F), Screen.height * .5F - Screen.dpi * .2F, 0);
        textbox.GetComponent<Text>().text = "\u25CB x"+ballnum.ToString();
    }

    public void settext2()
    {
        textbox2.GetComponent<Text>().text = "Score: " + score.ToString();
    }

    bool maxed()
    {
        for (int i = 0; i < 2 * w + 1; i++)
        {
            if (bottom[i] >= h + 1) { return true; }
        }
        return false;
    }

    bool filled()
    {
        for(int i = 0; i < 2 * w + 1; i++)
        {
            if (bottom[i] == -h - 1) { return false; }
        }
        return true;
    }

    // Use this for initialization
    void Start () {
        ballnum = 5;
        settext();
        settext2();
        textbox.GetComponent<Text>().font=Font.CreateDynamicFontFromOSFont(textbox.GetComponent<Text>().font.name,(int)Screen.dpi);
        textbox.GetComponent<Text>().fontSize = (int)(Screen.dpi * .2F);
        textbox.GetComponent<RectTransform>().localPosition = new Vector3(Screen.width * .5F - Screen.dpi * .5F, Screen.height * .5F - Screen.dpi * .2F, 0);
        textbox2.GetComponent<Text>().font = Font.CreateDynamicFontFromOSFont(textbox.GetComponent<Text>().font.name, (int)Screen.dpi);
        textbox2.GetComponent<Text>().fontSize = (int)(Screen.dpi * .2F);
        textbox2.GetComponent<RectTransform>().localPosition = new Vector3(-Screen.width * .5F + Screen.dpi*.3F, Screen.height * .5F - Screen.dpi * .2F, 0);
        y = Screen.height;
        x = Screen.width;
        Camera.main.aspect = x / y;
        Camera.main.orthographicSize =4* Screen.width / Screen.dpi;
        w = Mathf.FloorToInt(2* Screen.width / Screen.dpi);
        h = Mathf.FloorToInt(2* Screen.height / Screen.dpi);
        for(int i = -h-1; i < h+2; i++)
        {
            makewall(-w - 1, i, 0);
            makewall(w + 1, i, 0);
        }
        for (int i = -w; i < w+1; i++)
        {
            makewall(i, -h-1, 2);
            makewall(i, h+1, 1);
        }
        //countball.transform.position = new Vector3(w-1,h-.3F,0);
        bottom = new int[2 * w + 1];
        for(int i = 0; i < 2 * w + 1; i++)
        {
            bottom[i] = -h-1;
        }
    }

	// Update is called once per frame
	void Update () {
        if(maxed() || ballnum < 0)
        {
            lose = true;
        }
        if (lose)
        {
            Time.timeScale = .05F;
        }
        rowclear = filled();
        t++;
        if (t % 600 == 0)
        {
            genblocks(w, h);
            Time.timeScale *= 1.007F;
        }
        if (b > 0) { b--; }
        /*if (transform.childCount > 0 && release || b > 0)
        {
            if (Input.GetMouseButton(0))
            {
                for (int i = 0; i < 1; i++)
                {
                    mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    mousepos.z = 0;
                    temp = Instantiate(touch, mousepos, transform.rotation);
                    temp.GetComponent<Touch>().main = gameObject;
                }
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                a = 3;
                mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousepos.z = 0;
                if (transform.childCount == 0)
                {
                    Instantiate(ball, mousepos, transform.rotation, transform);
                }
                else
                {
                    transform.GetChild(0).position = mousepos;
                }
            }
            else
            {
                a--;
                if (a == 0)
                {
                    release = true;
                    transform.GetChild(0).gameObject.GetComponent<ball>().released = true;
                    transform.GetChild(0).gameObject.GetComponent<ball>().w = w;
                    transform.GetChild(0).gameObject.GetComponent<ball>().h = h;
                }
            }
        }*/
        
        if (transform.childCount > 0 && release || b>0)
        {
            if (Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    mousepos = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
                    mousepos.z = 0;
                    temp=Instantiate(touch, mousepos, transform.rotation);
                    temp.GetComponent<Touch>().main = gameObject;
                }
            }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                a = 3;
                mousepos = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
                mousepos.z = 0;
                if (transform.childCount == 0)
                {
                    Instantiate(ball, mousepos, transform.rotation, transform);
                }
                else
                {
                    transform.GetChild(0).position = mousepos;
                }
            }
            else
            {
                a--;
                if (a == 0)
                {
                    release = true;
                    transform.GetChild(0).gameObject.GetComponent<ball>().released = true;
                    transform.GetChild(0).gameObject.GetComponent<ball>().w = w;
                    transform.GetChild(0).gameObject.GetComponent<ball>().h = h;
                }
            }
        }
    }
}