### Projeto Inicial da Mentoria | ADO.Net Puro

- Ainda em desenvolvimento...


```CSharp
using Cooperchip.ITDeveloper.Mvc.Extentions.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Cooperchip.ITDeveloper.Mvc.Configurations
{
    public static class MvcAndRazorConfig
    {
        public static IServiceCollection AddMvcAndRazor(this IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(AuditoriaIloggerFilter));
                
                // Todo: Passar na aula esta Validação global contra CSRF;
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());

            }); //.SetCompatibilityVersion(CompatibilityVersion.Version_3_1);  (OUT in the version)

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();

            return services;
        }
    }
}
```