using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Image HealthImage;
    private float HealthCount = 100f;
    private int DecreaseCount = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyHit")
        {
            HealthCount -= 5f;
            HealthImage.fillAmount = HealthCount / 100f;
        }
    }
}
