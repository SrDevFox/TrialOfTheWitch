using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace CameraMechanic
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class CameraMechanics : MonoBehaviour
    {
        public static CinemachineVirtualCamera cinemachineCamera;

        static Animator _anim;
        void Start()
        {
            cinemachineCamera = GetComponent<CinemachineVirtualCamera>();
            _anim = GetComponent<Animator>();
        }

        public static void CameraShake()
        {  
           _anim.SetTrigger("Shake");
        }

        public static void CameraSize(float size, float time)
        {
            cinemachineCamera.m_Lens.OrthographicSize = Mathf.MoveTowards(cinemachineCamera.m_Lens.OrthographicSize, size, time);
        }
    }

}
