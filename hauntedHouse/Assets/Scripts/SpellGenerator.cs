using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpellGenerator : MonoBehaviour
{
    public GameObject middleFinger;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createSpell(){
        middleFinger.GetComponent<MiddleFinger>().yalla();
    }

    public void SwitchScene()
    {
        SceneManager.LoadScene("VampireScene");

    }


}
