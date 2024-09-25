using DmitriySerebryakovKt_31_21.Interfaces.TeachersInterfaces;

namespace DmitriySerebryakovKt_31_21.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITeacherService, TeacherService>();

            return services;
        }
    }
}
