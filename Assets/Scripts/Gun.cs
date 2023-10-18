using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    [SerializeField] Transform barrel;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] private int _maxAmmo;
    [SerializeField] private float reloadTime = 2f;

    private PlayerController playerController;
    private Quaternion originalRotation;
    private int shotCount = 0;
    private float timer = 0;
    private bool isReloading = false;

    private void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        originalRotation = barrel.rotation;
    }

    void Update()
    {
        HandleShooting();
        HandleRotation();
        HandleReload();
    }

    private void HandleShooting()
    {
        if (Input.GetButtonDown("Shoot") && !isReloading)
        {
            AudioManager.Instance.PlayGunShot();
            shotCount++;
            GameObject bullet = Instantiate(bulletPrefab, barrel.position, barrel.rotation);
            Destroy(bullet, 2f);
        }
    }

    private void HandleRotation()
    {
        if (playerController != null)
        {
            barrel.rotation = originalRotation * Quaternion.Euler(0, playerController.IsFacingRight() ? 0 : 180f, 0);
        }
    }

    private void HandleReload()
    {
        if (Input.GetKeyDown(KeyCode.R) || (shotCount >= _maxAmmo && !isReloading))
        {
            isReloading = true;
            AudioManager.Instance.PlayReload();
        }

        if (isReloading)
        {
           
            timer += Time.deltaTime;

            if (timer >= reloadTime)
            {
                timer = 0;
                shotCount = 0;
                isReloading = false;
            }
        }
    }
}
