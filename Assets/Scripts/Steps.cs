using UnityEngine;


public class Steps : MonoBehaviour {

    public ParticleSystem ps;
    private Vector3 lastLocation;
    private CharacterController cc;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update ()
    {
        if (lastLocation != transform.position && cc.isGrounded)
        {
            ps.Play();
        }
        lastLocation = transform.position;
	}
}
