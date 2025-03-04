using UnityEngine;

public class ExitGame : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Exit();

        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
