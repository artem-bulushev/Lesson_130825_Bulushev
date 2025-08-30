using UnityEngine;

namespace Code.Gameplay.Features.Character.ComponentDriven
{
  public class CharacterHealth : MonoBehaviour
  {
    [SerializeField] private float _health = 100f;
      
    public void Construct()
    {
    }

    public void TakeDamage(float damage)
    {
      _health -= 10;
    }
  }
}