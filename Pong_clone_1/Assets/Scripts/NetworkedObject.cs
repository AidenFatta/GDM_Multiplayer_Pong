using UnityEngine;

public abstract class NetworkedObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected abstract void Intialize();

    protected abstract void GetNetworkId();
}
