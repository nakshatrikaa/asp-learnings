using System;

namespace Learn.DependencyInjection
{
    public class AnotherDependencyService : IAnotherDependencyService
    {
        private readonly IOperationScoped _scoped;
        private readonly IOperationSingleton _singleton;
        private readonly IOperationSingletonInstance _singletonInstance;
        private readonly IOperationTransient _transient;

        public AnotherDependencyService(
            IOperationTransient operationTransient,
            IOperationScoped operationScoped,
            IOperationSingleton operationSingleton,
            IOperationSingletonInstance operationSingletonInstance)
        {
            _transient = operationTransient;
            _scoped = operationScoped;
            _singleton = operationSingleton;
            _singletonInstance = operationSingletonInstance;
        }

        public void Write()
        {
            Console.WriteLine();
            Console.WriteLine("From DependencyService");
            Console.WriteLine($"Transient - {_transient.OperationId}");
            Console.WriteLine($"Scoped - {_scoped.OperationId}");
            Console.WriteLine($"Singleton - {_singleton.OperationId}");
            Console.WriteLine($"SingletonInstance - {_singletonInstance.OperationId}");
        }
    }
}