using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Class used for Initializing and Starting events on the Scene being Loaded
public class SceneLoad : MonoBehaviour
{
    [SerializeField] UnityEvent OnLoaded;

    // Start is called before the first frame update
    void Start()
    {
        OnLoaded.Invoke();
    }
}