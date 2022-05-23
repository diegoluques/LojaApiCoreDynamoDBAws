using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using CadastroApiCore.Data.Repositories;
using CadastroApiCore.Domain.Services;
using LojaApiCore.Integrations.Storage;
using SharedApiCore.Domain.Contracts;
using SharedApiCore.Domain.Contracts.Repositories;
using SharedApiCore.Domain.Services;

namespace CadastroApiCore.API.Pipeline
{
    public static class NativeInjector
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            ConfigureRepositories(builder);
            ConfigureAutoMapper(builder);
        }

        public static void ConfigureRepositories(WebApplicationBuilder builder)
        {
            var awsAccessKeyId = builder.Configuration.GetSection("AwsAuth:AwsAccessKeyId").Value;
            var awsSecretAccessKey = builder.Configuration.GetSection("AwsAuth:AwsSecretAccessKey").Value;
            var awsDynamoClient = new AmazonDynamoDBClient(awsAccessKeyId, awsSecretAccessKey, RegionEndpoint.USEast1);

            builder.Services.AddSingleton<IAmazonDynamoDB>(awsDynamoClient);

            builder.Services.AddScoped<IDynamoDBContext, DynamoDBContext>();
            builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
            builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

            builder.Services.AddScoped<IPessoaService, PessoaService>();
            builder.Services.AddScoped<IFileService, S3Service>();
        }

        public static void ConfigureAutoMapper(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
