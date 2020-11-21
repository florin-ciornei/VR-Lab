using UnityEngine;

public class Vinegar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            other.gameObject.GetComponent<VolcanoReaction>().ApplyVinegar();
            Destroy(gameObject);
        }
    }
}
