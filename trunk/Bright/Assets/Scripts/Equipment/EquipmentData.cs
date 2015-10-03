using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// 武器データ.
	/// </summary>
	[CreateAssetMenu()]
	public class EquipmentData : ScriptableObject
	{
		public string WeaponName{ get{ return this.weaponName; } }
		[SerializeField]
		private string weaponName;

		public GameObject AttackPrefab{ get{ return this.attackPrefab; } }
		[SerializeField]
		private GameObject attackPrefab;

		private float coolTime = 0.0f;

		public EquipmentData(EquipmentData other)
		{
			this.weaponName = other.weaponName;
			this.attackPrefab = other.attackPrefab;
			this.coolTime = other.coolTime;
		}

		public void Update()
		{
			coolTime -= Time.deltaTime;
		}
	}
}
