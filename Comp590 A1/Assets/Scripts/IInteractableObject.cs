using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    [SerializeField] protected double maxDistance = 1.7;

    public abstract void Interact(InteractionController source);

    public abstract string GetInteractionDescription(InteractionController source);

    public virtual void Update() { }

    public virtual void Start() { }

    public double GetMaxDistance()
    {
        return this.maxDistance;
    }
}
