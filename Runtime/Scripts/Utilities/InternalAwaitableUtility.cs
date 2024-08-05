namespace GK.FlexibleObjectReference.Utilities
{
    using UnityEngine;


    /// <summary>
    /// Helper methods for the UnityEngine.Awaitable class.
    /// </summary>
    internal static partial class InternalAwaitableUtility
    {

        /// <summary>
        /// Gets an Awaitable<TResult> that is completed with the specified result.
        /// </summary>
        public static Awaitable<TResult> FromResult<TResult>(TResult result)
        {
            var nullStateMachine = new NullStateMachine();
            var builder = Awaitable.AwaitableAsyncMethodBuilder<TResult>.Create();

            builder.Start(ref nullStateMachine);
            builder.SetResult(result);

            return builder.Task;
        }

    }

}
