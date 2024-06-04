using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShoot1 : MonoBehaviour
{

    public GameObject bulletPrefab;
    //public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;
    public Transform barrelLocation;
    //public Transform casingExitLocation;
    private AudioSource MyPlayer;


    public float shotPower = 1000f;

    private bool IsShooting = false;

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;

        MyPlayer = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (SaveScript.InventoryOpen == false && SaveScript.OptionsOpen == false)
        {
            if(IsShooting == false)
            {
                IsShooting = true;
                StartCoroutine(DelayTime());
            }

        } 
    }

    void Shoot()
    {

        GameObject tempFlash;
       Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
       tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

       Destroy(tempFlash, 0.5f);
        //  Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation).GetComponent<Rigidbody>().AddForce(casingExitLocation.right * 100f);
       
    }

    void CasingRelease()
    {
        /* GameObject casing;
        casing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        casing.GetComponent<Rigidbody>().AddExplosionForce(550f, (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        casing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(10f, 1000f)), ForceMode.Impulse);*/
    }

    IEnumerator DelayTime()
    {
        GetComponent<Animator>().SetTrigger("Fire");
        MyPlayer.Play();
        yield return new WaitForSeconds(1f);
        IsShooting = false;
    }


}
