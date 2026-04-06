using UnityEngine;

public class BadItemCollectable : ItemCollectableBase
{
    public class ItemCollectableCoin : ItemCollectableBase
    {
        protected override void OnCollect()
        {
            base.OnCollect();
            ItemManager.Instance.loseCoins();
        }
    }
}
