using B_Extensions;
using DamageNumbersPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

public class TextVFXMediator : Singleton<TextVFXMediator>
{
    [SerializeField] DamageNumberMesh goalTextAnim;
    [SerializeField] DamageNumberMesh ballAwayTextAnim;
    [SerializeField] DamageNumberMesh passAwayTextAnim;
    [SerializeField] DamageNumberMesh grabAwayTextAnim;
    [SerializeField] Transform targetPos;

    private readonly IDictionary<TypeTextVFX, DamageNumberMesh>
        textsTypes = new Dictionary<TypeTextVFX, DamageNumberMesh>();

    private new void Awake()
    {
        base.Awake();
        textsTypes.Add(TypeTextVFX.Goal,goalTextAnim);
        textsTypes.Add(TypeTextVFX.BallAway, ballAwayTextAnim);
        textsTypes.Add(TypeTextVFX.Pass, passAwayTextAnim);
        textsTypes.Add(TypeTextVFX.Grab, grabAwayTextAnim);
    }

    public void Publish(TypeTextVFX type, Vector3 positionNew,Quaternion rotationNew) 
    {
        var prototype = textsTypes[type];
        Instantiate(prototype,positionNew,rotationNew);
    }

    public void Publish(TypeTextVFX type)
    {
        var prototype = textsTypes[type];
        Instantiate(prototype, targetPos.position, targetPos.rotation);
    }
}


public enum TypeTextVFX
{
    Goal,
    BallAway,
    Pass,
    Grab,
}