using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StabScript : MonoBehaviour
{
    public Animator vampireAnim;
    public Animator playerAnim;

    public GameObject stick;
    public bool isStabClicked = false;
    public bool isTorchClicked = false;

    public GameObject weaponPanel;

    public CinemachineVirtualCamera intro;
    public CinemachineVirtualCamera kill;

    public Camera introBrain;
    public Camera killBrain;

    bool started = false;

    private void Start()
    {
        
    }



    // Start is called before the first frame update
    void Update()
    {

        if (vampireAnim.GetCurrentAnimatorStateInfo(0).IsName("Vampiric Bite") && !started)
        {
            weaponPanel.SetActive(true);
            intro.Priority = 0;
            killBrain.enabled = true;
            introBrain.enabled = false;
            
            kill.Priority = 10;
            started = true;

        }


        

    }

    public void stabClick()
    {
        isStabClicked = true;

        weaponPanel.SetActive(false);
    }

    public void torchClick()
    {
        isTorchClicked = true;
        weaponPanel.SetActive(false);
    }

    public void OnStab()
    {
        if(isStabClicked)
        {
            vampireAnim.SetTrigger("Stabbed");
            playerAnim.SetTrigger("Stab");
        }

        if (isTorchClicked)
        {
            vampireAnim.SetTrigger("Torched");
            playerAnim.SetTrigger("Torch");
            
        }
    }


}
