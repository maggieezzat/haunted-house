using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class ZombieSceneManager : MonoBehaviour
{

    public GameObject WeaponPanel;
    public Animator ZombieAnimator;
    public Animator AkaiAnimator;
    Transform AkaiRightHand;
    Transform AkaiLeftHand;
    public Vector3 gunHoldingOffset;
    public Vector3 gunIdleOffset;

    public Vector3 knifeOffset;
    public Transform ZombieGirl;

    public GameObject gun;
    public GameObject knife;
    Animator knifeAnimator;
    Rigidbody kniferb;
    bool knifePositioned = false;
    bool knifeShot = false;

    bool weaponSelected = false;

    //0 means gun, 1 means knife
    int weapon = -1;

    bool gunShot = false;

    public AudioSource background;
    public AudioClip gameplayAudio;
    public AudioClip choiceAudio;

    bool choiceAudioPlaying = false;

    public AudioSource effects;
    public AudioClip agonySound;

    Transform head;

    Transform spine;


    public CinemachineVirtualCamera vcm_zombieStand;
    public CinemachineVirtualCamera vcm_kill;
    public CinemachineVirtualCamera vcm_zombieWalk;

    void Awake() {
        head = ZombieAnimator.GetBoneTransform(HumanBodyBones.Head);
        spine = ZombieAnimator.GetBoneTransform(HumanBodyBones.Spine);
        background.clip = gameplayAudio;
        background.Play();
        vcm_zombieStand.m_LookAt = head;
        vcm_zombieWalk.m_Follow = head;
        //vcm_zombieWalk.m_Follow = spine;
    }
    void Start()
    {
        //head = ZombieAnimator.GetBoneTransform(HumanBodyBones.Neck);
        background.clip = gameplayAudio;
        background.Play();
        AkaiRightHand = AkaiAnimator.GetBoneTransform(HumanBodyBones.RightHand);
        AkaiLeftHand = AkaiAnimator.GetBoneTransform(HumanBodyBones.LeftHand);
        //vcm1_stand.m_Follow = ZombieGirl;
        knife.transform.position = AkaiLeftHand.position;
        
    }

    void Update()
    {
        if (ZombieAnimator.GetCurrentAnimatorStateInfo(0).IsName("zombie-standup")){

            vcm_zombieStand.Priority = 10;
        }

        if (ZombieAnimator.GetCurrentAnimatorStateInfo(0).IsName("zombie-walk")){
            vcm_zombieStand.Priority = 0;
            vcm_zombieWalk.Priority = 10;
        }
        if (ZombieAnimator.GetCurrentAnimatorStateInfo(0).IsName("zombie-idle") && weaponSelected==false && !choiceAudioPlaying)
        {
            WeaponPanel.SetActive(true);
            background.Stop();
            background.clip = choiceAudio;
            background.Play();
            choiceAudioPlaying = true;

            vcm_zombieWalk.Priority =0;
            vcm_kill.Priority = 10;
        }


        gun.transform.position = AkaiRightHand.position + gunIdleOffset;
        
        if(weaponSelected==true && weapon==0) //gun
        {
            gun.transform.position = AkaiRightHand.position + gunHoldingOffset;
           
            if(!gunShot){
                gun.GetComponent<flaregun>().Shoot();
                ZombieAnimator.SetBool("playAgony", true);
                effects.Play();
                gunShot=true;

            }

        }

        if(weaponSelected==true && weapon==1 )  //knife
        {
            if(!knifeShot ){
                knifeAnimator.SetBool("spinKnife", true);
                Transform chest = ZombieAnimator.GetBoneTransform(HumanBodyBones.Chest);
                knife.transform.LookAt(chest);
                //Vector3 direction = (chest.position - knife.transform.position).normalized;
                //knife.transform.position = AkaiLeftHand.position;
                //kniferb.AddForce(knife.transform.forward*120f, ForceMode.Impulse);
                //kniferb.AddForce(direction*220f, ForceMode.Impulse);
                ZombieAnimator.SetBool("playAgony", true);
                effects.Play();
                knifeShot=true;
            }
            else{
                knife.transform.Translate(0,0,0.3f);

            }

        }
        else{
            
            knife.transform.position = AkaiLeftHand.position + knifeOffset;

        }
        
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");

    }

    public void SelectGun()
    {
        AkaiAnimator.SetBool("isGun", true);
        weaponSelected=true;
        weapon = 0;
        WeaponPanel.SetActive(false);

        background.Stop();
        background.clip = gameplayAudio;
        background.Play();
        

    }

    public void SelectKnife()
    {
        AkaiAnimator.SetBool("isKnife", true);
        weapon = 1;
        weaponSelected=true;
        WeaponPanel.SetActive(false);
        
        knifeAnimator = knife.GetComponent<Animator>();
        kniferb = knife.GetComponent<Rigidbody>();

        background.Stop();
        background.clip = gameplayAudio;
        background.Play();

    }



}
