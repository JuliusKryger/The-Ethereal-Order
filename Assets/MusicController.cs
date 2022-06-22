using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        if(instance == null)
        {
            instance=this;
        } else
        {
            Destroy(gameObject);
        }
    }
}
