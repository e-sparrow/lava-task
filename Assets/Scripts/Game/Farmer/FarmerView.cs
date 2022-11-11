using System.Collections;
using Game.Farmer.Interfaces;
using UnityEngine;
using UnityEngine.AI;
using Utils;

namespace Game.Farmer
{
    public class FarmerView : MonoBehaviour, IFarmerView
    {
        [Header("General")]
        [SerializeField] private float plantDelay;
        
        [Header("Movement")]
        [SerializeField] private NavMeshAgent agent;

        [Header("Animating")]
        [SerializeField] private Animator animator;

        [SerializeField] private string walkKey;
        [SerializeField] private string plantKey;
        
        public IEnumerator Plant(Vector3 position)
        {
            var walk = Animator.StringToHash(walkKey);
            animator.SetBool(walk, true);
            
            agent.SetDestination(position);
            yield return agent.WaitDestination();
            
            animator.SetBool(walk, false);

            var plant = Animator.StringToHash(plantKey);
            animator.SetTrigger(plant);

            yield return new WaitForSeconds(plantDelay);
        }
    }
}