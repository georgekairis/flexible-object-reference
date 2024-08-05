namespace GK.FlexibleObjectReference.Utilities
{
    using System.Runtime.CompilerServices;


    internal static partial class InternalAwaitableUtility
    {

        /// <summary>
        /// Implementation of the IAsyncStateMachine interface.
        /// </summary>
        readonly struct NullStateMachine : IAsyncStateMachine
        {

            /// <summary>
            /// Advances the state machine to its next state.
            /// This implementation does nothing as it's a null state machine.
            /// </summary>
            public void MoveNext() 
            {
            
            }


            /// <summary>
            /// Configures the state machine.
            /// This implementation does nothing as it's a null state machine.
            /// </summary>
            public void SetStateMachine(IAsyncStateMachine stateMachine) 
            { 
            
            }

        }

    }

}
