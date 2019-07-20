using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OutreachFeedback.Web.BusinessLogic;
using OutreachFeedback.Web.EF;
using OutreachFeedback.Web.Interface.Repository;
using OutreachFeedback.Web.Interface.Validator;
using OutreachFeedback.Web.Repository;

namespace OutreachFeedback.Web.Rest.Utilities
{
    public static class StartupUtilities
    {
        public static IApplicationBuilder RouteConfiguration(this IApplicationBuilder app)
        {
            return app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "question", action = "" });
            });
        }

        public static IApplicationBuilder DatabaseMigrate(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<OutreachFeedbackDbContext>();
                context.Database.EnsureCreated();
            }

            return app;
        }

        public static IServiceCollection ConfigureDependencyInjections(this IServiceCollection services)
        {
            services.AddTransient<IOutreachFeedbackDbContext, OutreachFeedbackDbContext>();
            services.AddTransient<IQuestionsRepository, QuestionsRepository>();
            services.AddTransient<IFeedbackOptionsRepository, FeedbackOptionsRepository>();
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();
            services.AddTransient<IFeedbackValidator, FeedbackValidator>();

            return services;
        }
    }
}
