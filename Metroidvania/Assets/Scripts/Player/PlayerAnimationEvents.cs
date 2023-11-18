using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void ShootingEnabled()
    {
        PlayerController.instance.isShooting = true;
    }

    public void ShootingDisabled()
    {
        PlayerController.instance.isShooting = false;
    }

    public void ShootingWhileStanding()
    {
        PlayerController.instance.isShootingOnGround = true;
    }

    public void StopShootingWhileStanding()
    {
        PlayerController.instance.isShootingOnGround = false;
    }

    public void Shoot()
    {
        PlayerController.instance.ShootIdle();
        //Instantiate(PlayerController.instance.shotToFire, PlayerController.instance.shotPoint.position, PlayerController.instance.shotPoint.rotation). moveDirection = new Vector2(transform.localScale.x, 0f);
    }
}
