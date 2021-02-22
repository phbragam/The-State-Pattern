using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Safe : State
{
    public Safe(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
       : base(_npc, _agent, _anim, _player)
    {
        name = STATE.SAFE;
        agent.speed = 10;
        agent.isStopped = false;
        safeBox = GameEnvironment.Instance.SafeBox;
    }

    public override void Enter()
    {
        anim.SetTrigger("isRunning");
        agent.SetDestination(safeBox.position);
        base.Enter();
    }

    public override void Update()
    {
        if (agent.hasPath)
        {
            // I could have used agent.remainingDistance and would not need this 
            // ReachedBox() method
            if (ReachedBox())
            {
                agent.isStopped = true;
                nextState = new Idle(npc, agent, anim, player);
                stage = EVENT.EXIT;
            }
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("isRunning");
    }
}
