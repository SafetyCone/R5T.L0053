using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IActionOperator : IFunctionalityMarker,
        L0066.IActionOperator
    {
        public void Foreach_Of<T>(
            IEnumerable<T> items,
            Action<T> action)
        {
            foreach (var item in items)
            {
                action(item);
            }
        }

        public void Run(Action action)
        {
            this.Run_Action(action);
        }

        public void Run_Action(Action action)
        {
            this.Run_Action_OkIfDefault(action);
        }

        public void Run_Action_OkIfDefault(Action action = default)
        {
            if (action == default)
            {
                return;
            }

            action();
        }

        public void Run_OkIfDefault(Action action = default)
        {
            this.Run_Action_OkIfDefault(action);
        }

        public Task Run(Func<Task> action)
        {
            return this.Run_Action(action);
        }

        public void Run<T1, T2>(
            T1 arg1,
            T2 arg2,
            Action<T1, T2> action)
        {
            this.Run_Action_OkIfDefault(
                arg1,
                arg2,
                action);
        }

        public void Run_Action_OkIfDefault<T1, T2>(
            T1 arg1,
            T2 arg2,
            Action<T1, T2> action = default)
        {
            if (action == default)
            {
                return;
            }

            action(arg1, arg2);
        }
    }
}
