﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleFinger : MonoBehaviour
{
    bool moving = false;
    public GameObject spell;
    public int speed;
    GameObject bisho;

    public AudioSource audio;
    public AudioClip castingSpell;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (moving){
            bisho.GetComponent<Transform>().Translate(0,0,-speed * Time.deltaTime);
        }
    }

    public void yalla(){
        Debug.Log("I am a spell");
        bisho = Instantiate(spell, new Vector3(-2.8f, -3.3f, 6.84f),  new Quaternion());
        Invoke("move",2.5f);
        audio.clip = castingSpell;
        audio.Play();

    }
    void move(){
        Invoke("destroy",5);
        moving = true;
        // bisho.GetComponent<Transform>().Translate(2,0,0);
    }

    void destroy(){
        moving = false;
        Destroy(bisho);
    }

    public void playCastingSound(){
        
    }
}
