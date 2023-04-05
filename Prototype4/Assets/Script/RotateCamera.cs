using UnityEngine;

public class RotateCamera : MonoBehaviour
{

    [SerializeField] private float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Rotate(Vector3.up * horizontalInput * rotateSpeed * Time.deltaTime);

    }
}
