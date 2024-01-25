namespace eShop.StateStore.LocalStorage
{
    public class StateStoreBase
    {
        protected Action _listeners = () => { };

        public void AddStateChangeListeners(Action listener) => _listeners += listener;

        public void RemoveStateChangeListeners(Action listener) => _listeners -= listener;

        public void BroadCastStateChange()
        {
            if (_listeners != null)
            {
                _listeners.Invoke();
            }
        }
    }
}
