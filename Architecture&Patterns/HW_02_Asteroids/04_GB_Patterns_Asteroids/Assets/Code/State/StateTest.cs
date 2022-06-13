using UnityEngine;


namespace Code.State
{
    public sealed class StateTest : MonoBehaviour
    {
        private void Start ()
        {
            Context c = new Context(new ConcreteStateA());
            c.Request();
            c.Request();
            c.Request();
            c.Request();
        }
    }
}