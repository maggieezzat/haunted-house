using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript : MonoBehaviour
{
    Rigidbody rb;
    public Animator knifeAnimator;
    public Animator zombieAnimator;

    bool follow = false;

    Transform chest;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        chest = zombieAnimator.GetBoneTransform(HumanBodyBones.UpperChest);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(follow){
            transform.position = chest.position;
        }
        
    }

    void OnTriggerEnter(Collider other) {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        knifeAnimator.SetBool("spinKnife", false);
        follow = true;

    }
}
