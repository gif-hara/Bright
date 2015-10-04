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
		public string EquipmentName{ get{ return this.equipmentName; } }
		[SerializeField]
		private string equipmentName;

		public GameObject AttackPrefab{ get{ return this.attackPrefab; } }
		[SerializeField]
		private GameObject attackPrefab;

		private float coolTime = 0.0f;

		public void Copy(EquipmentData other)
		{
			this.equipmentName = other.equipmentName;
			this.attackPrefab = other.attackPrefab;
			this.coolTime = other.coolTime;
		}

		public void Update()
		{
			coolTime -= Time.deltaTime;
		}
	}
}
