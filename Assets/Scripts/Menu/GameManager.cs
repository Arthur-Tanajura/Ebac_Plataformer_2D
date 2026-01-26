using System.Collections.Generic;
using DG.Tweening;
using NUnit.Framework;
using UnityEditor.AssetImporters;
using UnityEngine;
using DG.Tweening;

public class GameManager : Singleton<GameManager>
{
    [Header("player")]
    public GameObject playerPrefab;

    [Header("enemy")]
    public List<GameObject> enemies;

    [Header("References")]
    public Transform startPoint;

    [Header("Animation")]
    public float duration = .2f;
    public float delay = .05f;
    public Ease ease = Ease.OutBack;

    private GameObject _currentPlayer;

    public void Start()
    {
        Init();
    }
    public void Init()
    {


    }

    private void SpawnPlayer()
    {
        _currentPlayer = Instantiate(playerPrefab);
        _currentPlayer.transform.position = startPoint.transform.position;
        _currentPlayer.transform.DOScale(0,duration).SetEase(ease).From().SetDelay(delay);
    }














}

 