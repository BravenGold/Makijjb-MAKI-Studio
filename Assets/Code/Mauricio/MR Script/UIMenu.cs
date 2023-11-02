using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour{
    public GameObject SpawnMenu;

    public void MenuSpawn(){
        if(SpawnMenu.activeSelf){
            SpawnMenu.SetActive(false);
        }else{
            SpawnMenu.SetActive(true);
        }
    }

}
