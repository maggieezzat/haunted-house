using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieSceneManager : MonoBehaviour
{

    public GameObject WeaponPanel;
    public GameObject ZombieGirl;
    Animator ZombieAnimator;

    public GameObject gun;
    public GameObject knife;
    Animator knifeAnimator;
    Rigidbody kniferb;
    bool knifePositioned = false;
    bool knifeShot = false;

    bool weaponSelected = false;

    //0 means gun, 1 means knife
    int weapon;

    bool shot = false;

    public AudioSource background;
    public AudioClip gameplayAudio;
    public AudioClip choiceAudio;

    bool choiceAudioPlaying = false;

    public AudioSource effects;
    public AudioClip agonySound;


    void Start()
    {
        ZombieAnimator = ZombieGirl.GetComponent<Animator>();
        
        background.clip = gameplayAudio;
        background.Play();
        
    }

    void Update()
    {
        if (ZombieAnimator.GetCurrentAnimatorStateInfo(0).IsName("zombie-idle") && weaponSelected==false && !choiceAudioPlaying)
        {
            WeaponPanel.SetActive(true);
            background.Stop();
            background.clip = choiceAudio;
            background.Play();
            choiceAudioPlaying = true;
        }

        if(weaponSelected==true && weapon==0 && shot==false) //gun
        {
            gun.GetComponent<flaregun>().Shoot();
            shot=true;
            ZombieAnimator.SetBool("playAgony", true);
            effects.Play();

        }

        if(weaponSelected==true && weapon==1) //knife
        {
            //knifeAnimator.SetBool("spinKnife", true);
            if(! knifePositioned){
                knife.transform.position= new Vector3(-2.16f, -1f, -3f);
                knifePositioned=true;
            }
            if(! knifeShot){
                Vector3 direction = (ZombieGirl.transform.position - knife.transform.position).normalized;
                kniferb.AddForce(direction*100, ForceMode.Force);
                ZombieAnimator.SetBool("playAgony", true);
                effects.Play();
                knifeShot=true;

            }
            
        }
        
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");


    }

    public void SelectGun()
    {
        weaponSelected=true;
        weapon = 0;
        WeaponPanel.SetActive(false);
        gun.transform.position = new Vector3(0,0,0);
        background.Stop();
        background.clip = gameplayAudio;
        background.Play();
        

    }

    public void SelectKnife()
    {
        weapon = 1;
        weaponSelected=true;
        WeaponPanel.SetActive(false);
        knife.transform.position= new Vector3(0,0,0);
        knifeAnimator = knife.GetComponent<Animator>();
        kniferb = knife.GetComponent<Rigidbody>();
        background.Stop();
        background.clip = gameplayAudio;
        background.Play();

    }



}
