using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WhereToGo.BL.Services.Abstract;
using WhereToGo.BL.Services.Implementation;
using WhereToGo.DAL.Repositories.Abstract;
using WhereToGo.DAL.Repositories.Implementation;
using WhereToGo.BL.Services;
using WhereToGo.DAL.Domain;

namespace WhereToGo.API.Infrastructure
{
    public class Installer
    {
        public static void ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<ITagRepository, TagRepository>();
            services.AddTransient<ITagService, TagService>();
            services.AddTransient<IPlaceRepository, PlaceRepository>();
            services.AddTransient<IPlaceService, PlaceService>();
            services.AddTransient<DbContext, PlacesContext>();

        }
    }
}
