using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    [SerializeField] private GameObject _dustTrailPrefab;
    private List<GameObject> _dustParticlePool = new List<GameObject>();
    private Animator _animator;
    private GameManager _gameManager;
    private CinemachineImpulseSource _impulse;
    private void Awake()
    {
        _impulse = GetComponent<CinemachineImpulseSource>();
        _gameManager = FindObjectOfType<GameManager>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_gameManager.GetGameState() == GameState.Lost)
        {
            _animator.SetBool("GameOver",true);
        }else if (_gameManager.GetGameState() == GameState.Won)
        {
            _animator.SetBool("Won",true);
        }
    }

    public void DustTrail(Vector3 worldPoint)
    {
        foreach (GameObject g in _dustParticlePool)
        {
            if (!g.activeInHierarchy)
            {
                g.transform.position = worldPoint;
                g.SetActive(true);
                return;
            }
        }
        GameObject newDust = Instantiate(_dustTrailPrefab, worldPoint, transform.rotation);
        _dustParticlePool.Add(newDust);
    }


    public void HitWall(Vector2Int direction)
    {
        Vector3 impulseVelocity = new Vector3(direction.x, direction.y, 0);
        _impulse.GenerateImpulseWithVelocity(impulseVelocity);
        _animator.SetTrigger("Impact");
    }
}
