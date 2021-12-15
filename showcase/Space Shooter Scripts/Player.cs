using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3.5f;
    private float _speedMultiplier = 2;
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private GameObject _laserPrefabTriple;
    [SerializeField] private int _lives = 3;

    private float _nextFire = 0.0f;
    private SpawnManager _spawnManager;

    public float fireRate = 0.25f;
    public bool _tripleShootActive = false;
    public bool _speedBoostActive = false;
    public bool _shieldActive = false;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        if (_spawnManager == null)
        {
            Debug.LogError("Spawn Manager = NULL");
        }
    }

    void Update()
    {
        CalculateMovement();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
        {
            Shoot();
        }
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);
        if (transform.position.y >= -1.5f)
        {
            transform.position = new Vector3(transform.position.x, -1.5f, 0);
        }
        else if (transform.position.y <= -4f)
        {
            transform.position = new Vector3(transform.position.x, -4f, 0);
        }
        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0);
        }
    }
    
    private void Shoot()
    {
        _nextFire = Time.time + fireRate;
        if (_tripleShootActive == true)
        {
            Instantiate(_laserPrefabTriple,  transform.position + new Vector3(0, 0.1f, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(_laserPrefab,  transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        }
    }

    public void Damage()
    {
        if (_shieldActive == true)
        {
            return;
        }

        _lives -= 1;
        if (_lives < 1)
        {
            Die();
        }
    }

    public void Die()
    {
        _spawnManager.OnPlayerDeath();
        Destroy(this.gameObject);
    }

    public void TripleShootActive()
    {
        _tripleShootActive = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5f);
        _tripleShootActive = false;
    }

    public void SpeedBoostActive()
    {
        _speedBoostActive = true;
        _speed *= _speedMultiplier;
        StartCoroutine(SpeedBoostDownRoutine());
    }

    IEnumerator SpeedBoostDownRoutine()
    {
        yield return new WaitForSeconds(5f);
        _speedBoostActive = false;
        _speed /= _speedMultiplier;
    }

    public void ShieldsActive()
    {
        _shieldActive = true;
        StartCoroutine(ShieldsDownRoutine());
    }

    IEnumerator ShieldsDownRoutine()
    {
        yield return new WaitForSeconds(5f);
        _shieldActive = false;
    }
}
