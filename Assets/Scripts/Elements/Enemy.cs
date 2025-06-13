using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Player _player;
    public float speed;
    private Rigidbody _rb;
    public NavMeshAgent navMeshAgent;
    private Animator _animator;
    private bool isWalking;
    public void StartEnemy(Player player)
    {
        _player = player;
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
        
    }
    private void Update()
    {
        if (_player.isCollected)
        {
            //var direction = (_player.transform.position - transform.position).normalized;
            //direction.y = 0;
           // _rb.position += direction * speed;
           navMeshAgent.destination = _player.transform.position;
            if (!isWalking)
            {
                isWalking = true;
                _animator.SetTrigger("Walk");
            }
            
        } 
    }

    public void Stop()
    {
        navMeshAgent.speed = 0;
        _animator.SetTrigger("Idle");
    }
}
