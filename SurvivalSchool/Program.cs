﻿using BusinessLogic.Services;
using DataAccess.Wrapper;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using System.Buffers;
using System.Reflection;
using System.Xml.Linq;

namespace SurvivalSchool
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Настройка базы данных
            builder.Services.AddDbContext<SurvivalSchool1234Context>(
                  options => options.UseSqlServer(builder.Configuration["ConnectionString"]));

            // Регистрация сервисов
            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IVideoService, VideoService>();
            builder.Services.AddScoped<IUserTestResultService, UserTestResultService>();
            builder.Services.AddScoped<IForumPostService, ForumPostService>();
            builder.Services.AddScoped<IForumThreadService, ForumThreadService>();
            builder.Services.AddScoped<ILectureService, LectureService>();
            builder.Services.AddScoped<ITestQuestionService, TestQuestionService>();
            builder.Services.AddScoped<ITestService, TestService>();
            builder.Services.AddScoped<ILectureCommentsService, LectureCommentService>();
            builder.Services.AddScoped<IVideoCommentsService, VideoCommentService>();
            builder.Services.AddScoped<INotificationsService, NotificationsService>();

            // Настройка контроллеров
            builder.Services.AddControllers();

            // Настройка Swagger
            builder.Services.AddEndpointsApiExplorer();



            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "SurvivalSchollAPI",
                    Description = "Школа выживания",
                    Contact = new OpenApiContact
                    {
                        Name = "Наш сайт",
                        Url = new Uri("https://survivalschoolfinalsite.onrender.com/")
                    },
                    License = new OpenApiLicense()
                    {
                        Name = "Бекендер",
                        Url = new Uri("https://t.me/Ares250678")
                    }
                });

                // Включение комментариев из XML-файла
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            // Настройка CORS
            /*builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                {
                    builder.WithOrigins("https://localhost:7207/registration") // Разрешаем запросы с localhost:5104
                      .AllowAnyMethod() // Разрешаем любые методы (GET, POST, PUT, DELETE)
                       .AllowAnyHeader(); // Разрешаем любые заголовки
               });
            });*/

            var app = builder.Build();

            // Инициализация базы данных (миграция и заполнение начальными данными)
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                using (var context = services.GetRequiredService<SurvivalSchool1234Context>())
                {
                    context.Database.Migrate();
                    context.Database.EnsureCreated();

                    // Заполните базу данных ролями
                    if (!context.Roles.Any())
                    {
                        context.Roles.AddRange(
                            new Role { RoleName = "USER" },
                            new Role { RoleName = "ADMIN" },
                            new Role { RoleName = "SUPPORT" }
                        );
                    }

                    // Заполните базу данных категориями
                    if (!context.Categories.Any())
                    {
                        context.Categories.AddRange(
                            new Category { CategoryName = "FOREST" },
                            new Category { CategoryName = "ISLAND" },
                            new Category { CategoryName = "COLLEGE TSARITSINO" }
                        );
                    }

                    context.SaveChanges();
                }
            }

            // Настройка конвейера HTTP-запросов
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(builder => builder.WithOrigins(new[] { "https://survivalschoolfinalapi.onrender.com/", })
           .AllowAnyHeader()
           .AllowAnyMethod()
           .AllowAnyOrigin());

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}