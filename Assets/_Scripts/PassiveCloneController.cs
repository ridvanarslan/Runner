using UnityEngine;

namespace _Scripts
{
    public class PassiveCloneController : MonoBehaviour
    {
        [SerializeField] private Material cloneMaterial;
        private Clone_AI _cloneAI;
        private SkinnedMeshRenderer _renderer;
        private Animator _animator;

        private void Start()
        {
            _cloneAI = GetComponent<Clone_AI>();
            _animator = GetComponent<Animator>();
            _renderer = GetComponentInChildren<SkinnedMeshRenderer>();
        }

        public void SetClone()
        {
            _cloneAI.enabled = true;
            _animator.SetBool("__isCloneActive", true);
            SetMaterial();
            Destroy(this);
        }

        private void SetMaterial()
        {
            var mats = _renderer.materials;
            mats[0] = cloneMaterial;
            _renderer.materials = mats;
        }
    }
    

}