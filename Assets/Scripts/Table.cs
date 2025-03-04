using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private GameObject breadObj;
    private float xPos;
    private void Start()
    {
        xPos = transform.position.x;
    }
    public void SpawnBread(Sprite sprite)
    {
      GameObject go=  Instantiate(breadObj,new Vector3(xPos,transform.position.y,transform.position.z),Quaternion.identity);
        go.GetComponent<SpriteRenderer>().sprite = sprite;
        xPos++;
    }
}
