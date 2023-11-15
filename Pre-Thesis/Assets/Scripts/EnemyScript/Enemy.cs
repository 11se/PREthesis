using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyBullet;
    public GameObject EnemyBullet => _enemyBullet;

    public float projectileSpeed = 15f;

    public AudioSource MosterDead;

    public StateMachine stateMachine;
    public NavMeshAgent agent;
    public GameObject player;
    //private Vector3 lastKnowPos;
    public NavMeshAgent Agent { get => agent; }
    public GameObject Player { get => player; }
    public int HP = 150;
    public Transform playerTarget;
    //public Vector3 LastKnowPos { get => lastKnowPos; set => lastKnowPos = value; }
    [SerializeField] private float Radius = 20;
    Vector3 Next_position;
    public GameObject BloodLustPoint;

    //public Path path;
    [Header("Sigh Values")]
    public float sightDistance = 20f;
    public float fieldofView = 85f;
    public float eyeHight;
    [Header("Weapon Value")]
    public Transform IceBall;
    
    [Range(0.1f,50)]
    public float fireRate;
    MobSpawner Spawner;
    public string currentState;
    internal bool isDead;


    // Start is called before the first frame update
    void Start()
    {
        Next_position = transform.position;
        stateMachine =GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        stateMachine.Initialise();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Next_position, transform.position) <= 1.5f)
        {
            Next_position = EnemyRandom_Move.RandomPoint(transform.position, Radius);
            Agent.SetDestination(Next_position);
        }
        CanSeePlayer();
        currentState = stateMachine.activeState.ToString();

        //agent.SetDestination(playerTarget.position);

    }
    public bool CanSeePlayer()
    {
        if (player != null)
        {
            // is the play close enough to see?
            if(Vector3.Distance(transform.position, player.transform.position)< sightDistance)
            {
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyeHight);
                float angleToPlayer = Vector3.Angle(targetDirection,transform.forward);
                if(angleToPlayer  >= -fieldofView && angleToPlayer <= fieldofView)
                {
                    Ray ray = new Ray(transform.position + Vector3.up * eyeHight, targetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    if(Physics.Raycast(ray,out hitInfo, sightDistance))
                    {
                        if(hitInfo.transform.gameObject == player)
                        {
                            Debug.DrawRay(ray.origin, ray.direction * sightDistance);

                            return true;
                        }
                    }
                    
                }
                agent.SetDestination(playerTarget.position);
            }
        }
        return false;
        
    }
    public void TakeDamage(int damageAmount)
    {
        HP-=damageAmount;
        if(HP <= 0)
        {
            DropBloodPoint();
            //if (Spawner != null) Spawner.currentMonster.Remove(this.gameObject);
            Destroy(gameObject);
            //MosterDead.Play();
        }
    }
    
    public void SetSpawner(MobSpawner _spawner)
    {
        Spawner = _spawner;

    }
    void DropBloodPoint()
    {
        Vector3 position = transform.position;
        GameObject BloodPoint = Instantiate(BloodLustPoint,position + new Vector3(0.0f,1.0f,0.0f), Quaternion.identity);
        BloodPoint.SetActive(true);
        Destroy(gameObject);
    }

   
}
