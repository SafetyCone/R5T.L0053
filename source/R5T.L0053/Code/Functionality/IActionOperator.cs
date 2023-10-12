using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IActionOperator : IFunctionalityMarker
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

        /// <summary>
        /// Chooses <see cref="Run_Actions{TValue}(TValue, Action{TValue}[])"/> as the default.
        /// </summary>
        public void Run<TValue>(
            TValue value,
            params Action<TValue>[] actions)
        {
            this.Run_Actions(
                value,
                actions);
        }

        /// <summary>
        /// Chooses <see cref="Run_Action_OkIfDefault{TValue}(TValue, Action{TValue})"/> as the default.
        /// </summary>
        public void Run_Action<TValue>(
            TValue value,
            Action<TValue> action)
        {
            this.Run_Action_OkIfDefault(
                value,
                action);
        }

        public void Run_OkIfDefault<TValue>(
            TValue value,
            Action<TValue> action = default)
        {
            this.Run_Action_OkIfDefault(
                value,
                action);
        }

        public void Run_Action_OkIfDefault<TValue>(
            TValue value,
            Action<TValue> action = default)
        {
            if (action == default)
            {
                return;
            }

            action(value);
        }

        public void Run_Actions<TValue>(
            TValue value,
            IEnumerable<Action<TValue>> actions)
        {
            foreach (var action in actions)
            {
                this.Run_Action(
                    value,
                    action);
            }
        }

        public void Run_Actions<TValue>(
            TValue value,
            params Action<TValue>[] actions)
        {
            this.Run_Actions(
                value,
                actions.AsEnumerable());
        }

        /// <summary>
		/// Chooses <see cref="Run_Function_OkIfDefault{T, TOutput}(T, Func{T, TOutput})"/> as the default.
		/// </summary>
        public TOutput Run<T, TOutput>(
            T value,
            Func<T, TOutput> function)
        {
            var output = this.Run_Function_OkIfDefault(
                value,
                function);

            return output;
        }

        /// <summary>
        /// Chooses <see cref="Run_Function_OkIfDefault{T, TOutput}(T, Func{T, TOutput})"/> as the default.
        /// </summary>
        public TOutput Run_Function<T, TOutput>(
            T value,
            Func<T, TOutput> function)
        {
            var output = this.Run_Function_OkIfDefault(
                value,
                function);

            return output;
        }

        public TOutput Run_OkIfDefault<T, TOutput>(
            T value,
            Func<T, TOutput> function = default)
        {
            var output = this.Run_Function_OkIfDefault(
                value,
                function);

            return output;
        }

        public TOutput Run_Function_OkIfDefault<T, TOutput>(
            T value,
            Func<T, TOutput> function = default)
        {
            if (function == default)
            {
                return default;
            }

            var output = function(value);
            return output;
        }

        public IEnumerable<TOutput> Run_Functions<T, TOutput>(
            T value,
            IEnumerable<Func<T, TOutput>> functions)
        {
            var output = functions
                .Select(function => this.Run_Function(
                    value,
                    function))
                ;

            return output;
        }

        public TOutput[] Run_Functions<T, TOutput>(
            T value,
            Func<T, TOutput>[] functions)
        {
            var output = this.Run_Functions(
                value,
                functions.AsEnumerable())
                .Now();

            return output;
        }

        public Task Run(Func<Task> action)
        {
            return this.Run_Action(action);
        }

        public Task Run_Action(Func<Task> action)
        {
            return this.Run_Action_OkIfDefault(action);
        }

        public Task Run_OkIfDefault(
            Func<Task> action = default)
        {
            return this.Run_Action_OkIfDefault(action);
        }

        public async Task Run_Action_OkIfDefault(
            Func<Task> action = default)
        {
            if (action == default)
            {
                return;
            }

            await action();
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
