using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Door being opened by trigger")]
    private GameObject door;

    [SerializeField]
    [Tooltip("Door open height")]
    public float openHeight = 5f;

    [SerializeField]
    [Tooltip("Speed at which the door opens")]
    public float speed = 2f;

    [SerializeField]
    [Tooltip("Material the door changes to when locked")]
    public Material lockedDoorMaterial;

    [SerializeField]

    [Tooltip("Decide if door should be locked by default")]
    private bool isLocked = false;

    private Transform doorTransform;

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isOpening = false;
    private Material BaseMaterial;

    void Start()
    {
        doorTransform = door.transform;
        BaseMaterial = doorTransform.GetComponent<MeshRenderer>().material;
        if (!lockedDoorMaterial)
        {
            lockedDoorMaterial = doorTransform.GetComponent<MeshRenderer>().material;
        }
        if (isLocked)
        {
            doorTransform.GetComponent<MeshRenderer>().material = lockedDoorMaterial;
        }
        closedPosition = doorTransform.position;
        openPosition = closedPosition + Vector3.up * openHeight;
    }

    void FixedUpdate()
    {
        if (isOpening && !isLocked)
        {
            doorTransform.position = Vector3.Lerp(doorTransform.position, openPosition, speed * Time.fixedDeltaTime);
        }
        else
        {
            doorTransform.position = Vector3.Lerp(doorTransform.position, closedPosition, speed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOpening = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOpening = false;
        }
    }

    public void LockDoor()
    {
        isLocked = true;
        doorTransform.GetComponent<MeshRenderer>().material = lockedDoorMaterial;
    }

    public void UnlockDoor()
    {
        isLocked = false;
        doorTransform.GetComponent<MeshRenderer>().material = BaseMaterial;
    }

}