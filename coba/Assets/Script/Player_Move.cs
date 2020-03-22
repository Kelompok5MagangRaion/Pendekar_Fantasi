using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public int speed = 10;
    private bool FacingRight = false;
    public int jumppower = 1250;
    private float Xmove;
    public bool onground;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
    pergerakan();
    Playerhit();    
    }
    void pergerakan(){
        //Untuk acuan input gerak kanan-kiri secara horizontal
        Xmove = Input.GetAxis("Horizontal");
        //saat pencet lompat(space)
        if(Input.GetButtonDown("Jump") && onground){
            lompat();
        }
        //Saat bergerak hadap kanan
        if (Xmove < 0.0f && FacingRight == false){
            hadapanplayer();
            //Saat bergerak hadap kiri
        }else if (Xmove > 0.0f && FacingRight == true){
            hadapanplayer();
        }
        //kontrol untuk gerak kanan-kiri.
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3 (Xmove * speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }
    void lompat(){
        //lompat, saat gk ditanah gk bisa lompat
        GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumppower);
            onground = false;
    }
    private void OnCollisionEnter2D(Collision2D collision){
    onground = true;
    }
    void hadapanplayer(){
        //Kontrol untuk character menghadap kanan/kiri
        FacingRight = !FacingRight;
        Vector3 a = gameObject.transform.localScale;
        a.x *= -1;
        transform.localScale = a;
    }
    void Playerhit(){
        RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.down);
        if(hit != null && hit.collider != null && hit.distance < 0.9f && hit.collider.tag == "enemy"){
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            hit.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;            
            hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 8;            
            hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            hit.collider.gameObject.GetComponent<musuh_bergerak>().enabled = false;
        
        }
    }
}
