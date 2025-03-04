using DG.Tweening;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private GameObject breadObj;
    private float xPos;
    private void Start()
    {
        xPos = transform.position.x;
    }
    public void SpawnBread(Sprite sprite,Transform breadTransform)
    {
     
        GameObject go = Instantiate(breadObj, breadTransform.position, Quaternion.identity);
        go.transform.DOMove(new Vector3(xPos, transform.position.y, transform.position.z),1);
        go.GetComponent<SpriteRenderer>().sprite = sprite;
        xPos+=0.75f;
    }
}
