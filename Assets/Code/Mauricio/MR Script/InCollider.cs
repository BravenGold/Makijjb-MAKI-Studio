using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InCollider : MonoBehaviour{
    bool InBox = false; 

    public bool ChangeSign(bool change){
        InBox = change;
        return change; 
    }
}

