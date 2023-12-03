  /********************************
  * UIMENU.cs
  * Mauricio Rodriguez, Maki Studios
  *
  * This script dictates whether the menu is 
  * open or is closed. 
  * 
  *  
  ********************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class UIMenu : MonoBehaviour{

    public GameObject SpawnMenu;

    public Animator animator;

    /*private void Update(){
        if(SpawnMenu.activeSelf){
            animator.SetBool("Open",false);
        }else{
            animator.SetBool("Open",true);
        }
    }*/

    public void MenuSpawn(){
        if(SpawnMenu.activeSelf){
            SpawnMenu.SetActive(false);
            animator.SetBool("Open",false);
        }else{
            SpawnMenu.SetActive(true);
            animator.SetBool("Open",true);
        }
    }

}
