using _2_1_Generics_Stack.Controllers;
using _2_1_Generics_Stack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace _2_1_Generics_Stack
{
  

        public class MyDepencyResolver : IDependencyResolver
        {
            private readonly IGenericService<Stu01> _studentService;

            public MyDepencyResolver(IGenericService<Stu01> studentService)
            {
                _studentService = studentService;
            }

            public IDependencyScope BeginScope()
            {
                return this;
            }

            public void Dispose()
            {

            }

            public object GetService(Type serviceType)
            {
                // Return the appropriate service instances based on serviceType
                if (serviceType == typeof(CLStudnetController))
                {
                    return new CLStudnetController(_studentService);
                }

                // Handle other services...

                return null;
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                // Implement if needed
                return Enumerable.Empty<object>();
            }
        }

    }
