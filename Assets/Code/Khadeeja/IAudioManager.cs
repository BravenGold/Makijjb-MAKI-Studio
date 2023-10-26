using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAudioManager
{
    void ChangeSoundVolume(float change);
    void ChangeMusicVolume(float change);
    // Add other necessary methods that need to be accessed by other classes
}

