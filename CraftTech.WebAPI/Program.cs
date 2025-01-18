
using CraftTech.BussinessLayer.Abstract;
using CraftTech.BussinessLayer.Concrete;
using CraftTech.DataAccessLayer.Abstract;
using CraftTech.DataAccessLayer.Concrete;
using CraftTech.DataAccessLayer.EntityFramework;
using CraftTech.WebAPI.Filters;
using Microsoft.OpenApi.Models;
using Swashbuckle.Swagger;

namespace CraftTech.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CraftTech API", Version = "v1" });
                c.OperationFilter<SwaggerFileOperationFilter>();
            });
            builder.Services.AddDbContext<Context>();

            builder.Services.AddScoped<IAboutUsDal, EFAboutUsDal>();
            builder.Services.AddScoped<IAboutUsService, AboutUsManager>();

            builder.Services.AddScoped<IBannerDal,EFBannerDal>();
            builder.Services.AddScoped<IBannerService,BannerManager>();

            builder.Services.AddScoped<IContactDal,EFContactDal>();
            builder.Services.AddScoped<IContactService,ContactManager>();

            builder.Services.AddScoped<IMessageDal,EFMessageDal>();
            builder.Services.AddScoped<IMessageService,MessageManager>();

            builder.Services.AddScoped<IProcessDal,EFProcessDal>();
            builder.Services.AddScoped<IProcessService,ProcessManager>();

            builder.Services.AddScoped<IProductDal,EFProductDal>();
            builder.Services.AddScoped<IProductService,ProductManager>();

            builder.Services.AddScoped<IServiceDal,EFServiceDal>();
            builder.Services.AddScoped<IServiceService,ServiceManager>();

            builder.Services.AddScoped<ISubscribeDal,EFSubscribeDal>();
            builder.Services.AddScoped<ISubscribeService,SubscribeManager>();

            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("CraftTechCors", opt =>
                {
                    opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            var app = builder.Build();
            app.UseStaticFiles();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("./v1/swagger.json", "CraftTech.WebAPI V1"); //originally "./swagger/v1/swagger.json"
                });
            }

            app.UseHttpsRedirection();

            app.UseCors("CraftTechCors");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
