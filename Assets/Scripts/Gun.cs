using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    [SerializeField] Transform barrel;
    [SerializeField] GameObject bulletPrefab;

    private PlayerController playerController;
    private Quaternion originalRotation;

    private void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        originalRotation = barrel.rotation;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletPrefab, barrel.position, barrel.rotation);
            Destroy(bullet, 2f);
        }

        if (playerController != null)
        {
            if (playerController.IsFacingRight())
            {
                barrel.rotation = originalRotation;
            }
            else
            {
                Vector3 flippedRotation = originalRotation.eulerAngles;
                flippedRotation.y += 180f; // Rotate 180 degrees when facing left
                barrel.rotation = Quaternion.Euler(flippedRotation);
            }
        }
    }
}
