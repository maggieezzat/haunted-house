using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        Invoke("activatePanel", 10);
    }

    // Update is called once per frame
    void Update()
    {
        if(weaponSelected){
            if(doIt){
                if(crucio){
                    Instantiate(red, new Vector3(-2.8f, -2, 0.5f),  new Quaternion());
                    Invoke("die", 0);
                    doIt = false;
                    
                }
                else{
                    Instantiate(blue, new Vector3(-2.8f, -2, 0.5f),  new Quaternion());
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

    }

        public void SelectCrucio()
    {
        weaponSelected=true;
        crucio = true;
        WeaponPanel.SetActive(false);
        Debug.Log("Red spell");

    }

    public void SelectImperio()
    {
        weaponSelected=true;
        WeaponPanel.SetActive(false);
        Debug.Log("Blue spell");


    }
}
