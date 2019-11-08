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

    bool weaponSelected;

    //0 means gun, 1 means knife
    int weapon;

    bool shot = false;

    public AudioSource background;
    public AudioClip gameplayAudio;
    public AudioClip choiceAudio;

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
        if (ZombieAnimator.GetCurrentAnimatorStateInfo(0).IsName("zombie-idle") && weaponSelected==false)
        {
            WeaponPanel.SetActive(true);
            background.clip = choiceAudio;
            background.Play();
        }

        if(weaponSelected==true && weapon==0 && shot==false) //gun
        {
            gun.GetComponent<flaregun>().Shoot();
            shot=true;
            ZombieAnimator.SetBool("playAgony", true);

        }

        if(weaponSelected==true && weapon==1) //knife
        {
            knifeAnimator.SetBool("spinKnife", true);
            ZombieAnimator.SetBool("playAgony", true);
        }
        
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");


    }

    public void SelectGun()
    {
        weaponSelected=true;
        weapon=0;
        WeaponPanel.SetActive(false);
        gun.transform.position= new Vector3(0,0,0);
        background.clip = gameplayAudio;
        background.Play();
        

    }

    public void SelectKnife()
    {
        weapon=1;
        weaponSelected=true;
        WeaponPanel.SetActive(false);
        knife.transform.position= new Vector3(0,0,0);
        knifeAnimator = knifeAnimator.GetComponent<Animator>();
        background.clip = gameplayAudio;
        background.Play();

    }



}
