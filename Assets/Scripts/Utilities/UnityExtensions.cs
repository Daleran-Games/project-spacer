using UnityEngine;

namespace ProjectSpacer
{

    public static class UnityExtensions
    {

        public static T GetOrAddComponent<T>(this GameObject obj) where T : Component
        {
            T component = obj.GetComponent<T>();

            if (component == null)
            {
                obj.AddComponent<T>();
                component = obj.GetComponent<T>();
            }

            return component;
        }

        /// <summary>
        /// Only return the component if it is a non-null type
        /// </summary>
        /// <typeparam name="T">The type of component to retrieve</typeparam>
        /// <param name="obj">Game object beign searched</param>
        /// <returns>A game component</returns>
        public static T GetRequiredComponent<T>(this GameObject obj) where T : Component
        {
            T component = obj.GetComponent<T>();

            if (component == null)
            {
                Debug.LogError("Expected to find component of type " + typeof(T) + " but found none", obj);
            }

            return component;
        }

        /// <summary>
        /// Casts a Vector2 to a Vector2Int
        /// </summary>
        /// <param name="v">Vector2 to cast</param>
        /// <returns>Vector2Int</returns>
        public static Vector2Int ToVector2Int(this Vector2 v)
        {
            return new Vector2Int(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y));

        }

        /// <summary>
        /// Casts a Vector3 to a Vector2Int
        /// </summary>
        /// <param name="v">Vector 3 to cast</param>
        /// <returns>Vector2Int</returns>
        public static Vector2Int ToVector2Int(this Vector3 v)
        {
            return new Vector2Int(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y));

        }

        /// <summary>
        /// Enables the particle system to emit.
        /// </summary>
        /// <param name="particleSystem">The particle system.</param>
        /// <param name="enabled">If set to <c>true</c> emission will be enabled.</param>
        public static void EnableEmission(this ParticleSystem particleSystem, bool enabled)
        {
            var emission = particleSystem.emission;
            emission.enabled = enabled;
        }

        /// <summary>
        /// Gets the emission rate.
        /// </summary>
        /// <returns>The emission rate.</returns>
        /// <param name="particleSystem">Particle system.</param>
        public static float GetEmissionRate(this ParticleSystem particleSystem)
        {
            return particleSystem.emission.rate.constantMax;
        }

        /// <summary>
        /// Sets the emission rate.
        /// </summary>
        /// <param name="particleSystem">Particle system.</param>
        /// <param name="emissionRate">Emission rate.</param>
        public static void SetEmissionRate(this ParticleSystem particleSystem, float emissionRate)
        {
            var emission = particleSystem.emission;
            var rate = emission.rate;
            rate.constantMax = emissionRate;
            emission.rate = rate;
        }
    }
}
