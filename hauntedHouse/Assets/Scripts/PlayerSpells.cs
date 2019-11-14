using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpells : MonoBehaviour
{
    // Start is called before the first frame update
    int speed = 2;
    void Start()
    {
        Invoke("destroy", 5);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Transform>().Translate(0,0,speed * Time.deltaTime);
    }

    void destroy(){
        Destroy(gameObject);
    }
}
