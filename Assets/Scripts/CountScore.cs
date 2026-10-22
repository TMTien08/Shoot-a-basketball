using UnityEngine;

public class CountScore : MonoBehaviour
{
    public int score { get; private set; }
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        score += 1;
    }
}
