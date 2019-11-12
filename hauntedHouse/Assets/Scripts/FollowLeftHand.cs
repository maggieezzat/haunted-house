using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLeftHand : MonoBehaviour
{
    public Animator playerAnim;
    public Vector3 Offset;
    Transform leftHand;
    // Start is called before the first frame update
    void Start()
    {
        leftHand = playerAnim.GetBoneTransform(HumanBodyBones.LeftHand);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = leftHand.position + Offset;
    }
}
