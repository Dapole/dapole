using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    [SerializeField] private float _speed = 1.5f;
    [SerializeField] private float _rotateSpeed = 20.0f;
    [SerializeField] private int _score = 5;
    [SerializeField] private GameObject _prefabExplosion;
    private SpawnManager _spawnManager;
    private Player _player;

    private void Start() {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
    }

    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);

        if (transform.position.y < -5.5f)
        {
            float randomX = Random.Range(-9.0f, 9.0f);
            transform.position = new Vector3(randomX, 8, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                Instantiate(_prefabExplosion, transform.position, Quaternion.identity);
                player.Damage();
            }
            _speed = 0.5f;
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            if (_player != null)
            {
                _player.AddScore(_score);
            }
            Instantiate(_prefabExplosion, transform.position, Quaternion.identity);
            Destroy(GetComponent<Collider2D>());
            //_spawnManager.StartSpawning();
            Destroy(this.gameObject, 0.25f);
        }
    }
}
