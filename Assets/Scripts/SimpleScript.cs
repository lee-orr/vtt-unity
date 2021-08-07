using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using Unity.Mathematics;
using UnityEngine;

namespace LO.VTT
{
    public class SimpleScript : MonoBehaviour
    {
        public Mover movement;
        private float3 direction = new float3(0, 1, 0);
        
        // Update is called once per frame
        void Update()
        {
            float3 currentPosition = transform.position;
            float3 newPosition = movement.UpdateMove(Time.deltaTime, currentPosition, direction);
            if (newPosition.y > 10 || newPosition.y < 0)
            {
                direction *= -1;
                newPosition = currentPosition;
            }

            transform.position = newPosition;
        }
    }

    [Serializable]
    public class Mover
    {
        public float velocity;

        public float3 UpdateMove(float time, float3 position, float3 direction)
        {
            return position + math.normalize(direction) * time * velocity;
        }
    }
}
