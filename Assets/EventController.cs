using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EventController : MonoBehaviour
{
   [SerializeField] UnityEvent onMouseClick;
    private void OnMouseDown()
    {
        onMouseClick.Invoke();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
