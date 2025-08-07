using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Vector3 moveDirection;

    void Start()
    {
        PickNewDirection();
    }

    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.EndsWith("Wall"))
        {
            PickNewDirection();
        }
    }

    void PickNewDirection()
    {
        Vector3 newDirection;
        float similarityThreshold = 0.7f;

        do
        {
            newDirection = new Vector3(
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f)
            ).normalized;
        }
        while (Vector3.Dot(moveDirection, newDirection) > similarityThreshold);

        moveDirection = newDirection;
    }
}
