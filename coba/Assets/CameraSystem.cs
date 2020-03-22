using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    public GameObject player;
    public float xMin;
    public float xMax;
    public float yMax;
    public float yMin;
    // Start is called before the first frame update
    void Start()
    {
        //Menyimpan tag Player yang ada di character untuk disimpan pada variable player
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Membatasi posisi player dengan kamera agar kamera mengikuti.
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);       
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3 (x, y, gameObject.transform.position.z);
    }
}
