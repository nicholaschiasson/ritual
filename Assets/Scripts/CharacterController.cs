using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject Character;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Message Handlers
    void SetViewportRect(Rect dimensions)
    {
        Debug.Log(dimensions);
        Character.GetComponentInChildren<Camera>().rect = dimensions;
    }
}
