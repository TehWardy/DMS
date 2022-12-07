using DMS.Data.Brokers.Events.Import;
using DMS.Data.Brokers.Events.Import.Interfaces;
using DMS.Data.Brokers.Storages.Import;
using DMS.Data.Brokers.Storages.Import.Interfaces;
using DMS.Services.Coordination;
using DMS.Services.Coordination.Interfaces;
using DMS.Services.Foundation.Import;
using DMS.Services.Foundation.Import.Interfaces;
using DMS.Services.Orchestration.Import;
using DMS.Services.Orchestration.Import.Interfaces;
using DMS.Services.Processing.Import;
using DMS.Services.Processing.Import.Interfaces;
using DMS.Services.Transformation.Brokers;
using DMS.Services.Transformation.Brokers.Interfaces;
using DMS.Services.Transformation.Orchestration;
using DMS.Services.Transformation.Orchestration.Interfaces;
using DataLibrary;
using DataLibrary.Interfaces;

namespace DMS.Api
{
    public static partial class IServiceCollectionExtensions
    {
        static void AddImportServices(this IServiceCollection services)
        {
            services.AddImportBrokers();
            services.AddImportFoundationServices();
            services.AddImportProcessingServices();
            services.AddImportOrchestrationServices();

            services.AddTransient<ITransactionCoordinationService, TransactionCoordinationService>();
        }

        static void AddImportBrokers(this IServiceCollection services)
        {
            services.AddTransient<IDMSCSVDataParseBroker, DMSCSVDataParseBroker>();

            services.AddTransient<ICompanyCSVLineBroker, CompanyCSVLineBroker>();
            services.AddTransient<ICompanyCSVLineEventBroker, CompanyCSVLineEventBroker>();

            services.AddTransient<ITransactionCSVLineBroker, TransactionCSVLineBroker>();
            services.AddTransient<ITransactionCSVLineEventBroker, TransactionCSVLineEventBroker>();
        }

        static void AddImportFoundationServices(this IServiceCollection services)
        {
            services.AddTransient<ICompanyCSVLineEventService, CompanyCSVLineEventService>();
            services.AddTransient<ICompanyCSVLineService, CompanyCSVLineService>();

            services.AddTransient<ITransactionCSVLineEventService, TransactionCSVLineEventService>();
            services.AddTransient<ITransactionCSVLineService, TransactionCSVLineService>();
        }

        static void AddImportProcessingServices(this IServiceCollection services)
        {
            services.AddTransient<IParserProcessingService, ParserProcessingService>();

            services.AddTransient<ICompanyCSVLineEventProcessingService, CompanyCSVLineEventProcessingService>();
            services.AddTransient<ICompanyCSVLineProcessingService, CompanyCSVLineProcessingService>();

            services.AddTransient<ITransactionCSVLineEventProcessingService, TransactionCSVLineEventProcessingService>();
            services.AddTransient<ITransactionCSVLineProcessingService, TransactionCSVLineProcessingService>();
        }

        static void AddImportOrchestrationServices(this IServiceCollection services)
        {
            services.AddTransient<ICompanyCSVLineParserOrchestrationService, CompanyCSVLineParserOrchestrationService>();
            services.AddTransient<ITransactionCSVLineParserOrchestrationService, TransactionCSVLineParserOrchestrationService>();

            services.AddTransient<ICompanyCSVLineOrchestrationService, CompanyCSVLineOrchestrationService>();
            services.AddTransient<ITransactionCSVLineOrchestrationService, TransactionCSVLineOrchestrationService>();
        }
    }
}