using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] private bool isPlayer = true;
    
    [SerializeField] private GameObject prefabCreature;

    public void Spawning()
    {
        GameObject creature = Instantiate(prefabCreature, transform.position, transform.rotation);
        Debug.Log("hanhaa");
    }

}
