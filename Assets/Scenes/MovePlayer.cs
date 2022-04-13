
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "particle")
        {
            other.gameObject.SetActive(true);
        }
    }

    public float speed = .1f;
    // Update is called once per frame
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);

        transform.position += moveDirection*speed;

    }
}
