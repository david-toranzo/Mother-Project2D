using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;



namespace Runtime.Common
{
    public class ParallaxScroll : MonoBehaviour
    {
        public Transform background1; // Primera capa del fondo
        public Transform background2; // Segunda capa del fondo
        public Transform background3; // Tercera capa del fondo

        public float parallaxFactor1 = 0.5f; // Factor de parallax para la primera capa
        public float parallaxFactor2 = 1f; // Factor de parallax para la segunda capa
        public float parallaxFactor3 = 2f; // Factor de parallax para la tercera capa

        private float startPosX;
        private float lengthX;

        private CinemachineVirtualCamera virtualCamera;
        private float initialVirtualCameraPosX;

        private void Start()
        {
            startPosX = transform.position.x;
            lengthX = background1.GetComponent<SpriteRenderer>().bounds.size.x;

            virtualCamera = GetComponent<CinemachineVirtualCamera>();
            initialVirtualCameraPosX = virtualCamera.transform.position.x;
        }

        private void Update()
        {
            float distX = virtualCamera.transform.position.x - initialVirtualCameraPosX;

            // Movimiento parallax para la primera capa
            float tempPosX1 = startPosX + distX * parallaxFactor1;
            Vector3 background1Pos = new Vector3(tempPosX1, background1.position.y, background1.position.z);
            background1.position = background1Pos;

            // Movimiento parallax para la segunda capa
            float tempPosX2 = startPosX + distX * parallaxFactor2;
            Vector3 background2Pos = new Vector3(tempPosX2, background2.position.y, background2.position.z);
            background2.position = background2Pos;

            // Movimiento parallax para la tercera capa
            float tempPosX3 = startPosX + distX * parallaxFactor3;
            Vector3 background3Pos = new Vector3(tempPosX3, background3.position.y, background3.position.z);
            background3.position = background3Pos;

            // Si el fondo se ha movido completamente hacia la izquierda, reiniciamos su posición
            if (tempPosX1 < startPosX - lengthX)
                startPosX -= lengthX;
            if (tempPosX2 < startPosX - lengthX)
                startPosX -= lengthX;
            if (tempPosX3 < startPosX - lengthX)
                startPosX -= lengthX;
        }
    }


}
