using UnityEngine;

public class Shoots : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    float originalXPosition;

    void Start()
    {
        originalXPosition = transform.localPosition.x;
    }

    public void ShootBullet(bool isFacingRight, bool isFacingDown)
    {
        if (isFacingRight)
        {
            transform.localPosition = new Vector3(-originalXPosition, transform.localPosition.y, transform.localPosition.z);
        }
        else
        {
            transform.localPosition = new Vector3(originalXPosition, transform.localPosition.y, transform.localPosition.z);
        }

        GameObject bulletInstance = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
        if (isFacingDown)
        {
            bulletInstance.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 500 * (isFacingDown ? 1 : -1));
            return;
        }
        bulletInstance.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 500 * (isFacingRight ? 1 : -1));
    }
}