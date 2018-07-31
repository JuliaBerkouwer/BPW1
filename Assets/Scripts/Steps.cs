using UnityEngine;
using UnityEngine.SceneManagement;

public class Steps : MonoBehaviour {

    public ParticleSystem ps;
    private Vector3 lastLocation;
    private CharacterController cc;

    private Timer t;

    private void Start()
    {
        t = GetComponent<Timer>();
        cc = GetComponent<CharacterController>();
    }

    void Update ()
    {
        if (lastLocation.x != transform.position.x && lastLocation.z != transform.position.z && cc.isGrounded)
        {
            t.enabled = true;
            ps.Play();
        }

        if (lastLocation.y < -25f)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        lastLocation = transform.position;


	}
}
