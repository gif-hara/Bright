using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// 床を生成するクラス.
	/// </summary>
	public class FloorCreator
	{
		private StageManager stageManager;

		private int y;

		private int initialY;

		/// <summary>
		/// Y座標変更処理を行うか.
		/// </summary>
		private bool calculateFixedY;

		private int continuity;

		private int blank;

		/// <summary>
		/// Y座標の変更可能範囲.
		/// </summary>
		private int RangeY = 2;

		public FloorCreator(StageManager stageManager, int y)
		{
			this.stageManager = stageManager;
            //this.y = y;
			this.y = Random.Range(y - RangeY, y + RangeY + 1);
		    this.y = this.y < 1 ? 1 : this.y;
			this.initialY = y;

			this.blank = Random.Range(0, 4);
		}

		/// <summary>
		/// 生成・自分自身の死亡処理・宝箱の配置・敵の配置を行う.
		/// </summary>
		/// <param name="chunkSize">Chunk size.</param>
		public void Calculate(int chunkSize)
		{
			for(int x=0; x<chunkSize; x++)
			{
				if(this.blank > 0)
				{
					this.blank--;
				}
				else
				{
					var floor = this.stageManager.FloorHolder.GetFloor();
					this.stageManager.CmdCreateFloor(floor.gameObject, x, y);
					this.UpdateY(1.0f);
					this.blank = Random.Range(floor.Width, floor.Width + 3);
				}
			}
		}

		private void UpdateY(float probability)
		{
			if(Random.value > probability)
			{
				return;
			}

			this.y += Random.Range(-1, 2) * 2;
			this.y = this.y < 1 ? 1 : this.y;

			var max = (this.initialY + RangeY);
			var min = (this.initialY - RangeY);
			this.y = this.y >= max ? max : this.y;
			this.y = this.y <= min ? min : this.y;
			this.calculateFixedY = false;
		}
	}
}
