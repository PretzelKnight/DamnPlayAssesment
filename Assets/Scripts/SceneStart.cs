using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Class used for Initializing and Starting events on the Scene being Initialized
public class SceneStart : MonoBehaviour
{
    [SerializeField] UnityEvent OnStart;

    // Start is called before the first frame update
    void Start()
    {
        OnStart.Invoke();
    }
}