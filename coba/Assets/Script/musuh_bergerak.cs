using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musuh_bergerak : MonoBehaviour
{
    public int kecepatan = 1;
    public int Xtanda = 1;
    public Player_Dead plyr;
    
    void Start(){
        plyr = GameObject.Find("player").GetComponent<Player_Dead>();
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast (transform.position, new Vector3(Xtanda, 0)); 
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(Xtanda, 0) * kecepatan;
    if(hit.distance < 0.7f){
        balik_arah();
        if(hit.collider.tag == "Player"){
            plyr.sisanyawa();
            plyr.pos();
            }
        }
        
    }
    void balik_arah(){
        if(Xtanda > 0){
            Xtanda = -1;
        }else{
            Xtanda = 1;
        }
    }

}
