using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPooledRigidbodyComponent : MonoBehaviour, IPoolableComponent
{
    Rigidbody _body; 
    public void Spawned() { }
    public void Despawned()
    {
        if (_body == null)
        {
            _body = GetComponent<Rigidbody>(); 
            if (_body == null)
            {                
                // нет компонента Rigidbody!                 
                return;            
            }        
        }
        // Если это значение не сбросить явно до активации объекта, 
        // вновь активированный объект будет продолжать двигаться с той же 
        // скоростью, которую он имел до исчезновения. 
        _body.velocity = Vector3.zero;        
        _body.angularVelocity = Vector3.zero; 
    } 
}
