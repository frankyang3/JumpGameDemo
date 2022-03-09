using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TileStats : MonoBehaviour
{
    public string owner = "a";
    public int value = 1;

    SpriteRenderer sprite;
    public TextMeshPro valueText;

    public GameObject controller;
    public GameObject self;

    
    
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        float rng = Random.Range(1,4);
        int valueRng = Random.Range(1,4);
        if(rng == 1){
            owner = "a";
        }else if (rng == 2) {
            owner = "b"; 
        }else{
            owner = "na";
            value = valueRng;
        }

        

        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.GetComponent<Controller>().selected == self){
            sprite.color = new Color(50,50,0,1);
        }else if (owner == "a"){
            sprite.color = new Color (0, 0, 255, 1); 
        }else if (owner == "b"){
            sprite.color = new Color (255, 0, 0, 1);
        }else{
            sprite.color = new Color (255, 255, 255, 1); 
        }
        valueText.text = value.ToString();
    }

    void OnMouseDown()
    {
        //GameObject.Find("Unclaim").GetComponentInChildren<Text>().text = "la di da";
        //print("CLICKED ME");
        controller.GetComponent<Controller>().Select(self);
    }
}
