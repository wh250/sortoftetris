using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class MusicSelector : MonoBehaviour {
    string path;
    List<string> files;
	// Use this for initialization
	void Start () {
        transform.GetChild(0).GetComponent<Text>().text += files.ToArray().Length.ToString();
        path = Directory.GetCurrentDirectory();
		for(int i=0;i< Directory.GetDirectories(path).Length;i++)
        {
            files.Add(Directory.GetDirectories(path)[i]);
            
        }
        transform.GetChild(0).GetComponent<Text>().text += files.ToArray().Length.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
