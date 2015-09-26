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
		[SerializeField]
		private string weaponName;
	}
}
