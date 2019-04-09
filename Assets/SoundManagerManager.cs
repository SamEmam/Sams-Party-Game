using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManagerManager : MonoBehaviour
{
    public SoundManager SM;
    private bool hasUpdated = false;

    // Start is called before the first frame update
    void LateUpdate()
    {
        if (!hasUpdated)
        {
            hasUpdated = true;
            SM.ignoreLevelLoad = true;
            SM.maxMusicVolume = .4f;
            Destroy(this.gameObject);
        }
        
    }
    
}
