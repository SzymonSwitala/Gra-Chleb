using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class EventController : MonoBehaviour
{
   [SerializeField] UnityEvent onMouseClick;
    private void OnMouseDown()
    {
        onMouseClick.Invoke();
    }

    private void OnMouseEnter()
    {
        transform.localScale= new Vector3(1.2f, 1.2f, 1.2f);
    }
    private void OnMouseExit()
    {
        transform.localScale = new Vector3(1,1,1);
    }
}
