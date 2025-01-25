using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UiPath.CodedWorkflows;
using UiPath.CodedWorkflows.Interfaces;
using UiPath.Activities.Contracts;
using TeacherApplicationReviewAutomation;

[assembly: WorkflowRunnerServiceAttribute(typeof(TeacherApplicationReviewAutomation.WorkflowRunnerService))]
namespace TeacherApplicationReviewAutomation
{
    public class WorkflowRunnerService
    {
        private readonly ICodedWorkflowServices _services;
        public WorkflowRunnerService(ICodedWorkflowServices services)
        {
            _services = services;
        }

        /// <summary>
        /// Invokes the LMS/Detailes Requests.cs
        /// </summary>
        public void Detailes_Requests()
        {
            var result = _services.WorkflowInvocationService.RunWorkflow(@"LMS\Detailes Requests.cs", new Dictionary<string, object>{}, default, default, default, GetAssemblyName());
        }

        /// <summary>
        /// Invokes the LMS/Detailes Requests.cs
        /// </summary>
		/// <param name="isolated">Indicates whether to isolate executions (run them within a different process)</param>
        public void Detailes_Requests(System.Boolean isolated)
        {
            var result = _services.WorkflowInvocationService.RunWorkflow(@"LMS\Detailes Requests.cs", new Dictionary<string, object>{}, default, isolated, default, GetAssemblyName());
        }

        /// <summary>
        /// Invokes the LMS/LMS_Login.xaml
        /// </summary>
        public void LMS_Login(string In_AdminUser, System.Security.SecureString In_AdminPssaword)
        {
            var result = _services.WorkflowInvocationService.RunWorkflow(@"LMS\LMS_Login.xaml", new Dictionary<string, object>{{"In_AdminUser", In_AdminUser}, {"In_AdminPssaword", In_AdminPssaword}}, default, default, default, GetAssemblyName());
        }

        /// <summary>
        /// Invokes the LMS/LMS_Login.xaml
        /// </summary>
		/// <param name="isolated">Indicates whether to isolate executions (run them within a different process)</param>
        public void LMS_Login(string In_AdminUser, System.Security.SecureString In_AdminPssaword, System.Boolean isolated)
        {
            var result = _services.WorkflowInvocationService.RunWorkflow(@"LMS\LMS_Login.xaml", new Dictionary<string, object>{{"In_AdminUser", In_AdminUser}, {"In_AdminPssaword", In_AdminPssaword}}, default, isolated, default, GetAssemblyName());
        }

        /// <summary>
        /// Invokes the LMS/LMS_Launch.xaml
        /// </summary>
        public void LMS_Launch()
        {
            var result = _services.WorkflowInvocationService.RunWorkflow(@"LMS\LMS_Launch.xaml", new Dictionary<string, object>{}, default, default, default, GetAssemblyName());
        }

        /// <summary>
        /// Invokes the LMS/LMS_Launch.xaml
        /// </summary>
		/// <param name="isolated">Indicates whether to isolate executions (run them within a different process)</param>
        public void LMS_Launch(System.Boolean isolated)
        {
            var result = _services.WorkflowInvocationService.RunWorkflow(@"LMS\LMS_Launch.xaml", new Dictionary<string, object>{}, default, isolated, default, GetAssemblyName());
        }

        /// <summary>
        /// Invokes the LMS/Scrape Teacher Rrquestes.xaml
        /// </summary>
        public System.Data.DataTable Scrape_Teacher_Rrquestes()
        {
            var result = _services.WorkflowInvocationService.RunWorkflow(@"LMS\Scrape Teacher Rrquestes.xaml", new Dictionary<string, object>{}, default, default, default, GetAssemblyName());
            return (System.Data.DataTable)result["out_TeacherRequestss"];
        }

        /// <summary>
        /// Invokes the LMS/Scrape Teacher Rrquestes.xaml
        /// </summary>
		/// <param name="isolated">Indicates whether to isolate executions (run them within a different process)</param>
        public System.Data.DataTable Scrape_Teacher_Rrquestes(System.Boolean isolated)
        {
            var result = _services.WorkflowInvocationService.RunWorkflow(@"LMS\Scrape Teacher Rrquestes.xaml", new Dictionary<string, object>{}, default, isolated, default, GetAssemblyName());
            return (System.Data.DataTable)result["out_TeacherRequestss"];
        }

        /// <summary>
        /// Invokes the Main.xaml
        /// </summary>
        public void Main()
        {
            var result = _services.WorkflowInvocationService.RunWorkflow(@"Main.xaml", new Dictionary<string, object>{}, default, default, default, GetAssemblyName());
        }

        /// <summary>
        /// Invokes the Main.xaml
        /// </summary>
		/// <param name="isolated">Indicates whether to isolate executions (run them within a different process)</param>
        public void Main(System.Boolean isolated)
        {
            var result = _services.WorkflowInvocationService.RunWorkflow(@"Main.xaml", new Dictionary<string, object>{}, default, isolated, default, GetAssemblyName());
        }

        /// <summary>
        /// Invokes the LMS/Detailes Requests.xaml
        /// </summary>
        public void LMS_Detailes_Requests()
        {
            var result = _services.WorkflowInvocationService.RunWorkflow(@"LMS\Detailes Requests.xaml", new Dictionary<string, object>{}, default, default, default, GetAssemblyName());
        }

        /// <summary>
        /// Invokes the LMS/Detailes Requests.xaml
        /// </summary>
		/// <param name="isolated">Indicates whether to isolate executions (run them within a different process)</param>
        public void LMS_Detailes_Requests(System.Boolean isolated)
        {
            var result = _services.WorkflowInvocationService.RunWorkflow(@"LMS\Detailes Requests.xaml", new Dictionary<string, object>{}, default, isolated, default, GetAssemblyName());
        }

        private string GetAssemblyName()
        {
            var assemblyProvider = _services.Container.Resolve<ILibraryAssemblyProvider>();
            return assemblyProvider.GetLibraryAssemblyName(GetType().Assembly);
        }
    }
}