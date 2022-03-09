using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideInstructions : MonoBehaviour
{

    public GameObject instructions;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i"))
        { 
            instructions.SetActive(!instructions.activeInHierarchy);
        }

        if(Input.GetKeyDown(KeyCode.Q)){
           Application.Quit();
        }
    }
}
