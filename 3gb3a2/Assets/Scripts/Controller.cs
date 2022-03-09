using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{

    public string turn = "a";

    public bool p1win = false;
    public bool p2win = false;
    public int p1Res = 10;
    public int p2Res = 10;

    public GameObject selected;

    public Button unclaim;
    public Button claim;
    public Button upgrade;
    public Button end;
    public Text p1ResTxt;
    public Text p2ResTxt;
    public Text curTurn;
    public GameObject winMsg;

    //music stuff
    public GameObject musicManager;
    private AudioSource source;
    public AudioClip clickFX;
    public AudioClip endFX;

	
    
    // Start is called before the first frame update
    void Start()
    {
        source = musicManager.GetComponent<AudioSource>();
        winMsg.SetActive(false);
        float rng = Random.Range(1,3);
        if(rng == 1){
            turn = "a";
            curTurn.text =  "Current Turn: Player 1";
        }else{
            turn = "b";
            curTurn.text =  "Current Turn: Player 2";
        }
        
        Button unclaimB = unclaim.GetComponent<Button>();
		unclaimB.onClick.AddListener(Unclaim);
        Button claimB = claim.GetComponent<Button>();
		claimB.onClick.AddListener(Claim);
        Button upgradeB = upgrade.GetComponent<Button>();
		upgradeB.onClick.AddListener(Upgrade);
        Button endB = end.GetComponent<Button>();
		endB.onClick.AddListener(End);
    }

    void Unclaim(){
		if(turn == "a"){
            if(p1Res >=5){
                p1Res = p1Res - 5;
                selected.GetComponent<TileStats>().owner = "na";
            }
        }else{
            if(p2Res >=5){
                p2Res = p2Res - 5;
                selected.GetComponent<TileStats>().owner = "na";
            }
        }
        source.PlayOneShot(clickFX, 0.7f);
	}

    void Claim(){
        print("HERE");
		if(turn == "a"){
            if(p1Res >=3){
                p1Res = p1Res - 3;
                selected.GetComponent<TileStats>().owner = "a";
            }
        }else{
            if(p2Res >=3){
                p2Res = p2Res - 3;
                selected.GetComponent<TileStats>().owner = "b";
            }
        }
        source.PlayOneShot(clickFX, 0.7f);
	}

    void Upgrade(){
        print("UPGRADE");
		if(turn == "a"){
            if(p1Res >=1){
                p1Res = p1Res - 1;
                selected.GetComponent<TileStats>().value += 1;
            }
        }else{
            if(p2Res >=1){
                p2Res = p2Res - 1;
                selected.GetComponent<TileStats>().value +=1;
            }
        }
        source.PlayOneShot(clickFX, 0.7f);
	}

    void End(){

        var tiles = GameObject.FindGameObjectsWithTag("isTile");
		if(turn == "a"){
            turn = "b";
            

            foreach (var tile in tiles) {
                if(tile.GetComponent<TileStats>().owner == "b"){

                    p2Res += tile.GetComponent<TileStats>().value;
                }
            }

            //check win
            bool p1w = true;
            foreach (var tile in tiles) {
                if(tile.GetComponent<TileStats>().owner == "a"){
                    p1w = false;
                }
            }
            if(p1w){
                p1win = true;
            }

            curTurn.text = "Current Turn: Player 2";
        }else{
            turn = "a";
            foreach (var tile in tiles) {
                if(tile.GetComponent<TileStats>().owner == "a"){

                    p1Res += tile.GetComponent<TileStats>().value;
                }
            }

            //check win
            bool p2w = true;
            foreach (var tile in tiles) {
                if(tile.GetComponent<TileStats>().owner == "b"){
                    p2w = false;
                }
            }
            if(p2w){
                p2win = true;
            }

            curTurn.text = "Current Turn: Player 1";
        }


        source.PlayOneShot(endFX, 0.7f);
	}

    // Update is called once per frame
    void Update()
    {
        p1ResTxt.text = "Resources:" + p1Res.ToString();
        p2ResTxt.text = "Resources:" + p2Res.ToString();

        if(p1win){
            winMsg.GetComponent<Text>().text = "PLAYER 1 WIN";
            winMsg.SetActive(true);
        }

        if(p2win){
            winMsg.GetComponent<Text>().text = "PLAYER 2 WIN";
            winMsg.SetActive(true);
        }
    
    }

    public void Select(GameObject g){
        selected = g;
        //selected.GetComponent<SpriteRenderer>().color = new Color (50, 50, 50, 1); 
    }




}
