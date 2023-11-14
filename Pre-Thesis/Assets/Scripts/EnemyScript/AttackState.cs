using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    private float shotTimer;
    Animator anim;

    public override void Enter()
    {
        
    }

    public override void Exit()
    {
       
    }

    public override void Perform()
    {
        /*if (enemy.CanSeePlayer())
        {*/
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            shotTimer += Time.deltaTime;
            enemy.transform.LookAt(enemy.Player.transform);
            // if shot timer > firerate
            if(shotTimer > enemy.fireRate)
            {
                Shoot();
            }
            if(moveTimer > Random.Range(3, 7))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
            //enemy.LastKnowPos = enemy.Player.transform.position;
       /* }
        else
        {
            losePlayerTimer += Time.deltaTime;
            if(losePlayerTimer > 8)
            {
                //Change to search state.
                stateMachine.ChangeState(new PatrolState()); ;
            }
        }*/
    }
    public void Shoot()
    {
        
        //Store ref to gun barrel.
        Transform gunbarrel = enemy.IceBall;
        //instantiate a new buller.
        GameObject IceBalls = GameObject.Instantiate(Resources.Load("Prefab/IceBalls") as GameObject, gunbarrel.position, enemy.transform.rotation);
        
        //calculate the direction to the player.
        Vector3 shootDirection =(enemy.Player.transform.position - gunbarrel.transform.position).normalized;
        //add force rigidbody of ht bullet.
        IceBalls.GetComponent<Rigidbody>().velocity = shootDirection * enemy.projectileSpeed;
        
        Debug.Log("Shoot");
        shotTimer = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
