using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private float _speedMultiplier = 2;
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private GameObject _laserPrefabTriple;
    [SerializeField] private GameObject _shields;
    [SerializeField] private GameObject _rightEngine, _leftEngine;
    [SerializeField] private int _lives = 3;
    [SerializeField] private int _score;
    [SerializeField] private AudioClip _laserSoundClip;

    private float _nextFire = 0.0f;
    private SpawnManager _spawnManager;
    private UIManager _uiManager;
    private AudioSource _audioSource;

    public float fireRate = 0.25f;
    public bool _tripleShootActive = false;
    public bool _speedBoostActive = false;
    public bool _shieldActive = false;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _audioSource = GetComponent<AudioSource>();
        if (_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL");
        }
        if (_uiManager == null)
        {
            Debug.LogError("The UI Manager is NULL");
        }
        if (_audioSource == null)
        {
            Debug.LogError("AudioSource on the player is NULL");
        }
        else
        {
            _audioSource.clip = _laserSoundClip;
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
        _audioSource.Play();
    }

    public void Damage()
    {
        if (_shieldActive == true)
        {
            _shieldActive = false;
            _shields.SetActive(false);
            return;
        }
        _lives--;
        _uiManager.UpdateLives(_lives);
        if (_lives == 2)
        {
            _rightEngine.SetActive(true);
        }
        else if (_lives == 1)
        {
            _leftEngine.SetActive(true);
        }
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
        _shields.SetActive(true);
        StartCoroutine(ShieldsDownRoutine());
    }

    IEnumerator ShieldsDownRoutine()
    {
        yield return new WaitForSeconds(25f);
        _shieldActive = false;
        _shields.SetActive(false);
    }

    public void AddScore(int x)
    {
        _score += x;
        _uiManager.UpdateScore(_score);
    }
}
