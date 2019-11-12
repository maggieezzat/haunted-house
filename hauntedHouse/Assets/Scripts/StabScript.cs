using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabScript : MonoBehaviour
{
    public Animator vampireAnim;
    public Animator playerAnim;

    public GameObject stick; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStab()
    {
        if (vampireAnim.GetCurrentAnimatorStateInfo(0).IsName("Vampiric Bite"))
        {
            vampireAnim.SetTrigger("Stabbed");
            playerAnim.SetTrigger("Stab");
            stick.SetActive(true);
        }
    }
}
