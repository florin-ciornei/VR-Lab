using UnityEngine;

public class BakingSoda : MonoBehaviour
{
    [SerializeField]
    private Material materialToPaintWaterWith;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            other.gameObject.GetComponent<MeshRenderer>().material = materialToPaintWaterWith;
            other.gameObject.GetComponent<VolcanoReaction>().ApplyBakingSoda();
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
