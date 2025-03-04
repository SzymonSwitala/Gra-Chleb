using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
public class BreadController : MonoBehaviour 
{
    [SerializeField] int breadID;
    [SerializeField] GameManager gameManager;
    private void OnMouseDown()
    {
        gameManager.AddPurchasedBread(breadID,transform);
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
