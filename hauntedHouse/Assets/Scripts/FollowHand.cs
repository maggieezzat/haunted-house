using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Cinemachine;

public class FollowHand : MonoBehaviour
{
    public Animator playerAnim;
    public Animator vampireAnim;
    public Vector3 Offset;
    Transform rightHand;
    Transform spine;


    // Start is called before the first frame update
    void Start()
    {
        rightHand = playerAnim.GetBoneTransform(HumanBodyBones.RightHand);
        spine = playerAnim.GetBoneTransform(HumanBodyBones.Head);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = rightHand.position + Offset;
        //floatingCamera.position = spine.position;

    }


    public void backToMain()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
