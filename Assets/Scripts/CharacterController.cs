using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Camera camera;
    CharacterState characterState;

    public GameObject Character;

    void Awake()
    {
        camera = gameObject.AddComponent<Camera>();
        camera.transform.position = Character.transform.position - new Vector3(0, 0, 7.5f);
        characterState = Character.GetComponent<CharacterState>();
    }

    void FixedUpdate()
    {
        characterState.Velocity = new Vector2(Input.GetAxis("Horizontal") * characterState.WalkSpeed, characterState.Velocity.y);
    }

    // Message Handlers
    void SetViewportRect(Rect dimensions)
    {
        camera.rect = dimensions;
    }
}
