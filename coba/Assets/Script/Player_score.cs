using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player_score : MonoBehaviour
{
    public GameObject waktuUI;
    public GameObject scoreUI;
    private float waktu = 120;
    public int score = 0;
    // Update is called once per frame
    void Update()
    {
        waktu -= Time.deltaTime;
        waktuUI.gameObject.GetComponent<Text>().text = ("Time" + (int)waktu);
        scoreUI.gameObject.GetComponent<Text>().text = ("score" + score);
        if (waktu < 0.1f){
            SceneManager.LoadScene("coba_1");
        }
    
    }
    void OnTriggerEnter2D(Collider2D trig){
        Hitung_Score();
    }
    void Hitung_Score(){
        score = score + (int)(waktu*10);
    }
}
