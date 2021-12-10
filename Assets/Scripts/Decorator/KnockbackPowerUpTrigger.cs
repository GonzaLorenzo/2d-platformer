using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackPowerUpTrigger : MonoBehaviour
{
    ModelController modelStats = new ModelStats(); //Crear nuevo Model Stats y darselo al Model del player

    void Start()
    {
        modelStats = new KnockbackPowerUp(modelStats);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Model playerModel = other.GetComponent<Model>();

        playerModel.GetNewStats(modelStats);

        Destroy(this.gameObject);
    }
}
