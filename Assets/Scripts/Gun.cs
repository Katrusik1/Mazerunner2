using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 26f;
    public float range = 100f;
    public float fireRate = 15f;
    public int ammo = 27;

    public Camera fpsCam =null;
    //public ParticleSystem muzzleFlash;

    private float nextShoot = 0f;

    void Start()
    {

    }

    void Update()
    {
        if (fpsCam != null)
        {
            if (ammo > 0)
            {
                if (Input.GetButton("Fire1"))
                {
                    if (Time.time >= nextShoot)
                    {
                        nextShoot = Time.time + 1f / fireRate;
                        Shoot();

                    }
                    ammo -= 1;
                }
            }
            else ammo = 27;
        }
    }

    void Shoot()
    {
        //muzzleFlash.Play();       

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

        }
    }
    public void taken(Camera c)
    {
        fpsCam = c;
    }
}
