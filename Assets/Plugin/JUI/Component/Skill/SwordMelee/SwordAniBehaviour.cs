using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JackUtil {

    public class SwordAniBehaviour : StateMachineBehaviour {

        public SwordMelee melee;
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            melee = animator.gameObject.GetComponent<SwordMelee>();
            if (melee == null) {
                melee = animator.gameObject.GetComponentInChildren<SwordMelee>();
                if (melee == null) {
                    DebugUtil.LogError("未获取到");
                }
            }
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            // DebugUtil.Log("Enter: " + animator.gameObject.name);
            Destroy(animator.gameObject);
        }

        // OnStateMove is called right after Animator.OnAnimatorMove()
        //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that processes and affects root motion
        //}

        // OnStateIK is called right after Animator.OnAnimatorIK()
        //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that sets up animation IK (inverse kinematics)
        //}
    }
}