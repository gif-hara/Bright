using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// OnStartAttackイベント時にプレハブを生成するコンポーネント.
	/// </summary>
	public class CreateAttackPrefabOnStartAttack : MonoBehaviour, IReceiveSetEquipmentData, IReceiveStartAttack
	{
		[SerializeField]
		private GameObject attacker;

		[SerializeField]
		private Transform prefabParent;

		[SerializeField]
		private string attackerLayerName;

		private GameObject prefab;

		public void OnSetEquipmentData(EquipmentData data)
		{
			this.prefab = data == null ? null : data.AttackPrefab;
		}

		public void OnStartAttack()
		{
			if(this.prefab == null)
			{
				return;
			}
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
