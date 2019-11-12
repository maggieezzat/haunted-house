using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHand : MonoBehaviour
{
    public Animator playerAnim;
    public Vector3 Offset;
    Transform rightHand;
    // Start is called before the first frame update
    void Start()
    {
        rightHand = playerAnim.GetBoneTransform(HumanBodyBones.RightHand);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = rightHand.position + Offset;
    }

    void OnTriggerEnter(Collider other) {
        transform.GetChild(1).gameObject.SetActive(true);
        print("heart");
    }
}
