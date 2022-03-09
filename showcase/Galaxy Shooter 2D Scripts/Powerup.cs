using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private int powerupID; // 0 = Triple Shot, 1 = Speed, 2 = Shields
    [SerializeField] private AudioClip _clip;
    
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -6f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            AudioSource.PlayClipAtPoint(_clip,transform.position);
            if (player != null)
            {
                switch (powerupID)
                {
                    case 0: player.TripleShootActive(); break;
                    case 1: player.SpeedBoostActive(); break;
                    case 2: player.ShieldsActive(); break;
                    default: Debug.Log("Default Value"); break;
                }
            }
            Destroy(this.gameObject);
        }
    }
}
