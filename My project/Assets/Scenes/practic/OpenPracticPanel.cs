using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPracticPanel : MonoBehaviour
{
public GameObject panel;
    // Start is called before the first frame update
    public void TogglePanelPracticVisibility()
    {
        if (panel != null)
        {
            panel.SetActive(!panel.activeSelf);
        }

    }
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
