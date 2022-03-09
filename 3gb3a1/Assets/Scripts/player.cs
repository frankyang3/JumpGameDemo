using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject winMsg;
    Rigidbody2D rb;
    int state = 0; //0 is stable, 1 is moving
    int jumpPow = 6;
    public Vector2 jumpDir = new Vector2(0,4);
    public GameObject musicManager;
    private AudioSource source;
    public AudioClip winFX;
    public AudioClip jumpFX;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody2D> ();
        jumpDir = new Vector2(0,jumpPow);
        winMsg.SetActive(false);
        source = musicManager.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.R)){
            rb.velocity = new Vector2(0,0);
            transform.position = new Vector2(-0, 0);
            winMsg.SetActive(false);
        }
        //transform.Translate(playerSpeed * Time.deltaTime, 0f, 0f);  //makes player run
        if(Input.GetKeyDown(KeyCode.Q)){
           Application.Quit();
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && state == 0)  //makes player jump
        {
            rb.velocity = new Vector2(0,0);
            source.PlayOneShot(jumpFX, 0.7f);
            GetComponent<Rigidbody2D>().AddForce(jumpDir, ForceMode2D.Impulse);
            state = 1;
        }
    
    }

    private void OnCollisionStay2D(Collision2D collision){
        
        GameObject other = collision.gameObject;

        if (other.CompareTag("wallUp")) {
            state = 0;
            jumpDir = new Vector2(0,jumpPow);
        }
        if (other.CompareTag("wallDown")) {
            state = 0;
            jumpDir = new Vector2(0,-jumpPow);
         }
         if (other.CompareTag("wallRight")) {
            state = 0;
            jumpDir = new Vector2(jumpPow,0);
         }
         if (other.CompareTag("wallLeft")) {
            state = 0;
            jumpDir = new Vector2(-jumpPow,0);
         }
         if (other.CompareTag("Finish")) {
            print("HIT HERE DNE");
            jumpDir = new Vector2(0,0);
            winMsg.SetActive(true);
            source.PlayOneShot(winFX, 0.7f);

            
         }
        
    }
    private void OnCollisionExit2D(Collision2D collision){
        print("ASDFLASFHASF");
        jumpDir = new Vector2(0,0);
    }
}
