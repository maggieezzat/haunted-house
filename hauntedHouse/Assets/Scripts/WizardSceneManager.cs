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

    public AudioSource background;
    public AudioClip gameAudio;
    public AudioClip choiceAudio;

    public AudioSource effects;
    public AudioClip wizardCasting;
    public AudioClip spell1;
    public AudioClip spell2;

    public CinemachineVirtualCamera wizardCamera;
    void Start()
    {
        Invoke("activatePanel", 10);
        background.clip = gameAudio;
        background.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(weaponSelected){
            if(doIt){
                if(crucio){
                    Instantiate(red, new Vector3(-2.8f, -3.3f, 0.5f),  new Quaternion());
                    Invoke("die", 0);
                    doIt = false;
                    
                }
                else{
                    Instantiate(blue, new Vector3(-2.8f, -3.3f, 0.5f),  new Quaternion());
                    doIt = false;
                    Invoke("die", 0);
                }

            }
        }
    }

    void  die(){
        Debug.Log("Die Mother fucker");
        wizardAnimator.SetBool("defeated", true);

    }

    void activatePanel(){
        WeaponPanel.SetActive(true);
        background.Stop();
        background.clip = choiceAudio;
        background.Play();

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
        Debug.Log("Blue spell");


    }

    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
