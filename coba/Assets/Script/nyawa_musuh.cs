using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nyawa_musuh : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < -11){
            Destroy(gameObject);
        }
    }
}
