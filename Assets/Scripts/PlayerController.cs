using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 6;
    public float lucNem = 7;
    public InputAction moveAction;
    public InputAction nemBong;
    public GameObject ball;
    public GameObject spawnBall;
    public float timeSpawn = 1;

    public GameManager gameManager;
    void Start()
    {
        moveAction.Enable();
        nemBong.Enable();
    }

    void Update()
    {
        if (gameManager.isGameActive)
        {
            Move();
            if (nemBong.WasPressedThisFrame() && timeSpawn <= 0)
            {
                NemBong();
                timeSpawn = 1;
            }
            timeSpawn -= Time.deltaTime;
        }
        
    }
    void NemBong()
    {
        GameObject newBall = Instantiate(ball,spawnBall.transform.position,Quaternion.identity);

        Rigidbody ballRb = newBall.GetComponent<Rigidbody>();

        if (ballRb != null && Camera.main != null)
        {
            ballRb.AddForce((Camera.main.transform.forward + new Vector3(0, 1, 0)).normalized * lucNem,ForceMode.Impulse);
        }
        Destroy(newBall, 5f);
    }
    void Move()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();
        Vector3 movement = new Vector3(move.x, 0, move.y);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
