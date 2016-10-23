using System;
using AdditiveSecretFunction.Services.Abstract;
using AdditiveSecretFunction.Services.Concrete;
using Autofac;
using CommandLine;

namespace AdditiveSecretFunction
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var options = new Options();
            Parser.Default.ParseArgumentsStrict(args, options, OnFail);

            var container = BuildContainer();

            var additiveService = container.Resolve<IAdditiveService>();
            var secretFactory = container.Resolve<SecretFactory>();

            var secret = secretFactory.CreateNewSecretFunction();

            Console.WriteLine(additiveService.IsAdditive(secret, options.Limit)
                ? "The secret function is additive"
                : "The secret function is not additive");
        }

        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.Register(x => new AdditiveService(x.Resolve<IPrimeNumberService>())).As<IAdditiveService>();
            builder.Register(x => new PrimeNumberService()).As<IPrimeNumberService>();
            builder.Register(x => new SecretFactory());

            return builder.Build();
        }

        private static void OnFail()
        {
            Environment.Exit(-1);
        }
    }
}