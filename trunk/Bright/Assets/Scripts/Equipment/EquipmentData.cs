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

		[SerializeField]
		private DelayTimer coolTime;

		public void Copy(EquipmentData other)
		{
			this.equipmentName = other.equipmentName;
			this.attackPrefab = other.attackPrefab;
			this.coolTime = new DelayTimer(other.coolTime);
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
