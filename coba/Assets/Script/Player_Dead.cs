using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Dead : MonoBehaviour
{
GameObject player;
public int hp = 3;
public int currenthp;
GameObject cp;

    public void sisanyawa(){
        currenthp = Mathf.Clamp (currenthp - 1, 0, hp);
        if(currenthp > 0){
            Debug.Log ("Nyawa ada "+ currenthp);
        }else if (currenthp == 0) {
        //game akan mengulang dari awal
        SceneManager.LoadScene("coba_1");
        }
    }

    // Update is called En per frame
    void Update()
    {
        //Jika player berada di posisi player dibawah y -11
    if (gameObject.transform.position.y < -11){
        sisanyawa();
        if(player.gameObject.tag == "Player"){
            pos();
            }
                
        }        
    }
    public void pos(){
        player.transform.position = cp.transform.position;           
    }

    void Start(){
        cp = GameObject.Find("checkpoint");
        player = GameObject.Find("player");
    }
    void Awake(){
        currenthp = hp;
    }
        
}
