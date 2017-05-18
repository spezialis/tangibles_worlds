
// =================================	
// Namespaces.
// =================================

using UnityEngine;
using System.Collections.Generic;

// =================================	
// Define namespace.
// =================================

namespace MirzaBeig
{

    namespace Scripting
    {

        namespace Effects
        {

            // =================================	
            // Classes.
            // =================================

            public abstract class ParticleAffector : MonoBehaviour
            {
                // =================================	
                // Nested classes and structures.
                // =================================

                // ...

                protected struct GetForceParameters
                {
                    public float distanceToAffectorCenterSqr;

                    public Vector3 scaledDirectionToAffectorCenter;
                    public Vector3 particlePosition;
                }

                // =================================	
                // Variables.
                // =================================

                // ...

                [Header("Common Controls")]

                public float radius = Mathf.Infinity;
                public float force = 5.0f;

                public Vector3 offset = Vector3.zero;

                public float scaledRadius
                {
                    get
                    {
                        return radius * transform.lossyScale.x;
                    }
                }

                public AnimationCurve scaleForceByDistance = new AnimationCurve(

                        new Keyframe(0.0f, 1.0f),
                        new Keyframe(1.0f, 1.0f)

                    );

                // If (attached to a particle system): forces will be LOCAL.
                // Else if (attached to a particle system): forces will be SELECTIVE.
                // Else: forces will be GLOBAL.

                new ParticleSystem particleSystem;
                public ParticleSystem[] _particleSystems;

                // All required particle systems that will actually be used.

                List<ParticleSystem> particleSystems = new List<ParticleSystem>();

                // Particles in each system. 

                // Second dimension initialized to max particle count
                // and not modified unless max particle count for that system changes.

                // Prevents allocations each frame.

                ParticleSystem.Particle[][] particleSystemParticles;
                ParticleSystem.MainModule[] particleSystemMainModules;
                Renderer[] particleSystemRenderers;

                // ^I could also just put the system and the module in a struct and make a 2D array
                // instead of having a seperate array for the modules.

                // Current iteration of the particle systems when looping through all of them.
                // Useful to derived classes (like for the vortex particle affector).

                protected ParticleSystem currentParticleSystem;

                // ...

                public bool alwaysUpdate = false;

                // =================================	
                // Functions.
                // =================================

                // ...

                protected virtual void Awake()
                {

                }

                // ...

                protected virtual void Start()
                {
                    particleSystem = GetComponent<ParticleSystem>();
                }

                // Called once per particle system, before entering second loop for its particles.
                // Used for setting up based on particle system-specific data. 

                protected virtual void perParticleSystemSetup()
                {

                }

                // Direction is NOT normalized.

                protected virtual Vector3 getForce(GetForceParameters parameters)
                {
                    return Vector3.zero;
                }

                // ...

                protected virtual void Update()
                {

                }

                // ...

                protected virtual void LateUpdate()
                {
                    float radius = scaledRadius;
                    float radiusSqr = radius * radius;

                    float forceDeltaTime = force * Time.deltaTime;

                    Vector3 transformPosition = transform.position + offset;

                    // LOCAL.
                    // If attached to particle system, use only that.

                    if (particleSystem)
                    {
                        // If just one element, assign as local PS component.

                        if (particleSystems.Count == 1)
                        {
                            particleSystems[0] = particleSystem;
                        }

                        // Else, clear entire array and add only the one.

                        else
                        {
                            particleSystems.Clear();
                            particleSystems.Add(particleSystem);
                        }
                    }

                    // SELECTIVE.
                    // Else if manually assigned a set of systems, use those.

                    else if (_particleSystems.Length != 0)
                    {
                        // If editor array size changed, clear and add again.

                        if (particleSystems.Count != _particleSystems.Length)
                        {
                            particleSystems.Clear();
                            particleSystems.AddRange(_particleSystems);
                        }

                        // Else if array size is the same, then re-assign from
                        // the editor array. I do this in case the elements are different
                        // even though the size is the same.

                        else
                        {
                            for (int i = 0; i < _particleSystems.Length; i++)
                            {
                                particleSystems[i] = _particleSystems[i];
                            }
                        }
                    }

                    // GLOBAL.
                    // Else, take all the ones from the entire scene.

                    // This is the most expensive since it searches the entire scene
                    // and also requires an allocation for every frame due to not knowing
                    // if the particle systems are all the same from the last frame unless
                    // I had a list to compare to from last frame. In that case, I'm not sure
                    // if the performance would be better or worse. Do a test later?

                    else
                    {
                        particleSystems.Clear();
                        particleSystems.AddRange(FindObjectsOfType<ParticleSystem>());
                    }

                    GetForceParameters parameters = new GetForceParameters();

                    int particleSystemsCount = particleSystems.Count;

                    if (particleSystemParticles == null || particleSystemParticles.Length < particleSystemsCount)
                    {
                        particleSystemParticles = new ParticleSystem.Particle[particleSystemsCount][];
                        particleSystemMainModules = new ParticleSystem.MainModule[particleSystemsCount];

                        particleSystemRenderers = new Renderer[particleSystemsCount];

                        for (int i = 0; i < particleSystemsCount; i++)
                        {
                            particleSystemMainModules[i] = particleSystems[i].main;
                            particleSystemRenderers[i] = particleSystems[i].GetComponent<Renderer>();
                        }
                    }

                    for (int i = 0; i < particleSystemsCount; i++)
                    {
                        currentParticleSystem = particleSystems[i];

                        if (!particleSystemRenderers[i].isVisible && !alwaysUpdate)
                        {
                            continue;
                        }

                        int maxParticles = particleSystemMainModules[i].maxParticles;

                        if (particleSystemParticles[i] == null || particleSystemParticles[i].Length < maxParticles)
                        {
                            particleSystemParticles[i] = new ParticleSystem.Particle[maxParticles];
                        }

                        perParticleSystemSetup();

                        int particleCount = currentParticleSystem.GetParticles(particleSystemParticles[i]);
                        float currentParticleSystemExternalForcesMultiplier = currentParticleSystem.externalForces.multiplier;

                        ParticleSystemSimulationSpace simulationSpace = particleSystemMainModules[i].simulationSpace;
                        ParticleSystemScalingMode scalingMode = particleSystemMainModules[i].scalingMode;

                        // I could also store the transforms in an array similar to what I do with modules.
                        // Or, put all of those together into a struct and make an array out of that since
                        // they'll always be assigned/updated at the same time.

                        Transform currentParticleSystemTransform = currentParticleSystem.transform;
                        Transform customSimulationSpaceTransform = particleSystemMainModules[i].customSimulationSpace;

                        // If in world space, there's no need to do any of the extra calculations... simplify the loop!

                        if (simulationSpace == ParticleSystemSimulationSpace.World)
                        {
                            for (int j = 0; j < particleCount; j++)
                            {
                                parameters.particlePosition = particleSystemParticles[i][j].position;

                                parameters.scaledDirectionToAffectorCenter.x = transformPosition.x - parameters.particlePosition.x;
                                parameters.scaledDirectionToAffectorCenter.y = transformPosition.y - parameters.particlePosition.y;
                                parameters.scaledDirectionToAffectorCenter.z = transformPosition.z - parameters.particlePosition.z;

                                parameters.distanceToAffectorCenterSqr = parameters.scaledDirectionToAffectorCenter.sqrMagnitude;

                                if (parameters.distanceToAffectorCenterSqr < radiusSqr)
                                {
                                    float distanceToCenterNormalized = parameters.distanceToAffectorCenterSqr / radiusSqr;
                                    float distanceScale = scaleForceByDistance.Evaluate(distanceToCenterNormalized);

                                    Vector3 force = getForce(parameters);
                                    float forceScale = (forceDeltaTime * distanceScale) * currentParticleSystemExternalForcesMultiplier;

                                    force.x *= forceScale;
                                    force.y *= forceScale;
                                    force.z *= forceScale;

                                    Vector3 particleVelocity = particleSystemParticles[i][j].velocity;

                                    particleVelocity.x += force.x;
                                    particleVelocity.y += force.y;
                                    particleVelocity.z += force.z;

                                    particleSystemParticles[i][j].velocity = particleVelocity;
                                }
                            }
                        }
                        else
                        {
                            Vector3 particleSystemPosition = Vector3.zero;
                            Quaternion particleSystemRotation = Quaternion.identity;
                            Vector3 particleSystemLocalScale = Vector3.one;

                            Transform simulationSpaceTransform = currentParticleSystemTransform;

                            switch (simulationSpace)
                            {
                                case ParticleSystemSimulationSpace.Local:
                                    {
                                        particleSystemPosition = simulationSpaceTransform.position;
                                        particleSystemRotation = simulationSpaceTransform.rotation;
                                        particleSystemLocalScale = simulationSpaceTransform.localScale;

                                        break;
                                    }
                                case ParticleSystemSimulationSpace.Custom:
                                    {
                                        simulationSpaceTransform = customSimulationSpaceTransform;

                                        particleSystemPosition = simulationSpaceTransform.position;
                                        particleSystemRotation = simulationSpaceTransform.rotation;
                                        particleSystemLocalScale = simulationSpaceTransform.localScale;

                                        break;
                                    }
                                default:
                                    {
                                        throw new System.NotSupportedException(

                                            string.Format("Unsupported scaling mode '{0}'.", simulationSpace));
                                    }
                            }

                            for (int j = 0; j < particleCount; j++)
                            {
                                parameters.particlePosition = particleSystemParticles[i][j].position;

                                switch (simulationSpace)
                                {
                                    case ParticleSystemSimulationSpace.Local:
                                    case ParticleSystemSimulationSpace.Custom:
                                        {
                                            switch (scalingMode)
                                            {
                                                case ParticleSystemScalingMode.Hierarchy:
                                                    {
                                                        parameters.particlePosition = simulationSpaceTransform.TransformPoint(particleSystemParticles[i][j].position);

                                                        break;
                                                    }
                                                case ParticleSystemScalingMode.Local:
                                                    {
                                                        // Order is important.

                                                        parameters.particlePosition = Vector3.Scale(parameters.particlePosition, particleSystemLocalScale);
                                                        parameters.particlePosition = particleSystemRotation * parameters.particlePosition;
                                                        parameters.particlePosition = parameters.particlePosition + particleSystemPosition;

                                                        break;
                                                    }
                                                case ParticleSystemScalingMode.Shape:
                                                    {
                                                        parameters.particlePosition = particleSystemRotation * parameters.particlePosition;
                                                        parameters.particlePosition = parameters.particlePosition + particleSystemPosition;

                                                        break;
                                                    }
                                                default:
                                                    {
                                                        throw new System.NotSupportedException(

                                                            string.Format("Unsupported scaling mode '{0}'.", scalingMode));
                                                    }
                                            }

                                            break;
                                        }
                                }

                                parameters.scaledDirectionToAffectorCenter.x = transformPosition.x - parameters.particlePosition.x;
                                parameters.scaledDirectionToAffectorCenter.y = transformPosition.y - parameters.particlePosition.y;
                                parameters.scaledDirectionToAffectorCenter.z = transformPosition.z - parameters.particlePosition.z;

                                parameters.distanceToAffectorCenterSqr = parameters.scaledDirectionToAffectorCenter.sqrMagnitude;

                                //particleSystemParticles[i][j].velocity += forceDeltaTime * Vector3.Normalize(parameters.scaledDirectionToAffectorCenter);

                                if (parameters.distanceToAffectorCenterSqr < radiusSqr)
                                {
                                    // 0.0f -> 0.99...f;

                                    float distanceToCenterNormalized = parameters.distanceToAffectorCenterSqr / radiusSqr;

                                    // Evaluating a curve within a loop which is very likely to exceed a few thousand
                                    // iterations produces a noticeable FPS drop (around minus 2 - 5). Might be a worthwhile
                                    // optimization to check outside all loops if the curve is constant (all keyframes same value),
                                    // and then run a different block of code if true that uses that value as a stored float without 
                                    // having to call Evaluate(t).

                                    float distanceScale = scaleForceByDistance.Evaluate(distanceToCenterNormalized);

                                    // Expanded vector operations for optimization. I think this is already done by 
                                    // the compiler, but it's nice to have for the editor anyway.

                                    Vector3 force = getForce(parameters);
                                    float forceScale = (forceDeltaTime * distanceScale) * currentParticleSystemExternalForcesMultiplier;

                                    force.x *= forceScale;
                                    force.y *= forceScale;
                                    force.z *= forceScale;

                                    switch (simulationSpace)
                                    {
                                        case ParticleSystemSimulationSpace.Local:
                                        case ParticleSystemSimulationSpace.Custom:
                                            {
                                                switch (scalingMode)
                                                {
                                                    case ParticleSystemScalingMode.Hierarchy:
                                                        {
                                                            force = simulationSpaceTransform.InverseTransformVector(force);

                                                            break;
                                                        }
                                                    case ParticleSystemScalingMode.Local:
                                                        {
                                                            // Order is important. 
                                                            // Notice how rotation and scale orders are reversed.

                                                            force = Quaternion.Inverse(particleSystemRotation) * force;
                                                            force = Vector3.Scale(force, new Vector3(

                                                                        1.0f / particleSystemLocalScale.x,
                                                                        1.0f / particleSystemLocalScale.y,
                                                                        1.0f / particleSystemLocalScale.z));

                                                            break;
                                                        }
                                                    case ParticleSystemScalingMode.Shape:
                                                        {
                                                            force = Quaternion.Inverse(particleSystemRotation) * force;

                                                            break;
                                                        }

                                                    // This would technically never execute since it's checked earlier (above).

                                                    default:
                                                        {
                                                            throw new System.NotSupportedException(

                                                                string.Format("Unsupported scaling mode '{0}'.", scalingMode));
                                                        }
                                                }

                                                break;

                                            }
                                    }

                                    Vector3 particleVelocity = particleSystemParticles[i][j].velocity;

                                    particleVelocity.x += force.x;
                                    particleVelocity.y += force.y;
                                    particleVelocity.z += force.z;

                                    particleSystemParticles[i][j].velocity = particleVelocity;
                                }
                            }
                        }

                        particleSystems[i].SetParticles(particleSystemParticles[i], particleCount);
                    }
                }

                // ...

                protected virtual void OnDrawGizmosSelected()
                {
                    Gizmos.color = Color.green;
                    Gizmos.DrawWireSphere(transform.position + offset, scaledRadius);
                }

                // =================================	
                // End functions.
                // =================================

            }

            // =================================	
            // End namespace.
            // =================================

        }

    }

}

// =================================	
// --END-- //
// =================================
