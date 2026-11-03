using UnityEngine; 
using UnityEngine.Pool;
using UnityEngine.InputSystem;
using TMPro;

public class ShootPool : MonoBehaviour
{
    public GameObject projectilePrefab; 
    public Transform firePoint; 
    public int poolSize = 30; 
    public int currentAmmo; 

    public TextMeshProUGUI ammoText;
    private int activeProjectiles = 0;
    private ObjectPool<GameObject> pool; 

    public bool isEnemy = false;
    private bool canShoot = false;
    private float fireRate = 0.5f;
    
    private float nextFireTime = 0f;
    public LayerMask layerMask;
    public Transform player;
    

    void Awake()
    {
        if(!isEnemy)
        {
            switch(GameManager.ChoosenCharacterIndex)
            {
                case 0:
                    poolSize = 30;
                    fireRate = 0.1f;
                    break;
                case 1:
                    poolSize = 7;
                    fireRate = 0.3f;
                    break;
            }
        }
        
        currentAmmo = poolSize;
        pool = new ObjectPool<GameObject>(
            () => Instantiate(projectilePrefab), 
            projectile => projectile.SetActive(true), 
            projectile => projectile.SetActive(false), 
            projectile => Destroy(projectile),
            false, 
            poolSize, 
            poolSize 
        
        );
        currentAmmo = poolSize;
        UpdateAmmoText();
    }

    void Update()
    {   
        player = GameManager.ActiveChar;
        if(isEnemy && canShoot && Time.time >= nextFireTime)
        {           
            Shoot();
            nextFireTime = Time.time + fireRate;
        }

        if (isEnemy && currentAmmo <= 0 && !IsInvoking("Reload"))
        {
            Invoke("Reload", 2f);
        }
        /*
        if (Mouse.current.leftButton.isPressed && !isEnemy)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
        */      
        if (!isEnemy && Time.time >= nextFireTime)
        {
            if (GameManager.ChoosenCharacterIndex == 0 && Mouse.current.leftButton.isPressed)
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }

            if (GameManager.ChoosenCharacterIndex == 1 && Mouse.current.leftButton.wasPressedThisFrame)
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }
        }

        if (Keyboard.current[Key.R].wasPressedThisFrame && !isEnemy && !IsInvoking("Reload"))
        {
            Invoke("Reload", 2f);
        }
        if(currentAmmo <= 0 && !isEnemy && !IsInvoking("Reload"))
        {
            Invoke("Reload", 2f);
        }
        
    }
void FixedUpdate()
{
    canShoot = false;
    if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 50f, layerMask))
    {           
        canShoot = true;
         Debug.DrawLine(transform.position, hit.point, Color.green);
    }else
    {
      Debug.DrawLine(transform.position, transform.position + transform.forward * 100f, Color.red);
}
}
    void Shoot()
    {
    if (currentAmmo <= 0 || activeProjectiles >= poolSize)
            return;
        GameObject projectile = pool.Get();
        currentAmmo--;
        activeProjectiles++;
        projectile.transform.SetPositionAndRotation(firePoint.position, firePoint.rotation);
        projectile.GetComponent<Projectile>().StartProjectile(firePoint.forward, this);
    }

    public void ReturnProjectile(GameObject projectile)
    {
        activeProjectiles--;
        pool.Release(projectile);    
        UpdateAmmoText();    
    }

    private void Reload()
    {
        currentAmmo = poolSize;
        UpdateAmmoText();
    }
    private void UpdateAmmoText()
    {
        if (ammoText != null)
        {
            ammoText.text = currentAmmo + " / " + poolSize;
        }
    }
}











