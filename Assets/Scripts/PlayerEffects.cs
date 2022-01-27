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
    private CinemachineImpulseSource _impulse;
    private void Awake()
    {
        _impulse = GetComponent<CinemachineImpulseSource>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        GameManager.OnGameStateChange += OnGameStateChange;
    }

    private void OnDisable()
    {
        GameManager.OnGameStateChange -= OnGameStateChange;
    }

    private void OnGameStateChange(GameState newState)
    {
        if (newState == GameState.Lost)
        {
            _animator.SetBool("GameOver", true);
        }
        else if (newState == GameState.Won)
        {
            _animator.SetBool("Won", true);
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
