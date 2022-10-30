using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Scripts;
using UnityEngine;

public class CloneSpawner : MonoBehaviour
{
    [Header("Clone spawn and AI settings")] 
    [SerializeField] private Transform spawnPoint;

    [Header("Character Pool System")] 
    [SerializeField] private List<Clone_AI> clonePool;

    [Header("ParticleSystem Pool System")] 
    [SerializeField] private List<ParticleSystem> spawnFX;
    [SerializeField] private List<ParticleSystem> destroyFX;
    
    public static Action<bool, Transform> ParticleSystemHandler;
    
    private volatile GameObject objectFromPool;

    private void Awake() => ParticleSystemHandler += CreateParticle;
    private void OnDisable() => ParticleSystemHandler -= CreateParticle;
    
    public void CreateClone(int cloneAmount, bool subOrDivide)
    {
        for (int i = 0; i < cloneAmount; i++)
        {
            if (subOrDivide)
            {
                SetObject(SearchInPool(clonePool, true), false, spawnPoint);
            }
            else
            {
                SetObject(SearchInPool(clonePool, false), true, spawnPoint);
            }
        }
    }
    private void CreateParticle(bool spawnOrDestroy, Transform position)
    {
        if (spawnOrDestroy)
        {
            var obj = SearchInPool(spawnFX, false);
            SetObject(obj, true, position);
            obj.GetComponent<ParticleSystem>().Play();
        }
        else
        {
            var obj = SearchInPool(destroyFX, false);
            SetObject(obj, true, position);
            obj.GetComponent<ParticleSystem>().Play();
        }
    }
    private void SetObject(GameObject obj, bool isActive, Transform setPosition)
    {
        obj.transform.position = setPosition.position;
        obj.SetActive(isActive);
    }
    private GameObject SearchInPool(List<Clone_AI> poolList, bool activeInHierarchy)
    {
        if (activeInHierarchy)
        {
            foreach (var item in poolList.Where(item => item.gameObject.activeInHierarchy))
            {
                objectFromPool = item.gameObject;
                break;
            }
        }
        else
        {
            foreach (var item in poolList.Where(item => !item.gameObject.activeInHierarchy))
            {
                objectFromPool = item.gameObject;
                break;
            }
        }

        return objectFromPool;
    }
    private GameObject SearchInPool(List<ParticleSystem> poolList, bool activeInHierarchy)
    {
        if (activeInHierarchy)
        {
            foreach (var item in poolList.Where(item => item.gameObject.activeInHierarchy))
            {
                objectFromPool = item.gameObject;
                break;
            }
        }
        else
        {
            foreach (var item in poolList.Where(item => !item.gameObject.activeInHierarchy))
            {
                objectFromPool = item.gameObject;
                break;
            }
        }

        return objectFromPool;
    }
    
}