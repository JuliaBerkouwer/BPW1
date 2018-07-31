using UnityEngine;
using UnityEngine.SceneManagement;

public class Steps : MonoBehaviour {

    public ParticleSystem ps;
    private Vector3 lastLocation;
    private CharacterController cc;

    private GameManager gm;

    private void Start()
    {
        gm = GetComponent<GameManager>();
        cc = GetComponent<CharacterController>();
    }

    void Update ()
    {
        if (lastLocation.x != transform.position.x && lastLocation.z != transform.position.z && cc.isGrounded)
        {
            gm.startTimer = true;
            ps.Play();
        }

         lastLocation = transform.position;


	}
}
