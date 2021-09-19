using UnityEngine;



public class TowerPlacement : MonoBehaviour

{

    private Tower _placedTower;



    // Fungsi yang terpanggil sekali ketika ada object Rigidbody yang menyentuh area collider
    // Kebalikan dari OnTriggerEnter2D, fungsi ini terpanggil sekali ketika object tersebut meninggalkan area collider

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_placedTower != null && _placedTower.IsPlaced && !_placedTower.gameObject.activeSelf)
        {
            _placedTower = null;
        }

        if (_placedTower == null)
        {
            Tower tower = collision.GetComponent<Tower>();
            if (tower != null)
            {
                tower.SetPlacePosition(transform.position);
                _placedTower = tower;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_placedTower == null) return;

        if (!_placedTower.IsPlaced)
        {
            _placedTower.SetPlacePosition(null);
            _placedTower = null;
        }

    }

}