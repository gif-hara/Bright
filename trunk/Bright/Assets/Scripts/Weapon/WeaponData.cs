using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// 武器データ.
	/// </summary>
	[CreateAssetMenu()]
	public class WeaponData : ScriptableObject
	{
		public string WeaponName{ get{ return this.weaponName; } }
		[SerializeField]
		private string weaponName;

		public GameObject AttackPrefab{ get{ return this.attackPrefab; } }
		[SerializeField]
		private GameObject attackPrefab;
	}
}
