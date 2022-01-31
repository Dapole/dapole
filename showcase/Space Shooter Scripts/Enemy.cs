using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _score = 10;
    [SerializeField] private float _speed = 4f;
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private float _fireRate = 3.0f;
    private Player _player;
    private Animator _animator;
    private AudioSource _audioSource;
    private float _canFire = -1;

    private void Start() {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _animator = gameObject.GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        CalculateMovement();

        if (Time.time > _canFire)
        {
            _fireRate = Random.Range(3f, 7f);
            _canFire = Time.time + _fireRate;
            GameObject enemyLaser = Instantiate(_laserPrefab, transform.position, Quaternion.identity);
            Laser[] lasers = enemyLaser.GetComponentsInChildren<Laser>();
            for (int i = 0; i < lasers.Length; i++)
            {
                lasers[i].AssignEnemyLaser();
            }
        }
    }

    void CalculateMovement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

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
                player.Damage();
            }
            _animator.SetTrigger("OnEnemyDeath");
            _speed = 0.5f;
            _audioSource.Play();
            Destroy(this.gameObject, 2.5f);
        }
        if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            if (_player != null)
            {
                _player.AddScore(_score);
            }
            _animator.SetTrigger("OnEnemyDeath");
            _speed = 0.5f;
            _audioSource.Play();
            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject, 2.5f);
        }
    }
}
