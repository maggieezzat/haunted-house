using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class WizardSceneManager : MonoBehaviour
{
    public GameObject WeaponPanel;
    // Start is called before the first frame update
    bool weaponSelected = false;
    bool crucio = false;
    public GameObject blue;
    public GameObject red;
    bool doIt = true;

    public Animator wizardAnimator;
    public Animator playerAnimator;

    public AudioSource background;
    public AudioClip gameAudio;
    public AudioClip choiceAudio;

    public AudioSource effects;
    public AudioClip wizardCasting;
    public AudioClip spell1;
    public AudioClip spell2;

    public AudioClip wizardDie;

    public CinemachineVirtualCamera topCam;
    public CinemachineVirtualCamera playerCam;
    public CinemachineVirtualCamera wizardCamera;
    void Start()
    {
        topCam.Priority = 10;
        playerCam.Priority = 0;
        wizardCamera.Priority = 0;
        Invoke("walkPlayer", 8);
        Invoke("activatePanel", 10);
        Invoke("switchCam", 3);
        background.clip = gameAudio;
        background.Play();
    }

    void switchCam()
    {
        topCam.Priority = 0;
        wizardCamera.Priority = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(weaponSelected){
            if(doIt){
                if(crucio){
                    Instantiate(red, new Vector3(-2.8f, -3.3f, 0.5f),  new Quaternion());
                    Invoke("die", 3);
                    doIt = false;
                    
                }
                else{
                    Instantiate(blue, new Vector3(-2.8f, -3.3f, 0.5f),  new Quaternion());
                    doIt = false;
                    Invoke("die", 3);
                }

            }
        }
    }

    void  die(){
        Debug.Log("Die Mother fucker");
        wizardAnimator.SetBool("defeated", true);
        if(crucio){
            wizardAnimator.SetBool("spell1Die", true);
            wizardAnimator.SetBool("spell2Explode", false);
        }
        else{
            wizardAnimator.SetBool("spell2Explode", true);
            wizardAnimator.SetBool("spell1Die", false);
        }
        background.Stop();

        effects.Stop();
        effects.clip = wizardDie;
        effects.Play();

    }

    void activatePanel(){
        playerAnimator.SetBool("casting", true);
        //playerAnimator.SetTrigger("walk");
        WeaponPanel.SetActive(true);
        background.Stop();
        background.clip = choiceAudio;
        background.Play();
        //playerCam.Priority = 30;
        wizardCamera.Priority = 0;
        topCam.Priority = 0;
    }

        public void SelectCrucio()
    {
        background.Stop();
        background.clip = gameAudio;
        background.Play();

        effects.Stop();
        effects.clip = spell1;
        effects.Play();

        weaponSelected=true;
        crucio = true;
        WeaponPanel.SetActive(false);
        wizardCamera.Priority = 30;
        playerCam.Priority = 0;
        Debug.Log("Red spell");

    }

    public void SelectImperio()
    {
        background.Stop();
        background.clip = gameAudio;
        background.Play();

        effects.Stop();
        effects.clip = spell2;
        effects.Play();

        weaponSelected = true;
        WeaponPanel.SetActive(false);
        wizardCamera.Priority = 35;
        playerCam.Priority = 0;
        Debug.Log("Blue spell");


    }

    public void walkPlayer(){
        playerAnimator.SetTrigger("walk");
        playerCam.Priority = 30;

    }

    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
