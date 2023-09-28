using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private int _sceneIndex;

    public void SwitchScene()
    {
        SceneManager.LoadScene(_sceneIndex);
    }
}
