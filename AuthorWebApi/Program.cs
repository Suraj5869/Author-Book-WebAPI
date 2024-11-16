
using AuthorWebApi.Data;
using AuthorWebApi.Exceptions;
using AuthorWebApi.Mappers;
using AuthorWebApi.Repositories;
using AuthorWebApi.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace AuthorWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddDbContext<AuthorContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("ConnString"));
            });

            builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            //builder.Services.AddTransient<IAuthorRepository, AuthorRepository>();
            //builder.Services.AddTransient<IBookRepository, BookRepository>();
            //builder.Services.AddTransient<IAuthorDetailRepository, AuthorDetailRepository>();

            builder.Services.AddTransient<IAuthorService, AuthorService>();
            builder.Services.AddTransient<IBookService, BookService>();
            builder.Services.AddTransient<IAuthorDetailsService, AuthorDetailService>();

            builder.Services.AddControllers();
            //Ignore Cyclic issue
            builder.Services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
           
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddExceptionHandler<AppExceptionHandler>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseExceptionHandler(_ => { });
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
