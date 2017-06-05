using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Menu : MonoBehaviour {
    float x;
    float y;
    public GameObject curr;
	// Use this for initialization
	void Start () {
        x = Screen.width;
        y = Screen.height;
        //Main panel size and buttons
        curr = transform.GetChild(1).gameObject;
        curr.GetComponent<RectTransform>().sizeDelta = new Vector2(-Screen.width*.4F, -Screen.height*.4F);
        curr.GetComponent<RectTransform>().localPosition = new Vector2(0, -Screen.height*.1F);
        curr = transform.GetChild(1).GetChild(0).gameObject;
        curr.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width * .5F, Screen.height * .1F);
        curr.GetComponent<RectTransform>().localPosition = new Vector2(0, Screen.height*.2F);
        curr.transform.GetChild(0).gameObject.GetComponent<Text>().fontSize = (int) (Screen.dpi * .1F);
        curr = transform.GetChild(1).GetChild(1).gameObject;
        curr.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width * .5F, Screen.height * .1F);
        curr.GetComponent<RectTransform>().localPosition = new Vector2(0, Screen.height * .1F);
        curr.transform.GetChild(0).gameObject.GetComponent<Text>().fontSize = (int)(Screen.dpi * .1F);
        curr = transform.GetChild(1).GetChild(2).gameObject;
        curr.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width * .5F, Screen.height * .1F);
        curr.GetComponent<RectTransform>().localPosition = new Vector2(0, Screen.height * 0F);
        curr.transform.GetChild(0).gameObject.GetComponent<Text>().fontSize = (int)(Screen.dpi * .1F);
        curr = transform.GetChild(1).GetChild(3).gameObject;
        curr.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width * .5F, Screen.height * .1F);
        curr.GetComponent<RectTransform>().localPosition = new Vector2(0, Screen.height * -.1F);
        curr.transform.GetChild(0).gameObject.GetComponent<Text>().fontSize = (int)(Screen.dpi * .1F);
        curr = transform.GetChild(1).GetChild(4).gameObject;
        curr.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width * .5F, Screen.height * .1F);
        curr.GetComponent<RectTransform>().localPosition = new Vector2(0, Screen.height * -.2F);
        curr.transform.GetChild(0).gameObject.GetComponent<Text>().fontSize = (int)(Screen.dpi * .1F);
        //Help Panel
        curr = transform.GetChild(2).gameObject;
        curr.GetComponent<RectTransform>().sizeDelta = new Vector2(-Screen.width * .4F, -Screen.height * .4F);
        curr.GetComponent<RectTransform>().localPosition = new Vector2(0, -Screen.height * .1F);
        curr = transform.GetChild(2).GetChild(0).gameObject;
        curr.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width * .2F, Screen.height * .1F);
        curr.GetComponent<RectTransform>().localPosition = new Vector2(0, Screen.height * -.2F);
        curr.transform.GetChild(0).gameObject.GetComponent<Text>().fontSize = (int)(Screen.dpi * .1F);
        curr = transform.GetChild(2).GetChild(1).gameObject;
        curr.GetComponent<RectTransform>().sizeDelta = new Vector2(-Screen.width * .1F, -Screen.height * .2F);
        curr.GetComponent<RectTransform>().localPosition = new Vector2(0, Screen.height * .05F);
        curr.GetComponent<Text>().fontSize = (int)(Screen.dpi * .1F);
        //Settings Panel
        curr = transform.GetChild(3).gameObject;
        curr.GetComponent<RectTransform>().sizeDelta = new Vector2(-Screen.width * .4F, -Screen.height * .4F);
        curr.GetComponent<RectTransform>().localPosition = new Vector2(0, -Screen.height * .1F);
        //Music Panel
        curr = transform.GetChild(4).gameObject;
        curr.GetComponent<RectTransform>().sizeDelta = new Vector2(-Screen.width * .4F, -Screen.height * .4F);
        curr.GetComponent<RectTransform>().localPosition = new Vector2(0, -Screen.height * .1F);
        //Credits Panel
        curr = transform.GetChild(5).gameObject;
        curr.GetComponent<RectTransform>().sizeDelta = new Vector2(-Screen.width * .4F, -Screen.height * .4F);
        curr.GetComponent<RectTransform>().localPosition = new Vector2(0, -Screen.height * .1F);
        curr = transform.GetChild(5).GetChild(0).gameObject;
        curr.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width * .2F, Screen.height * .1F);
        curr.GetComponent<RectTransform>().localPosition = new Vector2(0, Screen.height * -.2F);
        curr.transform.GetChild(0).gameObject.GetComponent<Text>().fontSize = (int)(Screen.dpi * .1F);
        curr = transform.GetChild(5).GetChild(1).gameObject;
        curr.GetComponent<RectTransform>().sizeDelta = new Vector2(-Screen.width * .1F, -Screen.height * .2F);
        curr.GetComponent<RectTransform>().localPosition = new Vector2(0, Screen.height * .05F);
        curr.GetComponent<Text>().fontSize = (int)(Screen.dpi * .1F);
    }
}
