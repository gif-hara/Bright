using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// OnStartAttackイベント時にプレハブを生成するコンポーネント.
	/// </summary>
	public class CreateAttackPrefabOnStartAttack : MonoBehaviour, IReceiveSetWeaponData, IReceiveStartAttack
	{
		[SerializeField]
		private GameObject attacker;

		[SerializeField]
		private Transform prefabParent;

		[SerializeField]
		private string attackerLayerName;

		private GameObject prefab;

		public void OnSetWeaponData(WeaponData data)
		{
			this.prefab = data.AttackPrefab;
		}

		public void OnStartAttack()
		{
			var instance = Instantiate(prefab);
			instance.transform.parent = this.prefabParent;
			instance.transform.localPosition = Vector3.zero;
			instance.transform.localScale = this.prefab.transform.localScale;
			SetLayer(instance);
			ExecuteEventsExtensions.Broadcast<IReceiveSetAttacker>(instance, null, (handler, eventData) => handler.OnSetAttacker(this.attacker));
		}

		private void SetLayer(GameObject instance)
		{
			var colliders = instance.GetComponentsInChildren<Collider2D>();
			for(int i=0, imax=colliders.Length; i<imax; i++)
			{
				colliders[i].gameObject.layer = LayerMask.NameToLayer(this.attackerLayerName);
			}
		}
	}
}
