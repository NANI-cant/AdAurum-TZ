namespace CodeBase.Architecture {
    public abstract class AState {
        public virtual void Enter(object payload = null){}
        public virtual void Exit(){}
    }
}