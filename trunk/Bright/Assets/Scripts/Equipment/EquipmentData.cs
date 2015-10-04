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

		public GameObject ItemPrefab{ get{ return this.itemPrefab; } }
		[SerializeField]
		private GameObject itemPrefab;

		[SerializeField]
		private DelayTimer coolTime;

		public EquipmentData Copy
		{
			get
			{
				var copy = ScriptableObject.CreateInstance<EquipmentData>();
				copy.equipmentName = this.equipmentName;
				copy.attackPrefab = this.attackPrefab;
				copy.itemPrefab = this.itemPrefab;
				copy.coolTime = new DelayTimer(this.coolTime);

				return copy;
			}
		}

		public void Update()
		{
			this.coolTime.Update();
		}

		public void ResetCoolTime()
		{
			this.coolTime.Reset();
		}

		public bool CanAttack
		{
			get
			{
				return this.coolTime.Complete;
			}
		}

		public float NormalizeCoolTime
		{
			get
			{
				return this.coolTime.Normalize;
			}
		}
	}
}
