using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUI : MonoBehaviour {
    public GameObject menu;
    public bool isShowing;
    public GameObject menu2;
    public bool isShowing2;
    // Use this for initialization
    void Start () {
        isShowing = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.O))
        {
            isShowing = !isShowing;
            menu.SetActive(isShowing);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            isShowing2 = !isShowing2;
            menu2.SetActive(isShowing2);
        }
    }
}
