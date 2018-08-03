using UnityEngine;

public class Gun : MonoBehaviour
{

    public float damage = 10f;              //Ammount of damage taken per hit
    public float range = 100f;              //The range you are able to shoot from

    public Camera fpsCam;                   //
    public GameObject impactEffectTerrain;    //Particle effect for when terrain is hit
    public GameObject impactEffectBunny;    //Particle effect for when terrain is hit
    public ParticleSystem muzzleFlash;      //Particle effect for muzzleFlash
    public AudioClip shootingSound;         //Sound when shooting



    void Update()
    {
        //Updates every frame

        //When you press the left mouse button shoot function will get called
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }


    }

    void Shoot()
    {
        //It shoots a ray to an object and when it hits it will do the following:

        //Activates the particle effect for the muzzleflash
        muzzleFlash.Play();

        //Will put the sound of the shootingSound float in the Audiosource clip and will play it when you shoot.
        GetComponent<AudioSource>().clip = shootingSound;
        GetComponent<AudioSource>().Play();


        RaycastHit hit;
        //It takes the position from the fpsCam, and the position forwards of the fpsCam. The out hit takes the data from what it hits and puts it together. And it can only shoot as far as the range
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Checks which object has been hit and shows the name at the bottom
            Debug.Log(hit.transform.name);

            //Takes the component target of the object it hit
            Target target = hit.transform.GetComponent<Target>();
            //If a target is hit it takes damage
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            //If the target has the tag "Shark" then a particle effect will play
            if (target.tag == "Bunny")
            {

                //We make a GameObject of the impactGO. It will Instantiate the particle effect of the shark when it hits the gameobject and it will make sure the particle effect will always show outside of the collider of the object
                GameObject impactGO = Instantiate(impactEffectBunny, hit.point, Quaternion.LookRotation(hit.normal));
                //The particle will be destroyed after 2 second
                Destroy(impactGO, 2f);
            }
            else if (target.tag == "Terrain")
            {
                //We make a GameObject of the impactGO. It will Instantiate the particle effect of the shark when it hits the gameobject and it will make sure the particle effect will always show outside of the collider of the object
                GameObject impactGO = Instantiate(impactEffectTerrain, hit.point, Quaternion.LookRotation(hit.normal));
                //The particle will be destroyed after 2 second
                Destroy(impactGO, 2f);
            }
        }

    }
}
