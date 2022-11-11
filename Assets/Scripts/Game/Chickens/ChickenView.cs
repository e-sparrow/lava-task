using System;
using Game.Chickens.Interfaces;
using UnityEngine;
using UnityEngine.AI;
using Utils;

namespace Game.Chickens
{
    public class ChickenView : MonoBehaviour, IChickenView
    {
        public event Action OnHit = () => { };
        
        [Header("Movement")]
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Rigidbody body;

        [SerializeField] private float power;

        [Header("Animations")]
        [SerializeField] private Animator animator;

        [SerializeField] private string walkKey;
        [SerializeField] private string sittingKey;
        [SerializeField] private string peckKey;

        private Coroutine _wait;
        
        public void GoTo(Vector3 position, bool sitDown = false)
        {
            var walk = Animator.StringToHash(walkKey);
            animator.SetBool(walk, true);
            
            var sitting = Animator.StringToHash(sittingKey);
            animator.SetBool(sitting, false);
            
            agent.destination = position;
            _wait = agent
                .WaitDestination()
                .AppendCallback(Perform)
                .Start();

            void Perform()
            {
                animator.SetBool(walk, false);
                
                if (sitDown)
                {
                    animator.SetBool(sitting, true);
                }
            }
        }

        public void SetSpeed(float speed)
        {
            agent.speed = speed;
        }

        public void Peck()
        {
            var peck = Animator.StringToHash(peckKey);
            animator.SetTrigger(peck);
        }

        private void OnMouseDown()
        {
            if (_wait != null)
            {
                _wait.Stop();
            }
            
            agent.enabled = false;
            body.isKinematic = false;

            var force = (transform.position - Camera.main.transform.position).normalized * power;
            body.AddForce(force, ForceMode.Impulse);

            OnHit.Invoke();
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}