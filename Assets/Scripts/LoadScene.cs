using UnityEngine;

using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
    [SerializeField] private int sceneIndex;
    public void Load()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
