using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FubuMVC.Core;
using FubuMVC.StructureMap;
using StructureMap.Configuration.DSL;
using System.Data.SqlClient;

namespace SqlInjectionDemo
{
    public class App : IApplicationSource
    {
        public FubuApplication BuildApplication()
        {
            var fubuApp = FubuApplication.For<MyRegistry>().StructureMap < MyStructureMapRegistry>();
            return fubuApp;
        }
    }

    public class MyRegistry : FubuRegistry
    {
        public MyRegistry()
        {
            Actions
                .IncludeClassesSuffixedWithEndpoint();
            AlterSettings<DiagnosticsSettings>(x => x.TraceLevel = TraceLevel.Verbose);
        }
    }

    public class MyStructureMapRegistry : Registry
    {
        public MyStructureMapRegistry()
        {
            IncludeRegistry<SqlServerRegistry>();
        }
    }

    public class SqlServerRegistry : Registry
    {
        public SqlServerRegistry()
        {
        }
    }
}