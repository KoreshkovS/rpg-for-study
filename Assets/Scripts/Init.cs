using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    private void Awake()
    {
        AudioController.Init();
        SceneManager.LoadScene(1);
        AudioController.PlayMusic("Soulicious - Dyalla");
    }
}
